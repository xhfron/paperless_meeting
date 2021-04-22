using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace pm_client.util
{
    public class ProcessManager
    {
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

        public void StartupHook()
        {
            startupHook();
        }
        public void CloseHook()
        {
            closeHook();
        }


        public ProcessManager()
        {
            IntPtr pAddressOfFunctionToCall = GetProcAddress(pDll, "StartupHook");
            startupHook = (Func)Marshal.GetDelegateForFunctionPointer(pAddressOfFunctionToCall, typeof(Func));
            pAddressOfFunctionToCall = GetProcAddress(pDll, "CloseHook");
            closeHook = (Func)Marshal.GetDelegateForFunctionPointer(pAddressOfFunctionToCall, typeof(Func));
        }
        public void test() {
            Process p=Process.GetProcessById(20);
            p.Kill();
        }

        static ProcessManager()
        {
            pDll = LoadLibrary(@".\HookProc.dll");
            Console.WriteLine(pDll);
        }
    }
}
