using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pm_client.util
{
    class NetworkException:Exception
    {
        public int code;
        public string message;
        public NetworkException(int code,string message) {
            this.code = code;
            this.message = message;
        }
    }
}
