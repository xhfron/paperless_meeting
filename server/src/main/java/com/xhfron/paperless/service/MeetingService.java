package com.xhfron.paperless.service;

import com.xhfron.paperless.bean.MeetingDO;
import com.xhfron.paperless.bean.MeetingVO;
import com.xhfron.paperless.bean.Role;
import com.xhfron.paperless.dao.MeetingDao;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

@Component
public class MeetingService {
    @Autowired
    private MeetingDao meetingDao;
    @Autowired
    private RoleService roleService;

    public MeetingVO getMeetingInfo(int meetingId, int deviceId){
        MeetingDO meetingDO = meetingDao.getMeetingById(meetingId);
        if(meetingDO==null){
            return null;
        }
        MeetingVO meetingVO = new MeetingVO(meetingDO, deviceId);
        Role role = roleService.getRole(meetingId, deviceId);
        meetingVO.setRole(role);
        return meetingVO;
    }
}
