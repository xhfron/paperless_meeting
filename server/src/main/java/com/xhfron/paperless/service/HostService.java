package com.xhfron.paperless.service;

import com.xhfron.paperless.bean.Command;
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
    @Autowired
    private MeetingService meetingService;

    public void sendMessage(Command cmd) {
        simpMessageSendingOperations.convertAndSend("/topic/cmd", cmd);
    }

    public boolean startMeeting(int meetingId) {
        sendMessage(new Command(0, "开始会议id: " + meetingId));
        meetingService.changeMeetingState(meetingId, 1);
        return true;
    }

    public boolean startVote(int voteId) {
        sendMessage(new Command(4, "开始投票id: " + voteId));
        voteService.changeVoteState(true, voteId);
        return true;
    }

    public boolean closeVote(int voteId) {
        sendMessage(new Command(5, "结束投票id: " + voteId));
        voteService.changeVoteState(false, voteId);
        return true;
    }

    public State changeMode(int mode) {
        if (mode == 0) {
            state.setState("open");
            sendMessage(new Command(1, "腾讯会议开启"));
        } else {
            state.setState("close");
            sendMessage(new Command(2, "腾讯会议关闭"));
        }
        return state;
    }

    public Msg getVoteRes(int voteId) {
        return new Msg(200, "ok", voteService.getResultByVoteId(voteId));
    }

    public void cleanVoteRes(int voteId){
        voteService.cleanRes(voteId);
    }

    public void closeMeeting(int meetingId){

        meetingService.changeMeetingState(meetingId,2);
        sendMessage(new Command(6, "结束会议id: " + meetingId));
    }

}
