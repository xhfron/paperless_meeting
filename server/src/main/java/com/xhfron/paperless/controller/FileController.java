package com.xhfron.paperless.controller;

import com.xhfron.paperless.bean.Msg;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.multipart.MultipartFile;

@RestController("file")
public class FileController {
    @PostMapping("getFileList")
    Msg getFileList(@RequestParam int meetingId){
        return new Msg();
    }

    @PostMapping("uploadFile")
    Msg uploadFile(MultipartFile file){
        return new Msg();
    }
}
