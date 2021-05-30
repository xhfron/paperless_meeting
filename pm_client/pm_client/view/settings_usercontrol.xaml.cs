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

namespace pm_client.view {
    /// <summary>
    /// logout.xaml 的交互逻辑
    /// </summary>
    public partial class logout : UserControl,MessageListener {
        public logout() {
            InitializeComponent();
            if (ViewUtil.Find<Role>(this, "role").name.Contains("主持人")) {

            } else {
                closeBtn.Visibility = Visibility.Hidden;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            try {
                Button btn = e.OriginalSource as Button;
                if (btn.Name == "delete") {
                    //删除一个数字
                    txtValue.Text = txtValue.Text.Substring(0, txtValue.Text.Length - 1);
                } else if (btn.Name == "sure") {
                    //点击确定隐藏数字键盘
                    number_keyboard.Visibility = Visibility.Hidden;
                } else {
                    //键入数字
                    txtValue.Text += btn.Content;
                }
            } catch {
            }
        }


        private void TextBox_GetFocus(object sender, RoutedEventArgs e) {
            //文本框获得焦点弹出键盘(使键盘可见)
            number_keyboard.Visibility = Visibility.Visible;

        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e) {
            //文本框失去焦点隐藏键盘(使键盘不可见)
            //number_keyboard.Visibility = Visibility.Hidden;

        }



        private void exit(object sender, RoutedEventArgs e) {
            MessagePublisher.publish(MessagePublisher.CLOSE_MESSAGE, "");
            Task.Run(() => System.Environment.Exit(0));
        }
        private void close(object sender, RoutedEventArgs e) {
            Task.Run(() => {
                WebUtil.closeMeeting(ViewUtil.Find<Meeting>(this, "meeting").uid);
                //System.Environment.Exit(0);
            });
        }

        public void onMessage(Dictionary<string, object> json) {
            string cmd = (string)json["cmd"];
            if (cmd.Contains("结束会议")) {
                exit(null, null);
            }
        }
    }

}
