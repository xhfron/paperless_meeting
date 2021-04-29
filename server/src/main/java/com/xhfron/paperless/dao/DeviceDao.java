package com.xhfron.paperless.dao;

import com.xhfron.paperless.bean.DeviceDO;
import org.apache.ibatis.annotations.Insert;
import org.apache.ibatis.annotations.Mapper;
import org.apache.ibatis.annotations.ResultType;
import org.apache.ibatis.annotations.Select;

import java.util.List;

@Mapper
public interface DeviceDao {
    @Select("select * from device")
    @ResultType(com.xhfron.paperless.bean.DeviceDO.class)
    List<DeviceDO> getDevices();

    @Insert("insert into `device` (`mac`,`name`) values(#{mac}, #{name})")
    int addDevice(String name, String mac);
}
