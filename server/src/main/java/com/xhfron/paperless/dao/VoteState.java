package com.xhfron.paperless.dao;

import org.springframework.stereotype.Component;

import java.util.HashMap;
import java.util.Map;
import java.util.concurrent.ConcurrentHashMap;

@Component
public class VoteState {
    Map<Integer, Integer> voteState = new ConcurrentHashMap<>();

    public int getState(int voteId){

        return  voteState.getOrDefault(voteId,-1);
    }

    public void openVote(int voteId){

        voteState.put(voteId,0);
    }

    public void closeVote(int voteId){

        voteState.put(voteId,-2);
    }

    public void clear(){
        voteState.clear();
    }
}
