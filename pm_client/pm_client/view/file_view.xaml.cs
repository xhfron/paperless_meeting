using pm_client.util;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// file_list_view.xam`l 的交互逻辑
    /// </summary>
    public partial class file_list_view : UserControl
    {
        INavigator board;
        public void AddBoard(INavigator board)
        {
            this.board = board;
        }
        public file_list_view()
        {
            InitializeComponent();

            DirectoryInfo d=new DirectoryInfo(Settings.fileDir);
            List<util.File> list = new List<util.File>();
            foreach(FileInfo dir in d.GetFiles())
            {
                util.File f = new util.File();
                f.name = dir.Name;
                list.Add(f);
            }
            this.file_list.ItemsSource = list;

            Log.i("file", "" + list.Count);
        }
        void open(string name)
        {
            string path = System.IO.Path.Combine(Settings.fileDir, name);
            if (name.EndsWith(".pdf"))
            {
                board.Push(new file_pdf_view(path));
            }
            else
            {
                ViewUtil.msg("unknown format");
            }
        }

        /*
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
        */
        private void UserControl_Loaded(object sender, RoutedEventArgs re)
        {
            Image e = (Image)this.FindName("loading_img");
            RotateTransform rotateTransform = new RotateTransform();
            rotateTransform.CenterX = this.loading_img.Width/2;
            rotateTransform.CenterY = this.loading_img.Height/2;
            DoubleAnimation ani = new DoubleAnimation();
            ani.From = 0;
            ani.To = 720;
            ani.RepeatBehavior = RepeatBehavior.Forever;
            ani.Duration = TimeSpan.FromSeconds(10);
            e.RenderTransform = rotateTransform;
            rotateTransform.BeginAnimation(RotateTransform.AngleProperty, ani);
        }
    }
}
