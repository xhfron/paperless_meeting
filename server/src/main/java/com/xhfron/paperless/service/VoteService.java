package com.xhfron.paperless.service;

import com.xhfron.paperless.bean.*;
import com.xhfron.paperless.dao.VoteDao;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import java.util.LinkedList;
import java.util.List;

@Component
public class VoteService {
    @Autowired
    private VoteDao voteDao;

    public VoteResultVO getResultByVoteId(int voteId) {
        VoteResultVO voteResultVO = new VoteResultVO(voteId);
        List<Option> options = voteDao.getOptionsByVoteId(voteId);
        for(Option option : options){
            List<String> devices = voteDao.getDevicesByOptionId(option.getUid());
            voteResultVO.addResItem(option.getUid(),devices.size(),devices);
        }
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
        //检测机制有时间再说吧
        voteDao.insertOption(optionId,deviceId);
        return 0;
    }

}
