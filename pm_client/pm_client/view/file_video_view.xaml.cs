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

		private string filepath;

		private bool mediaPlayerIsPlaying = false;
		private bool userIsDraggingSlider = false;//是否正在拖动滑块
		private bool userIsClickingSlider = false;//是否正在点击进度条


		public file_video_view(string filepath)
		{
			InitializeComponent();

			this.filepath = filepath;

			DispatcherTimer timer = new DispatcherTimer();
			timer.Interval = TimeSpan.FromSeconds(1);
			timer.Tick += timer_Tick;
			timer.Start();
			mePlayer.Play();
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			if ((mePlayer.Source != null) && (mePlayer.NaturalDuration.HasTimeSpan) && (!userIsDraggingSlider) && (!userIsClickingSlider))
			{

				//设置进度条的最大值和最小值
				sliProgress.Minimum = 0;
				sliProgress.Maximum = mePlayer.NaturalDuration.TimeSpan.TotalSeconds;

				//显示视频的总时间
				totalTimeView.Text = TimeSpan.FromSeconds(sliProgress.Maximum).ToString(@"hh\:mm\:ss");

				sliProgress.Value = mePlayer.Position.TotalSeconds;

			}
		}

		private void mePlayer_Loaded(object sender, RoutedEventArgs e)
		{


			//开始播放视频
			mePlayer.Source = new Uri(filepath);
			//string path = AppDomain.CurrentDomain.BaseDirectory;
			//string rootpath = path.Substring(0, path.LastIndexOf("bin"));
			//string completePath = rootpath + "bin\\x64\\Debug" + filepath.Remove(0, 1);
			//mePlayer.Source = new Uri(completePath);
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
		}



		private void sliProgress_DragStarted(object sender, DragStartedEventArgs e)
		{
			userIsDraggingSlider = true;
		}

		private void sliProgress_DragCompleted(object sender, DragCompletedEventArgs e)
		{
			//拖动进度条改变播放进度
			userIsDraggingSlider = false;
			mePlayer.Position = TimeSpan.FromSeconds(sliProgress.Value);
		}



		private void sliProgress_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			userIsClickingSlider = true;
		}

		private void sliProgress_PreviewMouseUp(object sender, MouseButtonEventArgs e)
		{
			//点击进度条改变播放进度	
			userIsClickingSlider = false;
			mePlayer.Position = TimeSpan.FromSeconds(sliProgress.Value);
		}



		private void sliProgress_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			//显示的时间随着进度条的改变而改变
			lblProgressStatus.Text = TimeSpan.FromSeconds(sliProgress.Value).ToString(@"hh\:mm\:ss");
		}



        
    }

}
