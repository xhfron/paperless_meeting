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
using System.Windows.Shapes;

namespace pm_client.view
{


    public partial class DiyMessageBox : Window
    {

        //显示按钮类型
        public enum CustomMessageBoxButton
        {
            OK = 0,
            OKCancel = 1,
            YesNo = 2,
            YesNoCancel = 3
        }

        //消息框的返回值
        public enum CustomMessageBoxResult
        {
            //用户直接关闭了消息窗口
            None = 0,
            //用户点击确定按钮
            OK = 1,
            //用户点击取消按钮
            Cancel = 2,
            //用户点击是按钮
            Yes = 3,
            //用户点击否按钮
            No = 4
        }
        
        //图标类型
        public enum CustomMessageBoxIcon
        {
            None = 0,              //无图标
            Error = 1,              //错误
            Question = 2,              //询问
            Warning = 3,              //警告
            Tips = 4,              //提示
            Success = 5              //成功
        }


        #region Filed

        //显示的内容
        public string MessageBoxText { get; set; }
        
        //显示的图片
        public string ImagePath { get; set; }


        //控制显示 OK 按钮
        public Visibility OkButtonVisibility { get; set; }

        //控制显示 Cacncel 按钮
        public Visibility CancelButtonVisibility { get; set; }

        //控制显示 Yes 按钮
        public Visibility YesButtonVisibility { get; set; }

        //控制显示 No 按钮
        public Visibility NoButtonVisibility { get; set; }

        //消息框的返回值
        public CustomMessageBoxResult Result { get; set; }

        #endregion


        public DiyMessageBox()
        {

            InitializeComponent();
            this.DataContext = this;

            OkButtonVisibility = Visibility.Collapsed;
            CancelButtonVisibility = Visibility.Collapsed;
            YesButtonVisibility = Visibility.Collapsed;
            NoButtonVisibility = Visibility.Collapsed;

            Result = CustomMessageBoxResult.None;

        }


        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Result = CustomMessageBoxResult.OK;
            this.Close();
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            Result = CustomMessageBoxResult.Yes;
            this.Close();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            Result = CustomMessageBoxResult.No;
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Result = CustomMessageBoxResult.Cancel;
            this.Close();
        }


        public static CustomMessageBoxResult Show(string messageBoxText, CustomMessageBoxButton messageBoxButton, CustomMessageBoxIcon messageBoxImage)
        {
            DiyMessageBox window = new DiyMessageBox();
            window.Topmost = true;
            window.MessageBoxText = messageBoxText;

            switch (messageBoxImage)
            {
                case CustomMessageBoxIcon.Error:
                    window.ImagePath = @"/res/drawable/Error.png";
                    break;
                case CustomMessageBoxIcon.Question:
                    window.ImagePath = @"/res/drawable/Question.png";
                    break;
                case CustomMessageBoxIcon.Warning:
                    window.ImagePath = @"/res/drawable/Warning.png";
                    break;
                case CustomMessageBoxIcon.Tips:
                    window.ImagePath = @"/res/drawable/Tips.png";
                    break;
                case CustomMessageBoxIcon.Success:
                    window.ImagePath = @"/res/drawable/Success.png";
                    break;
            }

            switch (messageBoxButton)
            {
                case CustomMessageBoxButton.OK:
                    window.OkButtonVisibility = Visibility.Visible;
                    break;
                case CustomMessageBoxButton.OKCancel:
                    window.OkButtonVisibility = Visibility.Visible;
                    window.CancelButtonVisibility = Visibility.Visible;
                    break;
                case CustomMessageBoxButton.YesNo:
                    window.YesButtonVisibility = Visibility.Visible;
                    window.NoButtonVisibility = Visibility.Visible;
                    break;
                case CustomMessageBoxButton.YesNoCancel:
                    window.YesButtonVisibility = Visibility.Visible;
                    window.NoButtonVisibility = Visibility.Visible;
                    window.CancelButtonVisibility = Visibility.Visible;
                    break;
                default:
                    window.OkButtonVisibility = Visibility.Visible;
                    break;
            }

            window.ShowDialog();
            return window.Result;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    
    
    }
}
