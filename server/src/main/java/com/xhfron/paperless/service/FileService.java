package com.xhfron.paperless.service;

import com.xhfron.paperless.bean.File;
import com.xhfron.paperless.dao.FileDao;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import java.util.List;

@Component
public class FileService {
    @Autowired
    private FileDao fileDao;

    public List<File> getFileList(int roleId, int meetingId) {
        return fileDao.getFileList(roleId, meetingId);
    }
}
