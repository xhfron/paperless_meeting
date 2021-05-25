define({ "api": [
  {
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "optional": false,
            "field": "varname1",
            "description": "<p>No type.</p>"
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "varname2",
            "description": "<p>With type.</p>"
          }
        ]
      }
    },
    "type": "",
    "url": "",
    "version": "0.0.0",
    "filename": "../src/main/java/doc/main.js",
    "group": "/mnt/d/study/projectTrain/paperless_meeting/server/src/main/java/doc/main.js",
    "groupTitle": "/mnt/d/study/projectTrain/paperless_meeting/server/src/main/java/doc/main.js",
    "name": ""
  },
  {
    "type": "GET",
    "url": "/file/download",
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
          "content": "{\n\"fileId\":\"209\"\n}",
          "type": "json"
        }
      ]
    },
    "filename": "../src/main/java/com/xhfron/paperless/controller/FileController.java",
    "groupTitle": "File"
  },
  {
    "type": "POST",
    "url": "/file/getFileList",
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
          "content": "{\"meetingId\":12, \"roleId\":1}",
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
          "content": "{\"code\":200,\"message\":\"ok\",\"obj\":[{\"name\":\"typora-setup-x64.exe\",\"address\":\"C:\\\\Files\\\\13\\\\typora-setup-x64.exe\"},\n{\"name\":\"VSCodeUserSetup-x64-1.51.1.exe\",\"address\":\"13\\\\VSCodeUserSetup-x64-1.51.1.exe\"}]}",
          "type": "json"
        }
      ]
    },
    "filename": "../src/main/java/com/xhfron/paperless/controller/FileController.java",
    "groupTitle": "File"
  },
  {
    "type": "POST",
    "url": "/host/beginMeeting",
    "title": "beginMeeting",
    "version": "1.0.0",
    "group": "Host",
    "name": "beginMeeting",
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "int",
            "optional": false,
            "field": "meetingId",
            "description": "<p>会议的id</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "{",
          "content": "{\n    \"meetingId\":3\n}",
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
          "content": "{\"code\":200,\"message\":\"ok\",\"obj\":null}",
          "type": "json"
        }
      ]
    },
    "filename": "../src/main/java/com/xhfron/paperless/controller/HostController.java",
    "groupTitle": "Host"
  },
  {
    "type": "POST",
    "url": "/host/beginVote",
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
          "content": "{\n\"voteId\":10231\n}",
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
          "content": "{\"code\":200,\"message\":\"ok\",\"obj\":{}}",
          "type": "json"
        }
      ]
    },
    "filename": "../src/main/java/com/xhfron/paperless/controller/HostController.java",
    "groupTitle": "Host"
  },
  {
    "type": "POST",
    "url": "/host/getVoteRes",
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
          "content": "{\"code\":200,\"message\":\"ok\",\"obj\":{\"voteId\":1,\"res\":[{\"optionId\":1,\"number\":1,\"devices\":[\"SDUPAD1（doge)\"]},{\"optionId\":2,\"number\":1,\"devices\":[\"SDUPAD1（doge)\"]},{\"optionId\":3,\"number\":0,\"devices\":[]}]}}",
          "type": "json"
        }
      ]
    },
    "filename": "../src/main/java/com/xhfron/paperless/controller/HostController.java",
    "groupTitle": "Host"
  },
  {
    "type": "POST",
    "url": "/host/programLimit",
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
          "content": "{\n\"mode\":1\n}",
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
          "content": "{\"code\":200,\"message\":\"ok\",\"obj\":{\"state\":\"open\"}}",
          "type": "json"
        }
      ]
    },
    "filename": "../src/main/java/com/xhfron/paperless/controller/HostController.java",
    "groupTitle": "Host"
  },
  {
    "type": "POST",
    "url": "/meeting/info",
    "title": "info",
    "version": "1.0.0",
    "group": "Meeting",
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
          "content": "{\n    \"meetingId\":1\n}",
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
          "content": "{\n    \"code\": 200,\n    \"message\": \"ok\",\n    \"obj\": {\n        \"meetingId\":1,\n        \"title\":\"会议名称\",\n        \"content\":\"会议简介\",\n        \"beginTime\":\"2021-08-08 22:00\",\n        \"endTime\":\"2021-08-08 22:00\",\n        \"deviceId\":1,\n        \"role\":{\n            \"id\":1,\n            \"name\":\"主持人\"\n        }\n    }\n\n}",
          "type": "json"
        }
      ]
    },
    "filename": "../src/main/java/com/xhfron/paperless/controller/MeetingController.java",
    "groupTitle": "Meeting"
  },
  {
    "type": "POST",
    "url": "/vote/getVoteList",
    "title": "getVoteList",
    "version": "1.0.0",
    "group": "Vote",
    "name": "getVoteList",
    "parameter": {
      "fields": {
        "请求参数": [
          {
            "group": "请求参数",
            "type": "Number",
            "optional": false,
            "field": "deviceId",
            "description": ""
          }
        ],
        "Parameter": [
          {
            "group": "Parameter",
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
          "content": "{\n\"deviceId\":1,\n\"meetingId\":2\n}",
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
          "content": "{\"code\":200,\"message\":\"ok\",\"obj\":{\n\"voteList\":[\n{\n{\n\"id\":2,\n\"name\":\"eat ot not\",\n\"content\":\"something about voting\",\n\"type\":1,\n\"anonymous\":1,\n\"meetingId\":23,\n\"options\":[{\"id\":2,\"content\":\"food\"},\n{\n\"id\":2,\n\"name\":\"eat ot not\",\n\"content\":\"something about voting\",\n\"type\":1,\n\"anonymous\":1,\n\"meetingId\":23,\n\"options\":[{\"id\":2,\"content\":\"food\"}\n}\n}}",
          "type": "json"
        }
      ]
    },
    "filename": "../src/main/java/com/xhfron/paperless/controller/VoteController.java",
    "groupTitle": "Vote"
  },
  {
    "type": "POST",
    "url": "/vote/submitOption",
    "title": "submitOption",
    "version": "1.0.0",
    "group": "Vote",
    "name": "submitOption",
    "parameter": {
      "fields": {
        "请求参数": [
          {
            "group": "请求参数",
            "type": "Number",
            "optional": false,
            "field": "voteId",
            "description": ""
          },
          {
            "group": "请求参数",
            "type": "Number",
            "optional": false,
            "field": "optionId",
            "description": ""
          },
          {
            "group": "请求参数",
            "type": "Number",
            "optional": false,
            "field": "deviceId",
            "description": ""
          }
        ]
      },
      "examples": [
        {
          "title": "请求参数示例",
          "content": "{\n\"optionId\":1,\n\"voteId\":4008,\n\"deviceId\":2\n}",
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
          "content": "{\"code\":200,\"message\":\"ok\",\"obj\":{}}",
          "type": "json"
        }
      ]
    },
    "filename": "../src/main/java/com/xhfron/paperless/controller/VoteController.java",
    "groupTitle": "Vote"
  }
] });