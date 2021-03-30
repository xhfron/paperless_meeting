package com.xhfron.paperless.controller;

import com.xhfron.paperless.bean.Msg;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

@RestController("host")
public class HostController {
    /**
     * @api {POST} /host/beginMeeting beginMeeting
     * @apiVersion 1.0.0
     * @apiGroup Host
     * @apiName beginMeeting
     * @apiParam {int} meetingId 会议的id
     * @apiParamExample {json}
     * {
     *     "meetingId":3
     * }
     * @apiSuccess (响应结果) {Number} code
     * @apiSuccess (响应结果) {String} message
     * @apiSuccess (响应结果) {Object} obj
     * @apiSuccessExample 响应结果示例
     * {"code":200,"message":"ok","obj":{}}
     */
    @PostMapping("beginMeeting")
    Msg beginMeeting(int meetingId) {
        return new Msg();
    }

    /**
     * @api {POST} /host/beginVote beginVote
     * @apiVersion 1.0.0
     * @apiGroup Host
     * @apiName beginVote
     * @apiParam (请求参数) {Number} voteId
     * @apiParamExample 请求参数示例
     * {
     * "voteId":10231
     * }
     * @apiSuccess (响应结果) {Number} code
     * @apiSuccess (响应结果) {String} message
     * @apiSuccess (响应结果) {Object} obj
     * @apiSuccessExample 响应结果示例
     * {"code":200,"message":"ok","obj":{}}
     */
    @PostMapping("beginVote")
    Msg beginVote(@RequestParam int voteId) {
        return new Msg();
    }

    /**
     * @api {POST} /host/programLimit programLimit
     * @apiVersion 1.0.0
     * @apiGroup Host
     * @apiName programLimit
     * @apiParam (请求参数) {Number} mode
     * @apiParamExample 请求参数示例
     * {
     * "mode":1
     * }
     * @apiSuccess (响应结果) {Number} code
     * @apiSuccess (响应结果) {String} message
     * @apiSuccess (响应结果) {Object} obj
     * @apiSuccessExample 响应结果示例
     * {"code":200,"message":"ok","obj":{"state":"open"}}
     */
    @PostMapping("programLimit")
    Msg programLimit(@RequestParam int mode) {
        return new Msg();
    }

    /**
     * @api {POST} /host/getVoteRes getVoteRes
     * @apiVersion 1.0.0
     * @apiGroup Host
     * @apiName getVoteRes
     * @apiParam (请求参数) {Number} voteId
     * @apiParamExample 请求参数示例
     * {"voteId":200}
     * @apiSuccess (响应结果) {Number} code
     * @apiSuccess (响应结果) {String} message
     * @apiSuccess (响应结果) {Object} obj
     * @apiSuccessExample 响应结果示例
     * {"code":200,"message":"ok","obj":{"voteId":2,"res" : [{"optionId":1,"number":2,"devices":["sdu1", "sdu2"]}]}}
     */
    @PostMapping("getVoteRes")
    Msg getVoteRes(@RequestParam int voteId) {
        return new Msg();
    }
}
