package com.xhfron.paperless.bean;

import java.util.List;

public class VoteVO extends VoteDO {
    public VoteVO(VoteDO obj, List<Option> options) {
        super(obj);
        this.options = options;
    }

    List<Option> options;

    public List<Option> getOptions() {
        return options;
    }

    public void setOptions(List<Option> options) {
        this.options = options;
    }
}
