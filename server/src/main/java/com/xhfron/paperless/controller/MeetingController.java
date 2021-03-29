package com.xhfron.paperless.controller;

import com.xhfron.paperless.bean.Msg;
import org.apache.ibatis.ognl.ObjectElementsAccessor;
import org.springframework.beans.factory.annotation.Required;
import org.springframework.web.bind.annotation.*;
import reactor.util.annotation.NonNull;

@RestController("meeting")
public class MeetingController {


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

        return new Msg();
    }


    /**
     * @api {GET} /meeting/get getMeetingList
     * @apiVersion 1.0.0
     * @apiGroup Meeting
     * @apiName getMeetingList
     * @apiSuccess (响应结果) {Number} code
     * @apiSuccess (响应结果) {String} message
     * @apiSuccess (响应结果) {Object} obj
     * @apiSuccessExample 响应结果示例
     * {"code":200,"obj":{},"message":"ok"}
     */
    @GetMapping("get")
    Msg getMeetingList(){
        return new Msg();
    }


}
