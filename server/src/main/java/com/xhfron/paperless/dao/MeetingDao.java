package com.xhfron.paperless.dao;

import com.xhfron.paperless.bean.MeetingDO;
import org.apache.ibatis.annotations.Mapper;

@Mapper
public interface MeetingDao {
    int createMeeting(MeetingDO meeting);
}
