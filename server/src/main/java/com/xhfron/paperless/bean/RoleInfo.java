package com.xhfron.paperless.bean;

import java.util.List;

public class RoleInfo {
    String roleName;
    List<Integer> files;
    List<Integer> devices;

    public RoleInfo() {
    }

    public RoleInfo(String roleName, List<Integer> files, List<Integer> devices) {
        this.roleName = roleName;
        this.files = files;
        this.devices = devices;
    }

    public String getRoleName() {
        return roleName;
    }

    public void setRoleName(String roleName) {
        this.roleName = roleName;
    }

    public List<Integer> getFiles() {
        return files;
    }

    public void setFiles(List<Integer> files) {
        this.files = files;
    }

    public List<Integer> getDevices() {
        return devices;
    }

    public void setDevices(List<Integer> devices) {
        this.devices = devices;
    }
}
