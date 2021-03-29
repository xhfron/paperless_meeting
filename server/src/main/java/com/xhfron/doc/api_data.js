define({ "api": [
  {
    "type": "POST",
    "url": "/create",
    "title": "createMeeting",
    "version": "1.0.0",
    "group": "Meeting",
    "name": "createMeeting",
    "description": "<p>创建会议接口</p>",
    "parameter": {
      "fields": {
        "请求参数": [
          {
            "group": "请求参数",
            "type": "String",
            "optional": false,
            "field": "title",
            "description": "<p>会议主题</p>"
          },
          {
            "group": "请求参数",
            "type": "String",
            "optional": false,
            "field": "content",
            "description": "<p>会议简介</p>"
          },
          {
            "group": "请求参数",
            "type": "String",
            "optional": false,
            "field": "beginTime",
            "description": "<p>会议开始时间</p>"
          },
          {
            "group": "请求参数",
            "type": "String",
            "optional": false,
            "field": "endTime",
            "description": "<p>会议结束时间</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "请求参数示例",
          "content": "beginTime=GiiuC8&endTime=pVMJjQzC9&title=zo9rS6Twx&content=eQSZ",
          "type": "json"
        }
      ]
    },
    "success": {
      "fields": {
        "响应结果": [
          {
            "group": "响应结果",
            "type": "Number",
            "optional": false,
            "field": "code",
            "description": "<p>状态码</p>"
          },
          {
            "group": "响应结果",
            "type": "String",
            "optional": false,
            "field": "message",
            "description": ""
          },
          {
            "group": "响应结果",
            "type": "Object",
            "optional": false,
            "field": "obj",
            "description": ""
          }
        ]
      },
      "examples": [
        {
          "title": "响应结果示例",
          "content": "{\"code\":200,\"obj\":{},\"message\":\"ok\"}",
          "type": "json"
        }
      ]
    },
    "filename": "../paperless/controller/MeetingController.java",
    "groupTitle": "Meeting"
  },
  {
    "type": "POST",
    "url": "/addRole",
    "title": "addRole",
    "version": "1.0.0",
    "group": "RoleController",
    "name": "addRole",
    "parameter": {
      "fields": {
        "请求参数": [
          {
            "group": "请求参数",
            "type": "String",
            "optional": false,
            "field": "roleName",
            "description": ""
          }
        ]
      },
      "examples": [
        {
          "title": "请求参数示例",
          "content": "roleName=bnoWa",
          "type": "json"
        }
      ]
    },
    "success": {
      "fields": {
        "响应结果": [
          {
            "group": "响应结果",
            "type": "Number",
            "optional": false,
            "field": "code",
            "description": ""
          },
          {
            "group": "响应结果",
            "type": "String",
            "optional": false,
            "field": "message",
            "description": ""
          },
          {
            "group": "响应结果",
            "type": "Object",
            "optional": false,
            "field": "obj",
            "description": ""
          }
        ]
      },
      "examples": [
        {
          "title": "响应结果示例",
          "content": "{\"code\":6890,\"obj\":{},\"message\":\"50qP6Vo4\"}",
          "type": "json"
        }
      ]
    },
    "filename": "../paperless/controller/RoleController.java",
    "groupTitle": "RoleController"
  }
] });