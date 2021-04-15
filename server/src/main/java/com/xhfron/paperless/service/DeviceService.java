package com.xhfron.paperless.service;

import com.xhfron.paperless.bean.DeviceDO;
import com.xhfron.paperless.dao.DeviceDao;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import java.util.List;

@Component
public class DeviceService {
    @Autowired
    private DeviceDao dao;

    public List<DeviceDO> getDeviceList(){
        return  dao.getDevices();
    }
}
