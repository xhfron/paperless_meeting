package com.xhfron.paperless.service;

import ch.ethz.ssh2.Connection;
import ch.ethz.ssh2.Session;
import ch.ethz.ssh2.StreamGobbler;
import com.xhfron.paperless.bean.DeviceDO;
import com.xhfron.paperless.bean.RouterInfo;
import com.xhfron.paperless.bean.Token;
import com.xhfron.paperless.dao.DeviceDao;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpEntity;
import org.springframework.http.HttpHeaders;
import org.springframework.stereotype.Component;
import org.springframework.util.LinkedMultiValueMap;
import org.springframework.util.MultiValueMap;
import org.springframework.web.client.RestTemplate;

import java.io.BufferedReader;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.util.List;

@Component
public class DeviceService {
    final private String routerLoginUrl = "http://192.168.8.1/cgi-bin/api/router/login";
    final private String routerClientListUrl = "http://192.168.8.1/cgi-bin/api/client/list";
    final private String routerDeviceBlockUrl = "http://192.168.8.1/cgi-bin/api/client/block";
    final private String routerPassword = "admin";
    final private String deviceRegisterMacPre= "iptables -I INPUT -m mac --mac-source ";
    //注意顺序嗷
    //iptables -I INPUT -m mac --mac-source 7c:76:35:e7:13:05 -j ACCEPT
    //iptables -I INPUT -m mac ! --mac-source 7c:76:35:e7:13:05 -j DROP
    private String token;
    @Autowired
    private DeviceDao dao;


    public List<DeviceDO> getDeviceList() {
        return dao.getDevices();
    }

    private String getToken() {
        if(token!=null){
            return token;
        }
        RestTemplate temp = new RestTemplate();
        MultiValueMap<String, String> body = new LinkedMultiValueMap<>();
        body.add("pwd", routerPassword);
        HttpEntity<MultiValueMap<String,String>> request = new HttpEntity<>(body,null);

        Token res= temp.postForObject(routerLoginUrl, request, Token.class);
        try {
            if(res.getCode()==0){
                token = res.getToken();
            }else {
                throw new Exception("token获取失败");
            }
        }catch (Exception e){
            e.printStackTrace();
        }

        return token;
    }

    public RouterInfo getRouterInfo(){
        RouterInfo routerInfo;
        RestTemplate temp = new RestTemplate();
        HttpHeaders headers = new HttpHeaders();
        headers.add("Authorization", getToken());
        HttpEntity<MultiValueMap<String,String>> request = new HttpEntity<>(headers);
        RouterInfo info = temp.postForObject(routerClientListUrl, request, RouterInfo.class);
        return info;
    }

    public String sshConnect(String cmd){
        String host = "192.168.8.1";
        String username = "root";
        String passwd = "admin";

        try{
            Connection connection = new Connection(host);
            connection.connect();
            if(!connection.authenticateWithPassword(username, passwd)){
                throw new Exception("登录失败！");
            }

            Session session = connection.openSession();
            session.execCommand(cmd);
            InputStream stdout = new StreamGobbler(session.getStdout());

            BufferedReader br = new BufferedReader(new InputStreamReader(stdout));
            StringBuffer stringBuffer = new StringBuffer();
            while (true) {
                String line = br.readLine();
                if (line == null)
                    break;
                stringBuffer.append(line+"\n");
                System.out.println(line);
            }
            return stringBuffer.toString();
         }catch (Exception e){
            e.printStackTrace();
        }
        return "false";
    }

}
