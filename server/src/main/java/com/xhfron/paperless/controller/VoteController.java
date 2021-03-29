package com.xhfron.paperless.controller;

import com.xhfron.paperless.bean.Msg;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController("vote")
public class VoteController {

    @PostMapping("createVote")
    Msg createVote(@RequestParam String title, @RequestParam String content, @RequestParam int type,
                   @RequestParam List<String> options, @RequestParam int limit){
        return new Msg();
    }


    @GetMapping("voteInfo")
    Msg voteInfo(@RequestParam int voteId){
        return  new Msg();
    }
}
