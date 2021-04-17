using pm_client.util;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            if (true)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.baidu.com");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();
                Console.WriteLine(retString);
                return;
            }
            Console.WriteLine("Hello World!");
            Console.Title="pm_client";
            ProcessManager m=new ProcessManager();
            m.StartupHook();
            m.CloseHook();
        }
    }
}
