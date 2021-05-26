﻿using Newtonsoft.Json;
using pm_client.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pm_client.view
{
    /// <summary>
    /// SuperSplash.xaml 的交互逻辑
    /// </summary>
    public partial class SuperSplash : UserControl
    {
        public SuperSplash(){
            InitializeComponent();
        }
        string name = "SuperSplash";
        
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewUtil.Find<Meeting>(this,"meeting").load(getMeeting(1, 1));
            this.Visibility = Visibility.Collapsed;
        }
        Meeting getMeeting(int id, int deviceId)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict["meetingId"] = id;
            dict["deviceId"] = deviceId;
            string s = WebUtil.post("/meeting/info", dict);
            //Log.i("hi", JsonConvert.DeserializeObject(s));
            return JsonConvert.DeserializeObject<Meeting>(s);
        }
    }
}
