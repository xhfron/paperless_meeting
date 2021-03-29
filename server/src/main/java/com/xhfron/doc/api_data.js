define({ "api": [
  {
    "type": "POST",
    "url": "/info",
    "title": "info",
    "version": "1.0.0",
    "group": "MeetingController",
    "name": "info",
    "parameter": {
      "fields": {
        "请求参数": [
          {
            "group": "请求参数",
            "type": "Number",
            "optional": false,
            "field": "meetingId",
            "description": ""
          }
        ]
      },
      "examples": [
        {
          "title": "请求参数示例",
          "content": "meetingId=5692",
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
          "content": "{\"code\":8595,\"obj\":{},\"message\":\"Qv5k7ji58i\"}",
          "type": "json"
        }
      ]
    },
    "filename": "../paperless/controller/MeetingController.java",
    "groupTitle": "MeetingController"
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
