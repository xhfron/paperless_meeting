﻿using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Test {
    public class HookManager {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool SetDllDirectory(string path);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetLastError();


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
                Console.WriteLine("start up failed");
                return;
            }
            startupHook();
        }
        public void CloseHook() {
            if (startupHook == null) {
                Console.WriteLine("ending failed");
                return;
            }
            closeHook();
        }


        public HookManager() {
            IntPtr pAddressOfFunctionToCall = GetProcAddress(pDll, "StartupHook");
            startupHook = (Func)Marshal.GetDelegateForFunctionPointer(pAddressOfFunctionToCall, typeof(Func));
            
            Console.WriteLine($"start up handle:{startupHook.ToString()}");
            
            pAddressOfFunctionToCall = GetProcAddress(pDll, "CloseHook");
            closeHook = (Func)Marshal.GetDelegateForFunctionPointer(pAddressOfFunctionToCall, typeof(Func));
        }


        static HookManager() {
            //if (!SetDllDirectory(@".\lib")) {
            //  Console.WriteLine("false");
            //}
            FileInfo file=new FileInfo(@".\lib\HookProc.dll");
            
            pDll = LoadLibrary(file.FullName);
            if (pDll == IntPtr.Zero) {
                Console.WriteLine(file.FullName+"::hook failed:" + GetLastError());
                return;
            }
            Console.WriteLine($"dll handle:{pDll}");
        }
        bool shouldKill(int pid) {
            return false;
        }

    }
    class Program
    {
        
        static void Main(string[] args)
        {
            if (true) {
                HookManager hookManager = new HookManager();
                hookManager.StartupHook();
                hookManager.CloseHook();
                return;
            }
        }
    }
}
