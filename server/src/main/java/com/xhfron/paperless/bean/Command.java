package com.xhfron.paperless.bean;

public class Command {
    String cmd;
    int code;

    public Command() {
    }

    public Command(Command cmd) {
        this.code = cmd.code;
        this.cmd = cmd.cmd;
    }

<<<<<<< HEAD
=======
    public Command(int code, String cmd) {
        this.cmd = cmd;
        this.code = code;
    }

>>>>>>> 8b2262abedb71dd13d9ce82caaaaf077778ed9ac
    public String getCmd() {
        return cmd;
    }

    public void setCmd(String cmd) {
        this.cmd = cmd;
    }

    public int getCode() {
        return code;
    }

    public void setCode(int code) {
        this.code = code;
    }
}
