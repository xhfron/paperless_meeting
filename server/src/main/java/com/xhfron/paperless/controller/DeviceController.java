package com.xhfron.paperless.controller;

import com.xhfron.paperless.bean.Msg;
import org.springframework.security.core.parameters.P;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController("device")
public class DeviceController {
    @PostMapping("getDeviceList")
    Msg getDeviceList(){
        return new Msg();
    }
}
