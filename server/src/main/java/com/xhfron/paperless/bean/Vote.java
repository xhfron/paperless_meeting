package com.xhfron.paperless.bean;

public class Vote {
    int uid;
    String name;
    String content;
    int type;
    int anonymous;
    int meetingId;

    public Vote() {
    }

    public Vote(String name, String content, int type, int anonymous, int meetingId) {
        this.name = name;
        this.content = content;
        this.type = type;
        this.anonymous = anonymous;
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

    public String getContent() {
        return content;
    }

    public void setContent(String content) {
        this.content = content;
    }

    public int getType() {
        return type;
    }

    public void setType(int type) {
        this.type = type;
    }

    public int getAnonymous() {
        return anonymous;
    }

    public void setAnonymous(int anonymous) {
        this.anonymous = anonymous;
    }

    public int getMeetingId() {
        return meetingId;
    }

    public void setMeetingId(int meetingId) {
        this.meetingId = meetingId;
    }
}
