using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace pm_client.util {
    public class HookManager {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool SetDllDirectory(string path);


        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string dllToLoad);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);

        [DllImport("kernel32.dll")]
        public static extern bool FreeLibrary(IntPtr hModule);

        private delegate void Func();
        Func startupHook;
        Func closeHook;
        static IntPtr pDll;

        public void StartupHook() {
            if (startupHook == null) {
                ViewUtil.msg("start up failed");
                return;
            }
            startupHook();
        }
        public void CloseHook() {
            if (startupHook == null) {
                ViewUtil.msg("ending failed");
                return;
            }
            closeHook();
        }


        public HookManager() {
            IntPtr pAddressOfFunctionToCall = GetProcAddress(pDll, "StartupHook");
            if (pAddressOfFunctionToCall == IntPtr.Zero) {
                ViewUtil.msg("hook failed");
                return;
            }
            startupHook = (Func)Marshal.GetDelegateForFunctionPointer(pAddressOfFunctionToCall, typeof(Func));
            pAddressOfFunctionToCall = GetProcAddress(pDll, "CloseHook");
            closeHook = (Func)Marshal.GetDelegateForFunctionPointer(pAddressOfFunctionToCall, typeof(Func));
        }

        public void test() {
            Process p = Process.GetProcessById(20);
            p.Kill();
        }

        static HookManager() {
            pDll = LoadLibrary(@".\lib\HookProc_x64.dll");
            if (pDll == IntPtr.Zero) {
                pDll = LoadLibrary(@".\lib\HookProc_x86.dll");
            }

            Console.WriteLine(pDll);
        }
        bool shouldKill(int pid) {
            return false;
        }

    }
}
