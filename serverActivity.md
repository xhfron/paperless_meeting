```flow
st=>start: 开始会议
i=>inputoutput: 输入会议title time 
fileinput=>inputoutput: 导入文件
votesetting=>condition: 是否加入投票
voteinput=>inputoutput: 输入投票信息
rolesetting=>operation: 指定权限信息
roleAdd=>condition: 是否修改角色、
e=>end: 会议创建成功
st->i->fileinput->votesetting
votesetting(yes)->voteinput
votesetting(no)->rolesetting
voteinput->rolesetting
rolesetting->e
```