using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pm_client.util {
    class ProcessManager {
        List<Process> list=new List<Process>();
        int mode;
        public static int GRANTED=1;
        public static int DENIED =2;
        public void setMode(int mode) {
            if (mode == GRANTED) {

            }else if (mode == DENIED) {
                foreach(Process process in list) {
                    process.Kill();
                }
            }
        }
        public void open(string filepath) {
            if (mode == GRANTED) {

            Process process = Process.Start(filepath);
            list.Add(process);
            process.Exited += (sender,e) => list.Remove(process);
            } else {
                ViewUtil.msg("点什么点");
            }
        }
        public void onProcessStart(string path,Process process) {
            if (shouldClose(path)) {
                process.Kill();
            }
        }
        public bool shouldClose(string path) {
            return !path.Contains(@"C:\Windows");
        }
    }
}
