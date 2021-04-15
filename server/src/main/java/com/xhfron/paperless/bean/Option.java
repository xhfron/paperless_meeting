package com.xhfron.paperless.bean;

public class Option {
    int uid;
    int belongs;
    String content;

    public Option() {
    }

    public Option(int belongs, String content) {
        this.belongs = belongs;
        this.content = content;
    }

    public int getUid() {
        return uid;
    }

    public void setUid(int uid) {
        this.uid = uid;
    }

    public int getBelongs() {
        return belongs;
    }

    public void setBelongs(int belongs) {
        this.belongs = belongs;
    }

    public String getContent() {
        return content;
    }

    public void setContent(String content) {
        this.content = content;
    }
}
