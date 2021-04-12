package com.xhfron.paperless.controller;

import com.xhfron.paperless.bean.Msg;
import com.xhfron.paperless.bean.VoteVO;
import com.xhfron.paperless.service.VoteService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController("vote")
public class VoteController {
    @Autowired
    private VoteService voteService;

    /**
     * @api {POST} /vote/getVoteList getVoteList
     * @apiVersion 1.0.0
     * @apiGroup Vote
     * @apiName getVoteList
     * @apiParam (请求参数) {Number} deviceId
     * @apiParam {Number} meetingId
     * @apiParamExample 请求参数示例
     * {
     * "deviceId":1,
     * "meetingId":2
     * }
     * @apiSuccess (响应结果) {Number} code
     * @apiSuccess (响应结果) {String} message
     * @apiSuccess (响应结果) {Object} obj
     * @apiSuccessExample 响应结果示例
     * {"code":200,"message":"ok","obj":{
     * "voteList":[
     * {
     * {
     * "id":2,
     * "name":"eat ot not",
     * "content":"something about voting",
     * "type":1,
     * "anonymous":1,
     * "meetingId":23,
     * "options":[{"id":2,"content":"food"},
     * {
     * "id":2,
     * "name":"eat ot not",
     * "content":"something about voting",
     * "type":1,
     * "anonymous":1,
     * "meetingId":23,
     * "options":[{"id":2,"content":"food"}
     * }
     * }}
     */
    @PostMapping("getVoteList")
    Msg getVoteList(@RequestParam int deviceId, @RequestParam int meetingId) {
        List<VoteVO> voteVOList = voteService.getVoteList(meetingId);
        return new Msg(200,"ok",voteVOList);
    }


    /**
     * @api {POST} /vote/submitOption submitOption
     * @apiVersion 1.0.0
     * @apiGroup Vote
     * @apiName submitOption
     * @apiParam (请求参数) {Number} voteId
     * @apiParam (请求参数) {Number} optionId
     * @apiParam (请求参数) {Number} deviceId
     * @apiParamExample 请求参数示例
     * {
     * "optionId":1,
     * "voteId":4008,
     * "deviceId":2
     * }
     * @apiSuccess (响应结果) {Number} code
     * @apiSuccess (响应结果) {String} message
     * @apiSuccess (响应结果) {Object} obj
     * @apiSuccessExample 响应结果示例
     * {"code":200,"message":"ok","obj":{}}
     */
    @PostMapping("submitOption")
    Msg submitOption(@RequestParam int voteId, @RequestParam int optionId, @RequestParam int deviceId) {
        switch (voteService.submitOption(voteId, optionId, deviceId)) {
            case 0:
                return new Msg(200, "投票成功", null);
            case 1:
                return new Msg(200, "禁止对同一选项多次投票", null);
            case 2:
                return new Msg(200, "本投票为单选，禁止多次投票", null);
            default:
                return new Msg(200, "未知错误", null);
        }
    }

}
