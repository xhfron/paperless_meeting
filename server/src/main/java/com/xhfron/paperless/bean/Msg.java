package com.xhfron.paperless.bean;

public class Msg<T> {
    int code;
    String message;
    T obj;

    public Msg() {
        message = "default";
    }

    public Msg(String message) {
        this.message = message;
    }

    public Msg(int code, String message, T obj) {
        this.code = code;
        this.message = message;
        this.obj = obj;
    }

    public int getCode() {
        return code;
    }

    public void setCode(int code) {
        this.code = code;
    }

    public String getMessage() {
        return message;
    }

    public void setMessage(String message) {
        this.message = message;
    }

    public T getObj() {
        return obj;
    }

    public void setObj(T obj) {
        this.obj = obj;
    }


}
