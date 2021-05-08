using pm_client.util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebSocketSharp;

namespace Test
{
    class TCPClient {
        Socket s;
        byte[] buffer;
        TCPClient(string ip,int port) {
            s = new Socket(SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint p = new IPEndPoint(IPAddress.Parse(ip), port);
            s.Connect(p);
            buffer = new byte[1024];
        }
        void send(string text) {
            s.Send(Encoding.UTF8.GetBytes(text + "\n"));
        }
        string receive() {
            int n = s.Receive(buffer);
            return Encoding.UTF8.GetString(buffer,0, n);
        }
        void onMessage(string text) {
            System.Console.WriteLine(text);
        }

    }
    class STOMPClient {
        WebSocket webSocket;
        byte[] buffer;
        public async Task connectWs(string url) {
            Console.WriteLine("hihiho");
            webSocket = new WebSocket(url);
            webSocket.OnOpen += (send,e)=>Console.WriteLine("opened");
            webSocket.OnMessage += (send, e) => Console.WriteLine(e.IsPing ? "ping" : e.Data);
            webSocket.Connect();
            Console.WriteLine(new Uri(url));     //schtasks       
        }
        public async Task<string> receive() {
            return null;
        }
        public static string CONNECT = "CONNECT";
        public async Task connect() {
            webSocket.Send(CONNECT + "\naccept-version:1.1,1.0\nheart - beat:10000, 10000\n\n"+'\0');
            Console.WriteLine("sent");
        }
        public static string SEND = "SEND";
        public async Task send(string txt,string dest= "/topic/cmd") {
            webSocket.Send($"{SEND}\ndestination:{dest}\n\n{txt}\n" + '\0');
        }

        public static string SUBSCRIBE = "SUBSCRIBE";
        public async Task subscribe(string dest,string id="default") {
            webSocket.Send($"{SUBSCRIBE}\nid:{id}\ndestination:{dest}\n\n" + '\0');
        }
        public static string UNSUBSCRIBE = "UNSUBSCRIBE";
        public async Task unsubscribe(string id="default") {
            webSocket.Send($"{UNSUBSCRIBE}\nid:{id}\n\n" + '\0');
        }
        public static string BEGIN = "BEGIN";
        public async Task begin() {
        }
        public static string COMMIT = "COMMIT";
        public async Task commit() {
        }
        public static string ABORT = "ABORT";
        public async Task abort() {
        }
        public static string ACK = "ACK";
        public async Task ack() {
        }
        public static string NACK = "NACK";
        public async Task nack() {
        }
        public static string DISCONNECT = "DISCONNECT";
        public async Task disconnect(string id="0") {
            webSocket.Send($"{DISCONNECT}\nreceipt:{id}\n\n" + '\0');
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            if (true) {
                

                STOMPClient c = new STOMPClient();
                Console.WriteLine("oooooo");
                Task.Run(async () => {
                    Console.WriteLine("hi");
                    //await c.connectWs("ws://echo.websocket.org");
                    await c.connectWs("ws://paperless.ronwhite.online:10087/websocket");
                    Console.WriteLine("ha");
                    await c.connect();
                    Console.WriteLine("oh");
                    await c.subscribe("/topic/cmd");
                    Console.WriteLine("xxx");
                    await c.send("saaa");
                    Console.WriteLine(await c.receive());
                    });
                Console.ReadKey();
                return;
            }
            if (true) {
                Process p = Process.GetProcessById(4200);
                Console.WriteLine(p.MainModule.FileName);
                p.Kill();
                return;
            }
            if (true)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://paperless.ronwhite.online:10087/meeting/");
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
        Dictionary<string,string> post(Dictionary<string,string> reqJson)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://paperless.ronwhite.online:10087/meeting/");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();

            myStreamReader.Close();
            myResponseStream.Close();
            Console.WriteLine(retString);
            return null ;
        }
    }
}
