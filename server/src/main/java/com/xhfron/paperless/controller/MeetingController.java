package com.xhfron.paperless.controller;

import com.xhfron.paperless.bean.MeetingDO;
import com.xhfron.paperless.bean.Msg;
import com.xhfron.paperless.service.MeetingService;
import org.apache.ibatis.ognl.ObjectElementsAccessor;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Required;
import org.springframework.web.bind.annotation.*;
import reactor.util.annotation.NonNull;

@RestController
@RequestMapping("/meeting")
public class MeetingController {

    @Autowired
    private MeetingService meetingService;

    @RequestMapping(value = "create", method = RequestMethod.POST)
    Msg createMeeting(@RequestParam @NonNull String name,
                      @RequestParam String content,
                      @RequestParam String beginTime,
                      @RequestParam String endTime){
        MeetingDO meetingData = new MeetingDO(name, content, beginTime, endTime);
        return meetingService.createMeeting(meetingData);
    }


    @GetMapping("getMeetingList")
    Msg getMeetingList(@RequestParam int type){
        return new Msg();
    }

}
