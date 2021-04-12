package com.xhfron.paperless.controller;

import com.xhfron.paperless.bean.FileDO;
import com.xhfron.paperless.bean.Msg;
import com.xhfron.paperless.service.FileService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.multipart.MultipartFile;

import java.io.File;
import java.io.IOException;
import java.util.List;

@RestController
@RequestMapping("/file")
public class FileController {
    @Autowired
    private FileService fileService;

    @PostMapping("getFileList")
    Msg getFileList(@RequestParam int meetingId) {
        List<FileDO> files = fileService.getFileList(meetingId);
        if (files != null && files.size() > 0) {
            return new Msg(200, "success", files);
        } else {
            return new Msg(200, "文件不存在", null);
        }

    }


    @PostMapping("/upload")
    public Msg upload(@RequestParam MultipartFile file, int meetingId) {
        if (fileService.uploadFile(file, meetingId)) {
            return new Msg("yes");
        }
        return new Msg("nono");

    }

}
