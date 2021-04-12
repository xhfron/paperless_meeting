package com.xhfron.paperless.bean;

public class MeetingDO {
    int uid;
    String name,content,beginTime,endTime;

    public MeetingDO() {
    }

    public MeetingDO(MeetingDO obj){
        this.uid = obj.getUid();
        name = obj.getName();
        content = obj.getContent();
        beginTime = obj.getBeginTime();
        endTime = obj.getEndTime();
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

    public String getBeginTime() {
        return beginTime;
    }

    public void setBeginTime(String beginTime) {
        this.beginTime = beginTime;
    }

    public String getEndTime() {
        return endTime;
    }

    public void setEndTime(String endTime) {
        this.endTime = endTime;
    }
}
