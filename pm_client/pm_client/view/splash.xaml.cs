using pm_client.util;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pm_client.view
{
    /// <summary>
    /// splash.xaml 的交互逻辑
    /// </summary>
    public partial class splash : UserControl,MessageListener
    {
        public splash() {
            InitializeComponent();
            
            characterize();
        }
        void beginMeeting(int meetingId) {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict["meetingId"] = meetingId;
            WebUtil.post("/host/beginMeeting", dict);
        }

        private void hide(object sender, RoutedEventArgs e)
        {
            Meeting meeting = ViewUtil.Find<Meeting>(this, "meeting");
            beginMeeting(meeting.uid);
            this.Visibility = Visibility.Collapsed;
        }
        private void characterize() {
            
            if (ViewUtil.Find<Role>(this,"role").name == "主持人") {

            } else {
                this.beginMeetingBtn.Visibility = Visibility.Collapsed;
                
            }
        }

        public void onMessage(Dictionary<string, object> json) {
            string cmd = json["cmd"] as string;
            Log.l("splash", cmd);
            if (cmd.StartsWith("开始会议")) {
                this.Dispatcher.InvokeAsync(() => this.Visibility = Visibility.Collapsed);
            }
        }

        private void UserControl_Initialized(object sender, EventArgs e) {
            
        }
    }
}
