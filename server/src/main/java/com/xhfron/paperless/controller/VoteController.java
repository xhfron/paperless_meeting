package com.xhfron.paperless.controller;

import com.xhfron.paperless.bean.Msg;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

@RestController("vote")
public class VoteController {

    /**
     * @api {POST} /vote/getVoteList getVoteList
     * @apiVersion 1.0.0
     * @apiGroup Vote
     * @apiName getVoteList
     * @apiParam (请求参数) {Number} deviceId
     * @apiParam {Number} meetingId
     * @apiParamExample 请求参数示例
     * {
     *     "deviceId":1,
     *     "meetingId":2
     * }
     * @apiSuccess (响应结果) {Number} code
     * @apiSuccess (响应结果) {String} message
     * @apiSuccess (响应结果) {Object} obj
     * @apiSuccessExample 响应结果示例
     * {"code":200,"message":"ok","obj":{
     *     "voteList":[
     *      {
     *          "id":1,
     *          "name":"eat or not!"
     *          "meetingId":2
     *      }
     * }}
     */
    @PostMapping("getVoteList")
    Msg getVoteList(@RequestParam int deviceId, int meetingId){
        return  new Msg();
    }



    /**
     * @api {POST} /vote/getVoteInfo getVoteInfo
     * @apiVersion 1.0.0
     * @apiGroup Vote
     * @apiName getVoteInfo
     * @apiParam (请求参数) {Number} voteId
     * @apiParamExample 请求参数示例
     * {
     *     "voteId":2
     * }
     * @apiSuccess (响应结果) {Number} code
     * @apiSuccess (响应结果) {String} message
     * @apiSuccess (响应结果) {Object} obj
     * @apiSuccessExample 响应结果示例
     * {"code":200,"message":"ok","obj":{
     *     "id":2,
     *     "name":"eat ot not",
     *     "content":"something about voting",
     *     "type":1,
     *     "anonymous":1,
     *     "meetingId":23,
     *     "options":[{"id":2,"content":"food"}]
     * }}
     */
    @PostMapping("getVoteInfo")
    Msg getVoteInfo(@RequestParam int voteId){
        return new Msg();
    }

    /**
     * @api {POST} /vote/submitOptions submitOption
     * @apiVersion 1.0.0
     * @apiGroup Vote
     * @apiName submitOption
     * @apiParam (请求参数) {Number} voteId
     * @apiParam (请求参数) {Number} optionId
     * @apiParam (请求参数) {Number} deviceId
     * @apiParamExample 请求参数示例
     * {
     *     "optionId":1,
     *     "voteId":4008,
     *     "deviceId":2
     * }
     * @apiSuccess (响应结果) {Number} code
     * @apiSuccess (响应结果) {String} message
     * @apiSuccess (响应结果) {Object} obj
     * @apiSuccessExample 响应结果示例
     * {"code":200,"message":"ok","obj":{}}
     */
    @PostMapping("submitOptions")
    Msg submitOption(@RequestParam int voteId, @RequestParam int optionId, @RequestParam int deviceId){
        return new Msg();
    }

}
