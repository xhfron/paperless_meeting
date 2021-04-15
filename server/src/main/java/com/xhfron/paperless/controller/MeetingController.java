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

    /**
     * @api {POST} /meeting/create createMeeting
     * @apiVersion 1.0.0
     * @apiGroup Meeting
     * @apiName createMeeting
     * @apiDescription 创建会议接口
     * @apiParam (请求参数) {String} title 会议主题
     * @apiParam (请求参数) {String} content 会议简介
     * @apiParam (请求参数) {String} beginTime 会议开始时间
     * @apiParam (请求参数) {String} endTime 会议结束时间
     * @apiParamExample 请求参数示例
     * {"title":"会议“,"content":"我想开个会","beginTime":"2021-03-29 18:30",,"endTime":"2021-03-29 18:30"}
     * @apiSuccess (响应结果) {Number} code 状态码
     * @apiSuccess (响应结果) {String} message
     * @apiSuccess (响应结果) {Object} obj
     * @apiSuccessExample 响应结果示例
     * {"code":200,"obj":{},"message":"ok"}
     */
    @RequestMapping(value = "create", method = RequestMethod.POST)
    Msg createMeeting(@RequestParam @NonNull String title,
                      @RequestParam String content,
                      @RequestParam String beginTime,
                      @RequestParam String endTime){
        MeetingDO meetingData = new MeetingDO(title, content, beginTime, endTime);
        return meetingService.createMeeting(meetingData);
    }


    /**
     * @api {GET} /meeting/get getMeetingList 本接口尝试按照会议是否结束进行区分，故暂时搁置
     * @apiVersion 1.0.0
     * @apiGroup Meeting
     * @apiName getMeetingList
     * @apiSuccess (响应结果) {Number} code
     * @apiSuccess (响应结果) {String} message
     * @apiSuccess (响应结果) {Object} obj
     * @apiSuccessExample 响应结果示例
     * {"code":200,"obj":{},"message":"ok"}
     */
    @GetMapping("getMeetingList")
    Msg getMeetingList(@RequestParam int type){
        return new Msg();
    }

}
