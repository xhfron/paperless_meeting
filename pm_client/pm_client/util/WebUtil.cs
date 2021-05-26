using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using pm_client.view;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace pm_client.util
{
    class WebUtil
    {
        static string name = "WebUtil";
        
        public static string post(string rootPath,Dictionary<string,object> jsonRequest)
        {
            string url = WebUtil.url(rootPath);
            Dictionary<string, object> dict = jsonRequest;
            Log.l(name, "post");
            Log.l(name, "url", url);
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AlwaysMultipartFormData = true;
            foreach (string key in dict.Keys) {
                request.AddParameter(key, dict[key]);
                Log.l(name, "param", $"{key}:{dict[key]}");
            }
            var response = client.Post(request);
            Log.l(name, "status", response.StatusCode.ToString());
            string res = response.Content;
            Log.l(name, "res", res);
            JObject j = (JObject)JsonConvert.DeserializeObject(res);
            if ((int)j["code"]!= 200) {
                throw new NetworkException((int)j["code"], (string)j["message"]);
            }
            return JsonConvert.SerializeObject(j["obj"]);
        }
        public static Meeting getMeeting(int id, int deviceId) {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict["meetingId"] = id;
            dict["deviceId"] = deviceId;
            string s = WebUtil.post("/meeting/info", dict);
            //Log.i("hi", JsonConvert.DeserializeObject(s));
            return JsonConvert.DeserializeObject<Meeting>(s);
        }
        public static void downloadFile(int id,string localName)
        {
            var client = new RestClient(url("/file/download"));
            var request = new RestRequest();
            request.AddParameter("fileId", id);
            byte[] data =client.DownloadData(request);
            
            FileStream f = new FileStream(Path.Combine(Settings.fileDir,localName),FileMode.OpenOrCreate);
            BinaryWriter binaryWriter = new BinaryWriter(f);
            binaryWriter.Write(data);
        }
        public static void remoteSwitch(int mode) {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict["mode"] = mode;
            WebUtil.post("/host/programLimit", dict);
        }
        public static int latestMeetingId() {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            string res=WebUtil.post("/meeting/latestId", dict);
            return JsonConvert.DeserializeObject<int>(res);
        }
        public static void closeMeeting(int meetingId) {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict["meetingId"] = meetingId;
            string res = WebUtil.post("/host/closeMeeting", dict);
        }

        public static int getDeviceId() {
            string macAddr = null;
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc2 = mc.GetInstances();
            foreach (ManagementObject mo in moc2) {
                if (Convert.ToBoolean(mo["IPEnabled"]) == true) {
                    macAddr = mo["MacAddress"].ToString();
                    //macAddr = macAddr.Replace(':', '-');
                }
                mo.Dispose();
            }

            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict["mac"] = macAddr;
            string res = WebUtil.post("/meeting/getDeviceId", dict);
            return JsonConvert.DeserializeObject<int>(res);
        }
        public static void closeVote(int voteId) {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict["voteId"] = voteId;
            WebUtil.post("/host/closeVote", dict);
        }
        public static VoteResultCollection getVoteResult(int voteId) {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict["voteId"] = voteId;
            string str = WebUtil.post("/host/getVoteRes", dict);
            return JsonConvert.DeserializeObject<VoteResultCollection>(str);
        }
        public static List<util.Vote> getVoteList(int meetingId, int deviceId) {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict["meetingId"] = meetingId;
            dict["deviceId"] = deviceId;
            string str = WebUtil.post("/vote/getVoteList", dict);
            List<util.Vote> list = JsonConvert.DeserializeObject<List<util.Vote>>(str);
            foreach (Vote vote in list) {
                VoteResultCollection collection = getVoteResult(vote.uid);
                vote.state = collection.state;
            }
            return list;
        }
        public static int getMeetingState(int id) {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict["meetingId"] = id;
            string s = WebUtil.post("/meeting/state", dict);
            //Log.i("hi", JsonConvert.DeserializeObject(s));
            return JsonConvert.DeserializeObject<int>(s);
        }

        public static string url(string path)
        {
            return string.Format("{0}://{1}:{2}{3}", Settings.protocol, Settings.domain, Settings.port, path);
        }
    }
}
