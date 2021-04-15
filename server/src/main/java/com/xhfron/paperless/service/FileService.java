package com.xhfron.paperless.service;

import com.xhfron.paperless.bean.FileDO;
import com.xhfron.paperless.bean.Msg;
import com.xhfron.paperless.dao.FileDao;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;
import org.springframework.web.multipart.MultipartFile;

import java.io.File;
import java.io.IOException;
import java.util.List;

@Component
public class FileService {
    @Autowired
    private FileDao fileDao;
    public FileDO uploadFile(MultipartFile file, int meetingId){
        if (file.isEmpty()) {
            return null;
        }
        FileDO fileDO = null;
        File dir = new File(Integer.toString(meetingId));
        if(!dir.exists()){
            System.out.println(dir.mkdir());
        }
        File dest = new File(dir.getPath() +"/"+ file.getOriginalFilename());
        try {
            file.transferTo(dest);
            fileDO = new FileDO(file.getOriginalFilename(),dest.getPath(),meetingId);
            fileDao.createFileRecord(fileDO);
        } catch (IOException e) {
            e.printStackTrace();
        }
        return fileDO;
    }

    public List<FileDO> getFileList(int meetingId){
        return fileDao.getFilesByMeetingId(meetingId);
    }
}
