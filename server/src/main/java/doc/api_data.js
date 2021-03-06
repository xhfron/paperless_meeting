define({ "api": [
  {
    "type": "POST",
    "url": "/download",
    "title": "downloadFile",
    "version": "1.0.0",
    "group": "File",
    "name": "downloadFile",
    "description": "<p>文件下载</p>",
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "Number",
            "optional": false,
            "field": "fileId",
            "description": ""
          }
        ]
      },
      "examples": [
        {
          "title": "请求参数示例",
          "content": "body:{\n    \"fileId\":\"209\"\n}",
          "type": "json"
        }
      ]
    },
    "filename": "../paperless/controller/FileController.java",
    "groupTitle": "File"
  },
  {
    "type": "POST",
    "url": "/getFileList",
    "title": "getFileList",
    "version": "1.0.0",
    "group": "File",
    "name": "getFileList",
    "description": "<p>根据会议和角色获取文件列表</p>",
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "Number",
            "optional": false,
            "field": "meetingId",
            "description": ""
          },
          {
            "group": "Parameter",
            "type": "Number",
            "optional": false,
            "field": "roleId",
            "description": ""
          }
        ]
      },
      "examples": [
        {
          "title": "请求参数示例",
          "content": "{“meetingId\":12, \"roleId\":1}",
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
          "content": "{\"code\":200,\"obj\":{\"fileList\":[{\"id\":1,\"name\":\"1.pdf\",\"address\":\"meeting1/1.pdf\"}]},\"message\":\"ok\"}",
          "type": "json"
        }
      ]
    },
    "filename": "../paperless/controller/FileController.java",
    "groupTitle": "File"
  },
  {
    "type": "POST",
    "url": "/beginMeeting",
    "title": "beginMeeting",
    "version": "1.0.0",
    "group": "Host",
    "name": "beginMeeting",
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
          "content": "{\"code\":200,\"message\":\"ok\",\"obj\":{},}",
          "type": "json"
        }
      ]
    },
    "filename": "../paperless/controller/HostController.java",
    "groupTitle": "Host"
  },
  {
    "type": "POST",
    "url": "/beginVote",
    "title": "beginVote",
    "version": "1.0.0",
    "group": "Host",
    "name": "beginVote",
    "parameter": {
      "fields": {
        "请求参数": [
          {
            "group": "请求参数",
            "type": "Number",
            "optional": false,
            "field": "voteId",
            "description": ""
          }
        ]
      },
      "examples": [
        {
          "title": "请求参数示例",
          "content": "body:{\n\"voteId\":10231\n}",
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
          "content": "{\"code\":200,\"message\":\"ok\",\"obj\":{},}",
          "type": "json"
        }
      ]
    },
    "filename": "../paperless/controller/HostController.java",
    "groupTitle": "Host"
  },
  {
    "type": "POST",
    "url": "/getVoteRes",
    "title": "getVoteRes",
    "version": "1.0.0",
    "group": "Host",
    "name": "getVoteRes",
    "parameter": {
      "fields": {
        "请求参数": [
          {
            "group": "请求参数",
            "type": "Number",
            "optional": false,
            "field": "voteId",
            "description": ""
          }
        ]
      },
      "examples": [
        {
          "title": "请求参数示例",
          "content": "{\"voteId\":200}",
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
          "content": "{\"code\":200,\"message\":\"ok\",\"obj\":{\n\"voteId\":2,\n\"res\" : [\n{\"opinionId\":1,\n\"number\":2,\n\"devices\":[\"deviceName\":\"sdu1\"]}\n},}",
          "type": "json"
        }
      ]
    },
    "filename": "../paperless/controller/HostController.java",
    "groupTitle": "Host"
  },
  {
    "type": "POST",
    "url": "/programLimit",
    "title": "programLimit",
    "version": "1.0.0",
    "group": "Host",
    "name": "programLimit",
    "parameter": {
      "fields": {
        "请求参数": [
          {
            "group": "请求参数",
            "type": "Number",
            "optional": false,
            "field": "mode",
            "description": ""
          }
        ]
      },
      "examples": [
        {
          "title": "请求参数示例",
          "content": "{\n\"mode\":1,\n}",
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
          "content": "{\"code\":200,\"message\":\"ok\",\"obj\":{\"state\":\"open\"},}",
          "type": "json"
        }
      ]
    },
    "filename": "../paperless/controller/HostController.java",
    "groupTitle": "Host"
  },
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
  }
] });
