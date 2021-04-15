package com.xhfron.paperless.bean;

import org.springframework.context.annotation.Bean;


public class File {
    int id;
    String name;
    String address;

    public File() {
    }

    public File(int id, String name, String address) {
        this.id = id;
        this.name = name;
        this.address = address;
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
}
