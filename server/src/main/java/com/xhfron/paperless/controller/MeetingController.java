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
     * meetingId=5692
     * @apiSuccess (响应结果) {Number} code
     * @apiSuccess (响应结果) {String} message
     * @apiSuccess (响应结果) {Object} obj
     * @apiSuccessExample 响应结果示例
     * {"code":8595,"obj":{},"message":"Qv5k7ji58i"}
     */
    @PostMapping(value = "/info")
    Msg info(@RequestParam int meetingId){
        return new Msg();
    }
}
