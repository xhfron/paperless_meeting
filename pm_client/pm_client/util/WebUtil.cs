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
            if (true)
            {
                string res = post_(url(rootPath), jsonRequest);
                JObject j = (JObject)JsonConvert.DeserializeObject(res);
                return JsonConvert.SerializeObject(j["obj"]);
            }
            try {
                HttpClient c;
                Log.l("post", "url:" + url(rootPath));
                string reqString = JsonConvert.SerializeObject(jsonRequest);
                reqString = "";
                foreach(string key in jsonRequest.Keys)
                {
                    reqString += key + "=" + jsonRequest[key] + "&";
                }
                reqString = reqString.Substring(0, reqString.Length - 1);
                Log.l("post", "req:" + reqString);
                
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url(rootPath));
                request.Method = "POST";
                //request.ContentType = "application/json";
                request.ContentType = "multipart/form-data,boundary=--xhfnbaaaaaaaa";
                Log.i(name, "" + Encoding.UTF8.GetByteCount(reqString));
                request.ContentLength = Encoding.UTF8.GetByteCount(reqString);

                Stream myRequestStream = request.GetRequestStream();
                StreamWriter streamWriter = new StreamWriter(myRequestStream, Encoding.UTF8);
                streamWriter.Write(reqString);
                streamWriter.Flush();
                streamWriter.Close();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    Log.l(name, "failed:" + response.StatusCode);
                }
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                string retString = myStreamReader.ReadToEnd();

                myStreamReader.Close();
                myResponseStream.Close();
                return retString;
            } catch(Exception e)
            {
                throw e;
                Log.i(name, "f");
                return "hello";
            }


        }
        public static string post_(string url,Dictionary<string,object> dict)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AlwaysMultipartFormData = true;
            foreach(string key in dict.Keys)
            {
                request.AddParameter(key, dict[key]);
            }
            Log.i("new post", request);
            var response = client.Post(request);
            Log.i("new post", response.StatusCode.ToString());
            string res = response.Content;
            Log.i("new post", response.Content);
            return res;
        }
        public static void downloadFile(int id,string localName)
        {
            var client = new RestClient(url("/file/download"));
            var request = new RestRequest();
            request.AddParameter("fileId", id);
            byte[] data =client.DownloadData(request);
            /*
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict["fileId"] = id;
            string reqString = JsonConvert.SerializeObject(dict);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url("/file/download"));
            request.Timeout = 3000;
            Log.l(name, reqString);
            request.Method = "GET";
            request.ContentType = "application/json";
            Log.i(name, "" + Encoding.UTF8.GetByteCount(reqString));
            request.ContentLength = Encoding.UTF8.GetByteCount(reqString);

            Stream myRequestStream = request.GetRequestStream();
            StreamWriter streamWriter = new StreamWriter(myRequestStream, Encoding.UTF8);
            streamWriter.Write(reqString);
            streamWriter.Flush();
            streamWriter.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode != HttpStatusCode.OK)
            {
                Log.l(name, "failed:" + response.StatusCode);
            }
            Stream myResponseStream = response.GetResponseStream();
            BinaryReader binaryReader = new BinaryReader(myResponseStream);
            byte[] data = binaryReader.ReadBytes(0);
            
            binaryReader.Close();
            myResponseStream.Close();
            */
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
