package com.xhfron.paperless.controller;

import com.xhfron.paperless.bean.Msg;
<<<<<<< HEAD
import org.springframework.web.bind.annotation.*;

@RestController
public class FileController {
=======
import com.xhfron.paperless.service.FileService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import javax.servlet.http.HttpServletResponse;
import java.io.*;

@RestController
@RequestMapping("file")
public class FileController {
    @Autowired
    private FileService fileService;
>>>>>>> 8b2262abedb71dd13d9ce82caaaaf077778ed9ac

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
<<<<<<< HEAD
     * {"code":200,"message":"ok","obj":{"fileList":[{"id":1,"name":"1.pdf","address":"meeting1/1.pdf"}]}}
     */
    @PostMapping("getFileList")
    Msg getFileList(@RequestParam int meetingId, int roleId){
        return new Msg();
    }


    /**
     * @api {POST} /file/download downloadFile
=======
     * {"code":200,"message":"ok","obj":[{"name":"typora-setup-x64.exe","address":"C:\\Files\\13\\typora-setup-x64.exe"},
     * {"name":"VSCodeUserSetup-x64-1.51.1.exe","address":"13\\VSCodeUserSetup-x64-1.51.1.exe"}]}
     */
    @PostMapping("getFileList")
    Msg getFileList(@RequestParam int meetingId, int roleId) {
        return new Msg(200, "ok", fileService.getFileList(roleId, meetingId));
    }

    /**
     * @api {GET} /file/download downloadFile
>>>>>>> 8b2262abedb71dd13d9ce82caaaaf077778ed9ac
     * @apiVersion 1.0.0
     * @apiGroup File
     * @apiName downloadFile
     * @apiDescription 文件下载
<<<<<<< HEAD
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


=======
     * @apiParam {Number} fileId
     * @apiParamExample 请求参数示例
     * {
     * "fileId":"209"
     * }
     */
    @GetMapping("download")
    Msg downloadFile(HttpServletResponse response, @RequestParam int fileId) {
        File file = fileService.getFileById(fileId);
        if(!file.exists()){
            return new Msg(200,"下载文件不存在",null);
        }
        response.reset();
        response.setContentType("application/octet-stream");
        response.setCharacterEncoding("utf-8");
        response.setContentLength((int) file.length());
        response.setHeader("Content-Disposition", "attachment;filename=" +file.getName());

        try(BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));) {
            byte[] buff = new byte[1024];
            OutputStream os  = response.getOutputStream();
            int i = 0;
            while ((i = bis.read(buff)) != -1) {
                os.write(buff, 0, i);
                os.flush();
            }
        } catch (IOException e) {
           e.printStackTrace();
        }
        return new Msg(200,"ok",null);
    }
>>>>>>> 8b2262abedb71dd13d9ce82caaaaf077778ed9ac
}
