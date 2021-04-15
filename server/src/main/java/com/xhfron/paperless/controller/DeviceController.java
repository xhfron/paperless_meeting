package com.xhfron.paperless.controller;

import com.xhfron.paperless.bean.Msg;
import com.xhfron.paperless.service.DeviceService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/device")
public class DeviceController {

    @Autowired
    private DeviceService deviceService;

    @PostMapping("getDeviceList")
    Msg getDeviceList(){
        return new Msg(200,"ok",deviceService.getDeviceList());
    }
}
