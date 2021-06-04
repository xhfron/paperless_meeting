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
import java.util.LinkedList;
import java.util.List;

@Component
public class DeviceService {
//    final private String routerLoginUrl = "http://192.168.8.1/cgi-bin/api/router/login";
//    final private String routerClientListUrl = "http://192.168.8.1/cgi-bin/api/client/list";
//    final private String routerDeviceBlockUrl = "http://192.168.8.1/cgi-bin/api/client/block";
//    final private String routerPassword = "admin";
//    final private String deviceRegisterMacPre= "iptables -I INPUT -m mac --mac-source ";
    final String host = "http://192.168.8.1/cgi-bin/";
//    final String username = "root";
//    final String passwd = "admin";
//    //注意顺序嗷
//    //iptables -I INPUT -m mac --mac-source 7c:76:35:e7:13:05 -j ACCEPT
//    //iptables -I INPUT -m mac ! --mac-source 7c:76:35:e7:13:05 -j DROP

/*
    ssh效率过低，使用cgi重写本操作
 */
    private String token;
    @Autowired
    private DeviceDao deviceDao;
    private boolean getOutput = true;

    public int addDevice(String name, String mac){
        return deviceDao.addDevice(name, mac);
    }

    public List<DeviceDO> getDeviceList() {
        return deviceDao.getDevices();
    }



    public RouterInfo getRouterInfo(){
        RouterInfo routerInfo;
        RestTemplate temp = new RestTemplate();
        HttpHeaders headers = new HttpHeaders();
        String info = temp.getForObject(host+"l.py", String.class);
        System.out.println(info);
        return null;
    }

    public Boolean blockNewDevice(){
        try{
            List<DeviceDO> devices = deviceDao.getDevices();
            StringBuffer stringBuffer = new StringBuffer();
            //测试用管理，上线时mac替换为超管设备
            stringBuffer.append("iptables -I INPUT -m mac ! --mac-source 7C:76:35:E7:13:05 -j DROP&&");
            for(DeviceDO device : devices){
              stringBuffer.append("iptables -I INPUT -m mac --mac-source "
                        +device.getMac()+" -j ACCEPT&&");
            }
            String res= new RestTemplate().getForObject(host+"d.py?action=god&&cmd="+stringBuffer.toString(),String.class);
            System.out.println(res);

            return true;

         }catch (Exception e){
            e.printStackTrace();
        }
        return false;
    }

   public Boolean allowDeviceConnect() {
        String res= new RestTemplate().getForObject(host+"d.py?action=allow",String.class);
        System.out.println(res);
        return true;
   }


    public String deleteDevice(int id) {
        return deviceDao.deleteDevice(id).toString();

    }
}
