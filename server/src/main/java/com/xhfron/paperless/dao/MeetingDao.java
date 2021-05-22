package com.xhfron.paperless.dao;

import com.xhfron.paperless.bean.MeetingDO;
import com.xhfron.paperless.bean.MeetingVO;
import org.apache.ibatis.annotations.Mapper;

import java.util.List;

@Mapper
public interface MeetingDao {
    int createMeeting(MeetingDO meeting);
    List<MeetingVO> getMeetingList();
    int changeMeetingState(int meetingId, int state);
    int insertMeetingState(int uid);
}
