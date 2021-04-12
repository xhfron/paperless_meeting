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
    /// file_list_view.xam`l 的交互逻辑
    /// </summary>
    public partial class file_list_view : UserControl
    {
        public file_list_view()
        {
            InitializeComponent();
        }


        private void item1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //点击文件播放视频（测试）
            f_view.Children.Remove(f_sub_view);

            string path = AppDomain.CurrentDomain.BaseDirectory;
            string rootpath = path.Substring(0, path.LastIndexOf("bin"));
            string filepath = rootpath + "res\\drawable\\MP4Test.mp4";

            f_view.Children.Add(new file_video_view(filepath,f_view, f_sub_view));

        }


        private void item2_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //点击文件阅读PDF（测试）
            f_view.Children.Remove(f_sub_view);

            string path = AppDomain.CurrentDomain.BaseDirectory;
            string rootpath = path.Substring(0, path.LastIndexOf("bin"));
            string filePath = rootpath + "res\\drawable\\pdftest01.pdf";

            f_view.Children.Add(new file_pdf_view(filePath,f_view, f_sub_view));

        }



    }
}
