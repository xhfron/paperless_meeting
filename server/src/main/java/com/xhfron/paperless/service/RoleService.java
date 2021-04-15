package com.xhfron.paperless.service;

import com.xhfron.paperless.bean.Role;
import com.xhfron.paperless.bean.RoleInfo;
import com.xhfron.paperless.dao.RoleDao;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import java.util.List;

@Component
public class RoleService {
    @Autowired
    private RoleDao roleDao;

    public boolean addRole(List<RoleInfo> roleInfos, int meetingId) {
        for (RoleInfo roleInfo : roleInfos) {
            Role role = new Role(roleInfo.getRoleName());
            roleDao.addRole(role);
            deviceRegister(role.getUid(), roleInfo.getDevices(), meetingId);
            filePermit(role.getUid(), roleInfo.getFiles());
        }
        return true;
    }

    private void deviceRegister(int roleId, List<Integer> devices, int meetingId) {
        for (int device : devices) {
            roleDao.addDeviceToRole(roleId, device, meetingId);
        }
    }

    private void filePermit(int roleId, List<Integer> files) {
        for (int fileId : files) {
            roleDao.addFileToRole(roleId, fileId);
        }
    }


}
