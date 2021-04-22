using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using pm_client.view;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            return JsonConvert.SerializeObject(j["obj"]);
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
        public static string url(string path)
        {
            return string.Format("{0}://{1}:{2}{3}", Settings.protocol, Settings.domain, Settings.port, path);
        }
    }
}
