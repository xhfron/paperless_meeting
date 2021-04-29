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

    @GetMapping("getDeviceList")
    Msg getDeviceList(){
        return new Msg(200,"ok",deviceService.getDeviceList());
    }

    @GetMapping("getRouterInfo")
    Msg getOnlineDevices(){
        return new Msg(200,"ok",deviceService.getRouterInfo());
    }

    @PostMapping("addDevice")
    Msg addDevice(String mac, String name){
        return new Msg(200, "ok", deviceService.addDevice(name, mac));
    }

    @PostMapping("allowDeviceConnect")
    Msg allowDeviceConnect(){
        return new Msg(200, deviceService.allowDeviceConnect().toString(),null);
    }

    @PostMapping("blockNewDevice")
    Msg blockNewDevice(){
        return new Msg(200,deviceService.blockNewDevice().toString(),null);
    }
}
