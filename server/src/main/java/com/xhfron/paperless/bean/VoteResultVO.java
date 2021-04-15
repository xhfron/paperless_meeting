package com.xhfron.paperless.bean;

import java.util.LinkedList;
import java.util.List;

public class VoteResultVO {
    int voteId;
    List<Res> res;

    public VoteResultVO(int voteId) {
        this.voteId = voteId;
        res = new LinkedList<>();
    }

    public void addResItem(int optionId, int number, List<String> devices) {
        res.add(new Res(optionId,number,devices));
    }

    class Res{
        int optionId;
        int number;
        List<String> devices;

        public Res(int optionId, int number, List<String> devices) {
            this.optionId = optionId;
            this.number = number;
            this.devices = devices;
        }

        public int getOptionId() {
            return optionId;
        }

        public void setOptionId(int optionId) {
            this.optionId = optionId;
        }

        public int getNumber() {
            return number;
        }

        public void setNumber(int number) {
            this.number = number;
        }

        public List<String> getDevices() {
            return devices;
        }

        public void setDevices(List<String> devices) {
            this.devices = devices;
        }
    }

    public int getVoteId() {
        return voteId;
    }

    public void setVoteId(int voteId) {
        this.voteId = voteId;
    }

    public List<Res> getRes() {
        return res;
    }

    public void setRes(List<Res> res) {
        this.res = res;
    }
}
