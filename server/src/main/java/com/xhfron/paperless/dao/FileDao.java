package com.xhfron.paperless.dao;

import com.xhfron.paperless.bean.File;
import org.apache.ibatis.annotations.Mapper;
import org.apache.ibatis.annotations.Select;

import java.util.List;

@Mapper
public interface FileDao {
    @Select("select * from `file` where meeting_id = #{meetingId} and uid in (select file_id from role_file where role_id = #{roleId})")
    List<File> getFileList(int roleId, int meetingId);


}
