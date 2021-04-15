package com.xhfron.paperless.dao;

import com.xhfron.paperless.bean.Role;
import org.apache.ibatis.annotations.Mapper;

@Mapper
public interface RoleDao {
    int addRole(Role role);
    int addDeviceToRole(int roleId,int deviceId,int meetingId);
    int addFileToRole(int roleId,int fileId);
}
