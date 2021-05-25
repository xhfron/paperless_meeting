package com.xhfron.paperless.dao;

import com.xhfron.paperless.bean.MeetingDO;
import com.xhfron.paperless.bean.MeetingVO;
import org.apache.ibatis.annotations.Mapper;
import org.apache.ibatis.annotations.Select;
import org.apache.ibatis.annotations.Update;

@Mapper
public interface MeetingDao {
    @Select("select * from `meeting` where uid = #{meetingId} limit 1")
    MeetingDO getMeetingById(int meetingId);

    @Select("select id from `meeting_state` where state = 0 or state = 1 limit 1" )
    Integer getLatestId();

    @Select("select state from `meeting_state` where id = #{meetingId} limit 1")
    Integer getState(int meetingId);

    @Update("update `meeting_state` set state = #{meetingState} where id = #{meetingId}")
    int changeState(int meetingId, int meetingState);

    @Select("select uid from device where mac=#{mac}")
    Integer getDeviceId(String mac);
}
