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
            ;
        }

        private void btnselection_Click(object sender, RoutedEventArgs e)
        {
            inkcanvas1.EditingMode = System.Windows.Controls.InkCanvasEditingMode.Select;
        }


    }
}
