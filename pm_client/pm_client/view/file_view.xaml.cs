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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pm_client.view
{
    /// <summary>
    /// file_list_view.xaml 的交互逻辑
    /// </summary>
    public partial class file_list_view : UserControl
    {
        private RotateTransform rt_FanRotate = new RotateTransform();   //做旋转动
        private DoubleAnimation da_FanRotate = new DoubleAnimation();   //数值类型
        private Storyboard sb_FanRotate = new Storyboard();             //故事板
        public file_list_view()
        {
            InitializeComponent();
        }
    }
}
