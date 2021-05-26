using pm_client.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace pm_client.util
{
    class ViewUtil
    {
        public static void Ban(Control context,string name)
        {
            Control i = (Control)context.FindName(name);
            i.Visibility = System.Windows.Visibility.Hidden;
        }
        public static T Find<T>(Control context,string name)
        {
            return (T)context.FindResource(name);
        }
        public static void msg(string text)
        {
            DiyMessageBox.Show(text, DiyMessageBox.CustomMessageBoxButton.OK, DiyMessageBox.CustomMessageBoxIcon.None);
            //MessageBox.Show(text);
        }
    }
}
