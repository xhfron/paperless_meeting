package com.xhfron.paperless.controller;

import com.xhfron.paperless.bean.Msg;
import com.xhfron.paperless.bean.RouterInfo;
import com.xhfron.paperless.service.DeviceService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/device")
public class DeviceController {

    @Autowired
    private DeviceService deviceService;

    @PostMapping("getDeviceList")
    Msg getDeviceList(){
        return new Msg(200,"ok",deviceService.getDeviceList());
    }

    @GetMapping("admin")
    String getToken(@RequestParam String cmd){
        return deviceService.sshConnect(cmd);
    }
}
