using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pm_client.util
{
    class Settings
    {
        public static string protocol="http";
        public static string domain= "paperless.ronwhite.online";
        public static string fileDir = @".\tfile";
        public static string tempDir = @".\temp";
        public static int port = 10087;
        public static bool debug = true;
        public static string remoteFilePath = @".\rfile";
    }
    class RConst {
        public static string STOMPClient = "STOMPClient";
        public static string meeting = "meeting";

    }
}
