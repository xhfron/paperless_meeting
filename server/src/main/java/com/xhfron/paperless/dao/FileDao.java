package com.xhfron.paperless.dao;

import com.xhfron.paperless.bean.FileDO;
import org.apache.ibatis.annotations.Mapper;

import java.util.List;

@Mapper
public interface FileDao {
    int createFileRecord(FileDO fileDO);
    List<FileDO> getFilesByMeetingId(int meetingId);
    int deleteById(int fileId);
}
