package com.xhfron.paperless.dao;

import com.xhfron.paperless.bean.*;
import org.apache.ibatis.annotations.*;

import java.util.List;

@Mapper
public interface DeviceDao {
    @Select("select * from device")
    @ResultType(com.xhfron.paperless.bean.DeviceDO.class)
    List<DeviceDO> getDevices();

    @Insert("insert into `device` (`mac`,`name`) values(#{mac}, #{name})")
    int addDevice(String name, String mac);

    @Delete("delete from `device` where uid=#{id}")
    Integer deleteDevice(int id);
}
