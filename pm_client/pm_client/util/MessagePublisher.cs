using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pm_client.util {
    public class MessagePublisher {
        public const string CLOSE_MESSAGE = "close";

        static List<MessageSubscriber> subscribers = new List<MessageSubscriber>();
        static List<string> type = new List<string>();
        public static void publish(string message,string args) {
            for(int i = 0; i < subscribers.Count; i++) {
                if (type[i] == message) {
                    subscribers[i].onMessage(message, args);
                }
            }
        }
        public static void subscribe(MessageSubscriber subscriber,string message) {
            subscribers.Add(subscriber);
            type.Add(message);
        }
    }
    public interface MessageSubscriber {
        void onMessage(string message, string args);
    }
}
