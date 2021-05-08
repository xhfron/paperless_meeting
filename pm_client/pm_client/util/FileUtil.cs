using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pm_client.util {
    class FileUtil {
        public static FileInfo getFile(string filePath) {
            FileInfo res = new FileInfo(filePath);
            DirectoryInfo dir = new DirectoryInfo(filePath);
            if (!dir.Parent.Exists) {
                dir.Parent.Create();
            }
            if (!dir.Exists) {
                res.Create();
            }
            return res;
        }
    }
}
