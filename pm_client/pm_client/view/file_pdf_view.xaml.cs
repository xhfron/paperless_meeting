using Microsoft.Win32;
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
    /// file_pdf_view.xaml 的交互逻辑
    /// </summary>
    public partial class file_pdf_view : UserControl
    {

        string filePath;
        //Grid f_view;
        //Grid f_sub_view;

        private bool _isLoaded = false;

        public file_pdf_view(string filePath)
        {
            InitializeComponent();
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this)) return;
            this.filePath = filePath;



        }


        private void moonPdfPanel_Loaded(object sender, RoutedEventArgs e)
        {

            //打开PDF文件
            try
            {
                moonPdfPanel.OpenFile(filePath);
                _isLoaded = true;
            }
            catch (Exception exp)
            {
                _isLoaded = false;
                MessageBox.Show(exp.StackTrace.ToString());
            }


            //显示当前页数和总页数
            current_page_view.Text = moonPdfPanel.GetCurrentPageNumber().ToString();
            total_page_view.Text = moonPdfPanel.TotalPages.ToString();

        }



        private void moonPdfPanel_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {
            //滚动条滚动时改变当前页数
            current_page_view.Text = moonPdfPanel.GetCurrentPageNumber().ToString();
        }

        private void moonPdfPanel_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            //手指上下滑动时时改变当前页数
            current_page_view.Text = moonPdfPanel.GetCurrentPageNumber().ToString();
        }

        private void FirstButton_Click(object sender, RoutedEventArgs e)
        {
            //跳转到首页
            moonPdfPanel.GotoFirstPage();
            current_page_view.Text = moonPdfPanel.GetCurrentPageNumber().ToString();
        }

        private void LastButton_Click(object sender, RoutedEventArgs e)
        {
            //跳转到上一页
            moonPdfPanel.GotoPreviousPage();
            current_page_view.Text = moonPdfPanel.GetCurrentPageNumber().ToString();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            //跳转到下一页
            moonPdfPanel.GotoNextPage();
            current_page_view.Text = moonPdfPanel.GetCurrentPageNumber().ToString();
        }

        private void EndButton_Click(object sender, RoutedEventArgs e)
        {
            //跳转到末页
            moonPdfPanel.GotoLastPage();
            current_page_view.Text = moonPdfPanel.GetCurrentPageNumber().ToString();
        }
        double dist = 0.0;




        private void ZoomInButton_Click(object sender, RoutedEventArgs e)
        {
            if (_isLoaded)
            {
                moonPdfPanel.ZoomIn();
            }
        }

        private void ZoomOutButton_Click(object sender, RoutedEventArgs e)
        {
            if (_isLoaded)
            {
                moonPdfPanel.ZoomOut();
            }
        }

        private void NormalButton_Click(object sender, RoutedEventArgs e)
        {
            if (_isLoaded)
            {
                moonPdfPanel.Zoom(1.0);
            }
        }

        private void FitToHeightButton_Click(object sender, RoutedEventArgs e)
        {
            moonPdfPanel.ZoomToHeight();
        }

        private void FacingButton_Click(object sender, RoutedEventArgs e)
        {
            moonPdfPanel.ViewType = MoonPdfLib.ViewType.Facing;
        }

        private void SinglePageButton_Click(object sender, RoutedEventArgs e)
        {
            moonPdfPanel.ViewType = MoonPdfLib.ViewType.SinglePage;
        }


        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            //点击关闭按钮关闭PDF阅读器，返回文件列表
            //f_view.Children.Remove(this);
            //f_view.Children.Add(f_sub_view);
           
        }
        string name = "pdf";
        void say(string text) {
            //if (true) return;
            Log.l(name, text);
        }

        private void zoom(object sender, TouchEventArgs e) {
            if (true) return;
            TouchPointCollection collection = e.GetIntermediateTouchPoints(this);
            say("--------------------------start zoom");
            say($"collection len {collection.Count}");
            if (collection.Count <= 1) {
                say("count less");
                return;
            }

            TouchPoint pivot = collection[0];
            double maxDist = 0.0;
            TouchPoint maxP = pivot;

            say($"pivot:({pivot.Position.X},{pivot.Position.Y})");

            foreach(var x in collection) {
                double tempDist = 0.0;
                TouchPoint p1 =x, p2 = pivot;
                //say($"pick:({p1.Position.X},{p1.Position.Y})");
                double x1 = p1.Position.X, y1 = p1.Position.Y, x2 = p2.Position.X, y2 = p2.Position.Y;
                tempDist = (y1 - y2) * (y1 - y2) + (x1 - x2) * (x1 - x2);
                //say($"tempDist:{tempDist}");
                if (tempDist > maxDist) {
                    //say("updated");
                    maxDist = tempDist;
                    maxP = x;
                }
            }

            pivot = maxP;
            maxDist = 0.0;
            say($"pivot:({pivot.Position.X},{pivot.Position.Y})");

            foreach (var x in collection) {
                double tempDist = 0.0;
                TouchPoint p1 = x, p2 = pivot;
                double x1 = p1.Position.X, 
                    y1 = p1.Position.Y, 
                    x2 = p2.Position.X, 
                    y2 = p2.Position.Y;
                tempDist = (y1 - y2) * (y1 - y2) + (x1 - x2) * (x1 - x2);
                if (tempDist > maxDist) {
                    say($"with:({p2.Position.X},{p2.Position.Y})");
                    say($"pick:({p1.Position.X},{p1.Position.Y})");
                    say($"tempDist:{tempDist}");
                    say("updated");
                    maxDist = tempDist;
                    maxP = x;
                }
            }

            say("maxDist:" + maxDist);
            if (maxDist < 70*70) {
                say("single");
                return;
            }

            say("dist:" + dist);
            say("delta:" + (maxDist - dist));
            if (dist == 0) {
                dist = maxDist;
            } else {
                if (Math.Abs(maxDist - dist) > 50*50) {
                    double factor = Math.Sqrt(maxDist) - Math.Sqrt(dist);
                    factor = factor / 50*0.2 + moonPdfPanel.CurrentZoom;
                    moonPdfPanel.Zoom(factor);
                    say("::zoom");
                    dist = maxDist;
                }
            }

        }

        private void clear(object sender, TouchEventArgs e) {
            dist = 0;
            Log.l("pdf", "awjeifodsonicewoicndczkvljdfs");
        }


    }
class ZoomManager {
        void begin() {

        }
        void update(TouchPointCollection collection) {

        }
        void end() {

        }
        bool belong() {
            return false;
        }
    }
}
