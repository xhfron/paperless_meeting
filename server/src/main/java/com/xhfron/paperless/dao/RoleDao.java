package com.xhfron.paperless.dao;

import com.xhfron.paperless.bean.Role;
import org.apache.ibatis.annotations.Mapper;
import org.apache.ibatis.annotations.Result;
import org.apache.ibatis.annotations.ResultMap;
import org.apache.ibatis.annotations.Select;

@Mapper
public interface RoleDao {
    @Result(column = "uid", property = "id")
    @Select("select * from role where `uid` = " +
            "(select role_id from device_role where device_id = #{deviceId} and meeting_id = #{meetingId} limit 1)")
    Role getRole(int meetingId, int deviceId);
}
