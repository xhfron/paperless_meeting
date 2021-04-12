package com.xhfron.paperless.controller;

import com.xhfron.paperless.bean.Msg;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController("vote")
@RequestMapping(value = "/vote")
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
