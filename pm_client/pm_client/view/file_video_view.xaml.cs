using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace pm_client.view
{
    /// <summary>
    /// file_video_view.xaml 的交互逻辑
    /// </summary>
    public partial class file_video_view : UserControl
    {

		private Grid f_view;
		private Grid f_sub_view;
		private bool mediaPlayerIsPlaying = false;
		private bool userIsDraggingSlider = false;


		public file_video_view(Grid f_view, Grid f_sub_view)
		{
			InitializeComponent();

			this.f_view = f_view;
			this.f_sub_view = f_sub_view;

			DispatcherTimer timer = new DispatcherTimer();
			timer.Interval = TimeSpan.FromSeconds(1);
			timer.Tick += timer_Tick;
			timer.Start();
			mePlayer.Play();
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			if ((mePlayer.Source != null) && (mePlayer.NaturalDuration.HasTimeSpan) && (!userIsDraggingSlider))
			{
				sliProgress.Minimum = 0;
				sliProgress.Maximum = mePlayer.NaturalDuration.TimeSpan.TotalSeconds;
				sliProgress.Value = mePlayer.Position.TotalSeconds;
			}
		}

		private void mePlayer_Loaded(object sender, RoutedEventArgs e)
		{

			string path = AppDomain.CurrentDomain.BaseDirectory;
			string rootpath = path.Substring(0, path.LastIndexOf("bin"));

			mePlayer.Source = new Uri(rootpath + "res\\drawable\\MP4Test.mp4");

			mePlayer.Play();


		}


		



		private void Playbutton_Click(object sender, RoutedEventArgs e)
		{
			mePlayer.Play();
			mediaPlayerIsPlaying = true;
		}

		private void Pausebutton_Click(object sender, RoutedEventArgs e)
		{
			mePlayer.Pause();
		}

		private void Exitbutton_Click(object sender, RoutedEventArgs e)
		{
			//点击退出按钮退出视频，返回文件列表
			f_view.Children.Remove(this);
			f_view.Children.Add(f_sub_view);

		}



		private void sliProgress_DragStarted(object sender, DragStartedEventArgs e)
		{
			userIsDraggingSlider = true;
		}

		private void sliProgress_DragCompleted(object sender, DragCompletedEventArgs e)
		{
			userIsDraggingSlider = false;
			mePlayer.Position = TimeSpan.FromSeconds(sliProgress.Value);
		}

		private void sliProgress_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			lblProgressStatus.Text = TimeSpan.FromSeconds(sliProgress.Value).ToString(@"hh\:mm\:ss");
		}



		private void Grid_MouseWheel(object sender, MouseWheelEventArgs e)
		{
			mePlayer.Volume += (e.Delta > 0) ? 0.1 : -0.1;
		}




        

        
    }

}
