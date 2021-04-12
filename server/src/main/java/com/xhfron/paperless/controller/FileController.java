package com.xhfron.paperless.controller;

import com.xhfron.paperless.bean.Msg;
import com.xhfron.paperless.service.FileService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("file")
public class FileController {
    @Autowired
    private FileService fileService;

    /**
     * @api {POST} /file/getFileList getFileList
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
     * {"code":200,"message":"ok","obj":[{"name":"typora-setup-x64.exe","address":"C:\\Files\\13\\typora-setup-x64.exe"},
     * {"name":"VSCodeUserSetup-x64-1.51.1.exe","address":"13\\VSCodeUserSetup-x64-1.51.1.exe"}]}
     */
    @PostMapping("getFileList")
    Msg getFileList(@RequestParam int meetingId, int roleId) {
        return new Msg(200, "ok", fileService.getFileList(roleId, meetingId));
    }

    /**
     * @api {POST} /file/download downloadFile
     * @apiVersion 1.0.0
     * @apiGroup File
     * @apiName downloadFile
     * @apiDescription 文件下载
     * @apiParam {Number} fileId
     * @apiParamExample 请求参数示例
     * {
     * "fileId":"209"
     * }
     */
    @PostMapping("download")
    Msg downloadFile(@RequestParam int fileId) {
        return new Msg();
    }


}
