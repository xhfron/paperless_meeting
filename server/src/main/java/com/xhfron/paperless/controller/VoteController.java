package com.xhfron.paperless.controller;

import com.xhfron.paperless.bean.Msg;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

@RestController("vote")
public class VoteController {

    /**
     * @api {POST} /getVoteList getVoteList
     * @apiVersion 1.0.0
     * @apiGroup VoteController
     * @apiName getVoteList
     * @apiParam (请求参数) {Number} deviceId
     * @apiParamExample 请求参数示例
     * deviceId=7725
     * @apiSuccess (响应结果) {Number} code
     * @apiSuccess (响应结果) {String} message
     * @apiSuccess (响应结果) {Object} obj
     * @apiSuccessExample 响应结果示例
     * {"code":7749,"obj":{},"message":"tqSCJQW"}
     */
    @PostMapping("getVoteList")
    Msg getVoteList(@RequestParam int deviceId){
        return  new Msg();
    }

    /**
     * @api {POST} /getVoteInfo getVoteInfo
     * @apiVersion 1.0.0
     * @apiGroup VoteController
     * @apiName getVoteInfo
     * @apiParam (请求参数) {Number} voteId
     * @apiParamExample 请求参数示例
     * voteId=355
     * @apiSuccess (响应结果) {Number} code
     * @apiSuccess (响应结果) {String} message
     * @apiSuccess (响应结果) {Object} obj
     * @apiSuccessExample 响应结果示例
     * {"code":9506,"obj":{},"message":"K"}
     */
    @PostMapping("getVoteInfo")
    Msg getVoteInfo(@RequestParam int voteId){
        return new Msg();
    }

    /**
     * @api {POST} /submitOptions submitOption
     * @apiVersion 1.0.0
     * @apiGroup VoteController
     * @apiName submitOption
     * @apiParam (请求参数) {Number} voteId
     * @apiParam (请求参数) {Number} optionId
     * @apiParam (请求参数) {Number} deviceId
     * @apiParamExample 请求参数示例
     * optionId=4086&voteId=1464&deviceId=6886
     * @apiSuccess (响应结果) {Number} code
     * @apiSuccess (响应结果) {String} message
     * @apiSuccess (响应结果) {Object} obj
     * @apiSuccessExample 响应结果示例
     * {"code":4076,"obj":{},"message":"vKp"}
     */
    @PostMapping("submitOptions")
    Msg submitOption(@RequestParam int voteId, @RequestParam int optionId, @RequestParam int deviceId){
        return new Msg();
    }

}
