package com.xhfron.paperless.service;

import com.xhfron.paperless.bean.Option;
import com.xhfron.paperless.bean.Vote;
import com.xhfron.paperless.dao.VoteDao;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import java.util.List;

@Component
public class VoteService {
    @Autowired
    private VoteDao voteDao;

    public boolean createVote(Vote vote, List<String> options){
        voteDao.createVote(vote);
        for(String optionContent : options){
            Option option = new Option(vote.getUid(),optionContent);
            voteDao.addOption(option);
        }
        return true;
    }
}
