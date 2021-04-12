package com.xhfron.paperless.bean;

import org.springframework.context.annotation.Bean;


public class FileDO {
    int uid;
    String name;
    String address;
    int meetingId;
    public FileDO() {
    }

    public FileDO(String name, String address,int meetingId) {
        this.name = name;
        this.address = address;
        this.meetingId = meetingId;
    }

    public int getUid() {
        return uid;
    }

    public void setUid(int uid) {
        this.uid = uid;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getAddress() {
        return address;
    }

    public void setAddress(String address) {
        this.address = address;
    }

    public int getMeetingId() {
        return meetingId;
    }

    public void setMeetingId(int meetingId) {
        this.meetingId = meetingId;
    }
}
