package com.xhfron.paperless.controller;

import com.xhfron.paperless.bean.Msg;
import com.xhfron.paperless.bean.Vote;
import com.xhfron.paperless.service.VoteService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController()
@RequestMapping(value = "/vote")
public class VoteController {

    @Autowired
    private VoteService voteService;

    @PostMapping("createVote")
    Msg createVote(@RequestParam String title, @RequestParam String content, @RequestParam int type,
                   @RequestParam List<String> options, @RequestParam int anonymous, @RequestParam int meetingId) {
        if (voteService.createVote(new Vote(title, content, type, anonymous, meetingId), options)) {
            return new Msg(200, "ok", "null");
        }
        return new Msg("false!");

    }


    @GetMapping("voteInfo")
    Msg voteInfo(@RequestParam int voteId) {
        return new Msg();
    }
}
