package com.xhfron.paperless.dao;

import com.xhfron.paperless.bean.File;
import org.apache.ibatis.annotations.Mapper;
import org.apache.ibatis.annotations.Result;
import org.apache.ibatis.annotations.Select;

import java.util.List;

@Mapper
public interface FileDao {

    @Select("select * from `file` where meeting_id = #{meetingId} and uid in (select file_id from role_file where role_id = #{roleId})")
    @Result(property = "id", column = "uid")
    List<File> getFileList(int roleId, int meetingId);

    @Select("select address from `file` where uid = #{fileId} limit 1")
    String getAddressById(int filedId);

}
