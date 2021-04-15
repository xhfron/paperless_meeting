package com.xhfron.paperless.controller;

import com.xhfron.paperless.bean.Command;
import com.xhfron.paperless.bean.Msg;
import org.springframework.context.annotation.Conditional;
import org.springframework.messaging.handler.annotation.MessageMapping;
import org.springframework.messaging.handler.annotation.SendTo;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.CrossOrigin;



@Controller
public class CommandController {

    @MessageMapping("cmd")
    @SendTo("/cmdQueue")
    Command sendCommand(Command cmd){
        return new Command(cmd);
    }

}
