package com.xhfron.paperless.service;

import com.xhfron.paperless.bean.Msg;
import com.xhfron.paperless.bean.Option;
import com.xhfron.paperless.bean.State;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.messaging.simp.SimpMessageSendingOperations;
import org.springframework.messaging.simp.annotation.SubscribeMapping;
import org.springframework.stereotype.Component;

import java.util.List;

@Component
public class HostService {
    static State state = new State();
    @Autowired
    private VoteService voteService;
    @Autowired
    private SimpMessageSendingOperations simpMessageSendingOperations;

    public String sendMessage(String message){
        simpMessageSendingOperations.convertAndSend("/cmdQueue", message);
        return message;
    }

    public boolean startMeeting(int meetingId){
        sendMessage("aaaaa");
        return true;
    }

    public boolean startVote(int voteId){
        return  true;
    }

    public State changeMode(int mode){
        if(mode==0){
            state.setState("open");

        }else{
            state.setState("close");
        }
        return state;
    }

    public Msg getVoteRes(int voteId){
        //倒计时再说
        return new Msg(200,"ok",voteService.getResultByVoteId(voteId));

    }

}
