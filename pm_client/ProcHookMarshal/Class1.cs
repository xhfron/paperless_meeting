using System;
using System.Runtime.InteropServices;

namespace ProcHookMarshal
{
    public class Hook
    {
        [DllImport("ProcHook.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void StartupHook();
        [DllImport("ProcHook.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void CloseHook();
    }
   
}
