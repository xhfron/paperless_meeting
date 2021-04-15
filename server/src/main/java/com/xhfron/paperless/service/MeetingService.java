package com.xhfron.paperless.service;

import com.xhfron.paperless.bean.MeetingDO;
import com.xhfron.paperless.bean.Msg;
import com.xhfron.paperless.dao.MeetingDao;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Bean;
import org.springframework.stereotype.Component;

@Component
public class MeetingService{
    @Autowired
    private MeetingDao meetingDao;

    public Msg createMeeting(MeetingDO meetingData){
        meetingDao.createMeeting(meetingData);
        return new Msg(200,"ok",meetingData);
    }
}
