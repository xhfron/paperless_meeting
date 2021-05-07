using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace pm_client.view
{
    /// <summary>
    /// Log.xaml 的交互逻辑
    /// </summary>
    public partial class Log : Window
    {
        public static Dispatcher fuckingCSharp;
        static Log log;
        public static void say(string type,string name,string text)
        {
            fuckingCSharp.Invoke(() =>
            {

                if (log == null)
                {
                    log = new Log();
                    log.Show();
                }

                TextBox echo = (TextBox)log.FindName("echo");
                echo.AppendText(type + "[" + name + "]" + text);
                echo.AppendText("\n");
            });
        }
        public static void i(string name, string text)
        {
            say("[info]", name, text);
        }
        public static void l(string name, string text)
        {
            say("[loop]",name, text);
        }
        public static void l(string name, string tip,string text)
        {
            say("[loop]", name, $"[{tip}]"+text);
        }
        public static void i(string name,object obj)
        {
            if (obj == null)
            {
                i(name, "null");
            }
            else
            {
                i(name,obj.GetType().ToString());
                i(name,obj.ToString());
            }
        }

        public Log()
        {
            InitializeComponent();
        }
    }
}
