package com.xhfron.paperless.controller;

import com.xhfron.paperless.bean.Msg;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequestMapping("/role")
public class RoleController {
    /**
     * @api {POST} /addRole addRole
     * @apiVersion 1.0.0
     * @apiGroup RoleController
     * @apiName addRole
     * @apiParam (请求参数) {String} roleName
     * @apiParamExample 请求参数示例
     * roleName=bnoWa
     * @apiSuccess (响应结果) {Number} code
     * @apiSuccess (响应结果) {String} message
     * @apiSuccess (响应结果) {Object} obj
     * @apiSuccessExample 响应结果示例
     * {"code":6890,"obj":{},"message":"50qP6Vo4"}
     */
    @PostMapping("addRole")
    Msg  addRole(@RequestParam String roleName){
        return new Msg();
    }

    Msg filePermission(@RequestParam int roleId, @RequestParam List<Integer> files){
        return new Msg();
    }

    Msg memberAdd(@RequestParam int roleId, @RequestParam List<Integer> deivces){
        return new Msg();
    }


}