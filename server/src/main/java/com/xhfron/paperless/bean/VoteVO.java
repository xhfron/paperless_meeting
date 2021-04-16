package com.xhfron.paperless.bean;

import java.util.List;

<<<<<<< HEAD
public class VoteVO {
    int uid;
    String name;
    String content;
    int type;
    int anonymous;
    int meetingId;
    List<Option> options;

=======
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
>>>>>>> 8b2262abedb71dd13d9ce82caaaaf077778ed9ac
}
