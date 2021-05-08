using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;

namespace pm_client.util {
    interface MessageListener {
        void onMessage(Dictionary<string,object> json);
        
    }
    class MsgBuilder {
        int start;
        int end;
        string raw;
        void next() {
            start = end + 1;
            end= raw.IndexOf("\n", start) == -1 ? raw.Length : raw.IndexOf("\n", start);
        }
        string get() {
            return raw.Substring(start, start - end);
        }
        string build(string raw) {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            string msg = null;
            this.raw = raw;
            start = 0;
            end = raw.IndexOf("\n", start) == -1 ? raw.Length : raw.IndexOf("\n", start);
            if (get().ToLower() != "message") {
                return null;
            }
            next();
            while (get() != "") {
                int delim = get().IndexOf(":");
                dict[get().Substring(0, delim - 0)] = get().Substring(delim + 1, get().Length - delim - 1);
                next();
            }
            next();
            end = raw.IndexOf('\0');
            msg = raw.Substring(start, end - start);
            return msg;
        }
        public Dictionary<string,object> asDict(string raw) {
            return JsonConvert.DeserializeObject<Dictionary<string,object>>(build(raw));
        }
    }
    class STOMPClient {
        WebSocket webSocket;
        byte[] buffer;
        List<MessageListener> listeners = new List<MessageListener>();
        public void addJsonListener(MessageListener listener) {
            listeners.Add(listener);
        }
        public async Task connectWs(string url) {
            Console.WriteLine("hihiho");
            webSocket = new WebSocket(url);
            webSocket.OnOpen += (send, e) => Console.WriteLine("opened");
            webSocket.OnMessage += (send, e) => Console.WriteLine(e.IsPing ? "ping" : e.Data);
            webSocket.OnMessage += (send, e) => {
                if (e.IsPing) {
                    return;
                }
                MsgBuilder builder = new MsgBuilder();
                Dictionary<string, object> dict = builder.asDict(e.Data);
                foreach(var l in listeners) {
                    l.onMessage(dict);
                }
            };
            webSocket.Connect();
            Console.WriteLine(new Uri(url));     //schtasks       
        }
        public async Task<string> receive() {
            return null;
        }
        public static string CONNECT = "CONNECT";
        public async Task connect() {
            webSocket.Send(CONNECT + "\naccept-version:1.1,1.0\nheart - beat:10000, 10000\n\n" + '\0');
            Console.WriteLine("sent");
        }
        public static string SEND = "SEND";
        public async Task send(string txt, string dest = "/topic/cmd") {
            webSocket.Send($"{SEND}\ndestination:{dest}\n\n{txt}\n" + '\0');
        }

        public static string SUBSCRIBE = "SUBSCRIBE";
        public async Task subscribe(string dest, string id = "default") {
            webSocket.Send($"{SUBSCRIBE}\nid:{id}\ndestination:{dest}\n\n" + '\0');
        }
        public static string UNSUBSCRIBE = "UNSUBSCRIBE";
        public async Task unsubscribe(string id = "default") {
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
        public async Task disconnect(string id = "0") {
            webSocket.Send($"{DISCONNECT}\nreceipt:{id}\n\n" + '\0');
        }
    }
}
