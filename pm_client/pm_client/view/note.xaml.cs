using LinqToDB.Data;
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
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pm_client.view
{
    /// <summary>
    /// note.xaml 的交互逻辑
    /// </summary>
    public partial class note : UserControl
    {
        public note()
        {
            InitializeComponent();
        }



        private void btnerase_Click(object sender, RoutedEventArgs e)
        {
            inkcanvas1.EditingMode = System.Windows.Controls.InkCanvasEditingMode.EraseByStroke;
        }

        private void rectred_MouseDown(object sender, MouseButtonEventArgs e)
        {
            inkcanvas1.DefaultDrawingAttributes.Color = System.Windows.Media.Colors.Red;
        }

        private void btndraw_Click(object sender, RoutedEventArgs e)
        {
            inkcanvas1.EditingMode = System.Windows.Controls.InkCanvasEditingMode.Ink;
        }

        private void rectgreen_MouseDown(object sender, MouseButtonEventArgs e)
        {
            inkcanvas1.DefaultDrawingAttributes.Color = System.Windows.Media.Colors.Green;
        }

        private void rectblue_MouseDown(object sender, MouseButtonEventArgs e)
        {
            inkcanvas1.DefaultDrawingAttributes.Color = System.Windows.Media.Colors.Blue;
        }

        private void rectyellow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            inkcanvas1.DefaultDrawingAttributes.Color = System.Windows.Media.Colors.Yellow;           
        }

        private void btnselection_Click(object sender, RoutedEventArgs e)
        {
            inkcanvas1.EditingMode = System.Windows.Controls.InkCanvasEditingMode.Select;
        }

        private void btnsave_Click(object sender, RoutedEventArgs e)
        {

            //点击保存按钮保存笔迹

            //string inkFileName = "C:\\Users\\Lenovo\\Desktop\\inkrecord02";

            string path = AppDomain.CurrentDomain.BaseDirectory;
            string rootpath = path.Substring(0, path.LastIndexOf("bin"));
            string timeNumber = DateTime.Now.ToString().Replace(" ", "").Replace(@"/", "").Replace(":", "");
            string inkFileName = rootpath+"res\\drawable\\inkrecord"+ timeNumber;

            
            var fs = new FileStream(inkFileName, FileMode.Create);
            inkcanvas1.Strokes.Save(fs);

            MessageBox.Show("保存成功");

            /*
            //打开保存的笔迹
            var fs = new FileStream(inkFileName,FileMode.Open, FileAccess.Read);
            StrokeCollection strokes = new StrokeCollection(fs);
            inkcanvas1.Strokes = strokes;
             */


        }

        private void rectblack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            inkcanvas1.DefaultDrawingAttributes.Color = System.Windows.Media.Colors.Black;
        }
    }
}
