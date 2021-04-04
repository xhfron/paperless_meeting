using pm_client.util;
using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.Title="pm_client";
            ProcessManager m=new ProcessManager();
            m.StartupHook();
            m.CloseHook();
        }
    }
}
