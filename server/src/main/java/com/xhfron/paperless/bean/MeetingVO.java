package com.xhfron.paperless.bean;

public class MeetingVO extends MeetingDO{
    public MeetingVO(MeetingDO obj, int deviceId) {

        super(obj);
        this.deviceId = deviceId;
    }
    int deviceId;
    Role role;

    public int getDeviceId() {
        return deviceId;
    }

    public void setDeviceId(int deviceId) {
        this.deviceId = deviceId;
    }

    public Role getRole() {
        return role;
    }

    public void setRole(Role role) {
        this.role = role;
    }
}
