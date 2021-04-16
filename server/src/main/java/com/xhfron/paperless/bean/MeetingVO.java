package com.xhfron.paperless.bean;

<<<<<<< HEAD
public class MeetingVO {
    int id;
    String title;
    String content;
    String beginTime;
    String endTime;
    int deviceId;
    Role role;

=======
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
>>>>>>> 8b2262abedb71dd13d9ce82caaaaf077778ed9ac
}
