package com.xhfron.paperless.controller;

import com.xhfron.paperless.bean.Command;
import com.xhfron.paperless.bean.Msg;
<<<<<<< HEAD
import org.springframework.context.annotation.Conditional;
import org.springframework.messaging.handler.annotation.MessageMapping;
import org.springframework.messaging.handler.annotation.SendTo;
=======
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Conditional;
import org.springframework.messaging.handler.annotation.MessageMapping;
import org.springframework.messaging.handler.annotation.SendTo;
import org.springframework.messaging.simp.SimpMessageSendingOperations;
>>>>>>> 8b2262abedb71dd13d9ce82caaaaf077778ed9ac
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.CrossOrigin;



@Controller
public class CommandController {

<<<<<<< HEAD
    @MessageMapping("cmd")
    @SendTo("/cmdQueue")
    Command sendCommand(Command cmd){
=======
    @Autowired
    private SimpMessageSendingOperations simpMessageSendingOperations;

    @MessageMapping("/sendCmd")
    @SendTo("/topic/cmd")
    public Command sendCommand(Command cmd){
>>>>>>> 8b2262abedb71dd13d9ce82caaaaf077778ed9ac
        return new Command(cmd);
    }

}
