package com.xhfron.paperless.service;

import com.xhfron.paperless.bean.Role;
import com.xhfron.paperless.dao.RoleDao;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

@Component
public class RoleService {
    @Autowired
    private RoleDao roleDao;

    Role getRole(int meetingId, int deviceId){
        return roleDao.getRole(meetingId, deviceId);
    }
}
