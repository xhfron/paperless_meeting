package com.xhfron.paperless.dao;

import com.xhfron.paperless.bean.MeetingDO;
import com.xhfron.paperless.bean.MeetingVO;
import org.apache.ibatis.annotations.Mapper;
import org.apache.ibatis.annotations.Select;

@Mapper
public interface MeetingDao {
    @Select("select * from `meeting` where uid = #{meetingId} limit 1")
    MeetingDO getMeetingById(int meetingId);



}
