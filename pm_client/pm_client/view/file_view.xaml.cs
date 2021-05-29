using Newtonsoft.Json;
using pm_client.util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace pm_client.view {
    /// <summary>
    /// file_list_view.xam`l 的交互逻辑
    /// </summary>
    public partial class file_list_view : UserControl {
        INavigator board;
        public void AddBoard(INavigator board) {
            this.board = board;
        }
        public file_list_view() {
            InitializeComponent();
            //loadFile();
        }
        void open(string name) {

        }
        string name = "FileListView";

        public async void loadFile(int meetingId,int roleId) {
            try {

                int total = 0;
                int current = 0;
                DirectoryInfo d = new DirectoryInfo(Settings.fileDir);
                if (!d.Exists) {
                    Log.i(name, "dir created");
                    d.Create();
                }
                //List<util.File> list = getFileList(meetingId, roleId);
                List<util.File> list = new List<util.File>();
                total = list.Count;
                this.loading_text.Text = $"正在同步:{current}/{total}";
                foreach (var file in list) {
                    await Task.Run(() => WebUtil.downloadFile(file.id, file.name));
                    Log.l(name, "warrning const");
                    current++;
                    this.loading_text.Text = $"正在同步:{current}/{total}";
                }
                Log.i(name, "file downloaded");
                /*foreach (FileInfo dir in d.GetFiles())
                {
                    util.File f = new util.File();
                    f.name = dir.Name;
                    list.Add(f);
                }*/
                this.file_list.ItemsSource = list;
                this.loading_tip.Visibility = Visibility.Hidden;
            } catch (Exception e) {
                Log.i(name, e);
            }
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs re) {
            Image e = (Image)this.FindName("loading_img");
            RotateTransform rotateTransform = new RotateTransform();
            rotateTransform.CenterX = this.loading_img.Width / 2;
            rotateTransform.CenterY = this.loading_img.Height / 2;
            DoubleAnimation ani = new DoubleAnimation();
            ani.From = 0;
            ani.To = -720;
            ani.RepeatBehavior = RepeatBehavior.Forever;
            ani.Duration = TimeSpan.FromSeconds(10);
            e.RenderTransform = rotateTransform;
            rotateTransform.BeginAnimation(RotateTransform.AngleProperty, ani);
        }

        private void openFile(object sender, SelectionChangedEventArgs e) {
            util.File f = (util.File)this.file_list.SelectedItem;
            Log.i("file", this.file_list.SelectedItem);
            if (f == null) return;
            this.file_list.SelectedItem = null;
            Log.i(name, new FileInfo(f.name).FullName);

            string path = System.IO.Path.Combine(Settings.fileDir, f.name);
            if (path.EndsWith(".pdf")) {
                board.Push(new file_pdf_view(path));
            } else if (path.EndsWith(".mp4")) {
                path = new FileInfo(path).FullName;
                board.Push(new file_video_view(path));
            } else {
                ViewUtil.msg("unknown format");
            }
        }
        List<util.File> getFileList(int meetingId, int roleId) {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict["meetingId"] = meetingId;
            dict["roleId"] = roleId;
            string str = WebUtil.post("/file/getFileList", dict);
            return JsonConvert.DeserializeObject<List<util.File>>(str);
        }
    }
}
