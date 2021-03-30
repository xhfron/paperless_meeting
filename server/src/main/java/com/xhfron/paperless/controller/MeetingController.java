package com.xhfron.paperless.controller;

import com.xhfron.paperless.bean.Msg;
import org.apache.ibatis.ognl.ObjectElementsAccessor;
import org.springframework.web.bind.annotation.*;

@RestController("meeting")
public class MeetingController {

    /**
     * @api {POST} /info info
     * @apiVersion 1.0.0
     * @apiGroup MeetingController
     * @apiName info
     * @apiParam (请求参数) {Number} meetingId
     * @apiParamExample 请求参数示例
     *  {
     *      "meetingId":22
     *  }
     * @apiSuccess (响应结果) {Number} code
     * @apiSuccess (响应结果) {String} message
     * @apiSuccess (响应结果) {Object} obj
     * @apiSuccessExample 响应结果示例
     * {
     *     "code": 200,
     *     "message": "ok",
     *     "obj": {
     *         "meetingId":1,
     *         "title":"会议名称",
     *         "content":"会议简介",
     *         "beginTime":"2021-08-08 22:00",
     *         "endTime":"2021-08-08 22:00",
     *         "deviceId":22,
     *         "role":{
     *             "id":1,
     *             "name":"主持人"
     *         }
     *     }
     *
     * }
     */
    @PostMapping(value = "/info")
    Msg info(@RequestParam int meetingId, int deviceId){
        return new Msg();
    }
}
