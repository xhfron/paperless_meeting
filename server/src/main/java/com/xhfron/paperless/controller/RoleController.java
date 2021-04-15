package com.xhfron.paperless.controller;

import com.xhfron.paperless.bean.Msg;
import com.xhfron.paperless.bean.RoleInfo;
import com.xhfron.paperless.service.RoleService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;


import java.util.List;

@RestController
@RequestMapping("/role")
public class RoleController {
    @Autowired
    private RoleService roleService;
    /**
     * 本接口要求前端做好数据检查，保证主持人的权限
     * @api {POST} /addRole addRole
     * @apiVersion 1.0.0
     * @apiGroup RoleController
     * @apiName addRole
     * @apiParam (请求参数) {String} roleName, {int} meetingId
     * @apiParamExample 请求参数示例
     * roleName=bnoWa
     * @apiSuccess (响应结果) {Number} code
     * @apiSuccess (响应结果) {String} message
     * @apiSuccess (响应结果) {Object} obj
     * @apiSuccessExample 响应结果示例
     * {"code":6890,"obj":{},"message":"50qP6Vo4"}
     */
    @PostMapping("uploadRole")
    Msg  addRole(@RequestBody List<RoleInfo> roleInfos,@RequestParam int meetingId){

        if(roleService.addRole(roleInfos,meetingId)){
            return new Msg(200,"ok",null);
        }
        return null;
    }


}
