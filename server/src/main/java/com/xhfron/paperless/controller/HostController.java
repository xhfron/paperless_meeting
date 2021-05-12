package com.xhfron.paperless.controller;

import com.xhfron.paperless.bean.Msg;
import com.xhfron.paperless.bean.State;
import com.xhfron.paperless.bean.VoteResultVO;
import com.xhfron.paperless.service.HostService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

@RestController()
@RequestMapping("host")
public class HostController {
    @Autowired
    private HostService hostService;
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
     * {"code":200,"message":"ok","obj":null}
     */
    @PostMapping("beginMeeting")
    Msg beginMeeting(int meetingId) {
        if(hostService.startMeeting(meetingId)){
            return new Msg(200,"ok",null);
        }
        return new Msg(200, "something wrong, please reboot system",null);
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
        if(hostService.startVote(voteId)){
            return new Msg(200,"ok",null);
        }
        return new Msg(200, "something wrong, please reboot system",null);
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
        State state = hostService.changeMode(mode);
        return new Msg(200,"ok",state);
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
     * {"code":200,"message":"ok","obj":{"voteId":1,"res":[{"optionId":1,"number":1,"devices":["SDUPAD1（doge)"]},{"optionId":2,"number":1,"devices":["SDUPAD1（doge)"]},{"optionId":3,"number":0,"devices":[]}]}}
     */
    @PostMapping("getVoteRes")
    Msg getVoteRes(@RequestParam int voteId) {
        return hostService.getVoteRes(voteId);
    }

    @PostMapping("closeVote")
    Msg closeVote(@RequestParam int voteId) {
        if(hostService.closeVote(voteId)){
            return new Msg(200,"ok",null);
        }
        return new Msg(200, "something wrong, please reboot system",null);
    }

}
