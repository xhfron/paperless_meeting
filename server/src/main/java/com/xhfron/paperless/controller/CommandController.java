package com.xhfron.paperless.controller;

import com.xhfron.paperless.bean.Command;
import com.xhfron.paperless.bean.Msg;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Conditional;
import org.springframework.messaging.handler.annotation.MessageMapping;
import org.springframework.messaging.handler.annotation.SendTo;
import org.springframework.messaging.simp.SimpMessageSendingOperations;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.CrossOrigin;



@Controller
public class CommandController {

    @Autowired
    private SimpMessageSendingOperations simpMessageSendingOperations;

    @MessageMapping("/sendCmd")
    @SendTo("/topic/cmd")
    public Command sendCommand(Command cmd){
        return new Command(cmd);
    }

}
