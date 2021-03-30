package com.xhfron.paperless.controller;

import com.xhfron.paperless.bean.Msg;
import org.springframework.web.bind.annotation.*;

@RestController
public class FileController {

    /**
     * @api {POST} /getFileList getFileList
     * @apiVersion 1.0.0
     * @apiGroup File
     * @apiName getFileList
     * @apiDescription 根据会议和角色获取文件列表
     * @apiParam {Number} meetingId
     * @apiParam {Number} roleId
     * @apiParamExample {json}请求参数示例
     * {"meetingId":12, "roleId":1}
     * @apiSuccess (响应结果) {Number} code
     * @apiSuccess (响应结果) {String} message
     * @apiSuccess (响应结果) {Object} obj
     * @apiSuccessExample 响应结果示例
     * {"code":200,"message":"ok","obj":{"fileList":[{"id":1,"name":"1.pdf","address":"meeting1/1.pdf"}]}}
     */
    @PostMapping("getFileList")
    Msg getFileList(@RequestParam int meetingId, int roleId){
        return new Msg();
    }


    /**
     * @api {POST} /download downloadFile
     * @apiVersion 1.0.0
     * @apiGroup File
     * @apiName downloadFile
     * @apiDescription 文件下载
     * @apiParam  {Number} fileId
     * @apiParamExample 请求参数示例
     * {
     *     "fileId":"209"
     * }
     */
    @PostMapping("download")
    Msg downloadFile(@RequestParam int fileId){
        return new Msg();
    }


}
