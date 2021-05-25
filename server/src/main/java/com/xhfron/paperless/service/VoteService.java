package com.xhfron.paperless.service;

import com.xhfron.paperless.bean.*;
import com.xhfron.paperless.dao.VoteDao;
import com.xhfron.paperless.dao.VoteState;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import java.util.HashMap;
import java.util.LinkedList;
import java.util.List;
import java.util.Map;
import java.util.concurrent.ConcurrentHashMap;

@Component
public class VoteService {
    @Autowired
    private VoteDao voteDao;
    @Autowired
    private VoteState state;

    public void changeVoteState(boolean open, int voteId){
        if(open){
            state.openVote(voteId);
        }else{
            state.closeVote(voteId);
        }
    }

    public VoteResultVO getResultByVoteId(int voteId) {
        VoteResultVO voteResultVO = new VoteResultVO(voteId);
        List<Option> options = voteDao.getOptionsByVoteId(voteId);
        for(Option option : options){
            List<String> devices = voteDao.getDevicesByOptionId(option.getUid());
            voteResultVO.addResItem(option.getUid(),devices.size(),devices);
        }
        voteResultVO.setState(state.getState(voteId));
        return voteResultVO;
    }

    public List<VoteVO> getVoteList(int meetingId){
       List<VoteDO> voteDOList = voteDao.getVoteListByMeetingId(meetingId);
        List<VoteVO> voteVOList = new LinkedList<>();
        for(VoteDO voteDO : voteDOList) {
            voteVOList.add(new VoteVO(voteDO, voteDao.getOptionsByVoteId(voteDO.getUid())));
        }
        return voteVOList;
    }

    public int submitOption(int voteId, int optionId, int deviceId){
        if(state.getState(voteId)==0){
            voteDao.insertOption(optionId,deviceId);
        }
        return state.getState(voteId);
    }

    public void cleanRes(int voteId){
        voteDao.cleanRes(voteId);
        state.clear();
    }
}
