using Newtonsoft.Json;
using pm_client.util;
using pm_client.view;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;

namespace pm_client {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    /// 文件 file
    /// 投票 vote
    /// 笔记 note
    /// 应用 remote
    /// 设置 settings
    /// 主持人 a_
    /// 组件 _componentname
    /// 
    /// 文件名 下划线
    /// xml，cs 大驼峰
    /// 
    /// 角色_功能_组件_状态
    public partial class MainWindow : Window, INavigator {
        Stack<UserControl> current;
        Dictionary<string, Stack<UserControl>> ui = new Dictionary<string, Stack<UserControl>>();
        ProcessManager p;
        public MainWindow() {
            Log.fuckingCSharp = this.Dispatcher;
            var t = this.Dispatcher;
            InitializeComponent();
            showBanner(new splash());
            showBanner(new SuperSplash());
            Log.i("hello", "hello");
            new Thread(new ThreadStart(this.run)).Start();
            
            if (false) {
                try {
                    /*getMeeting(1,1);
                    getFileList(1, 1);
                    beginMeeting(1);
                    beginVote(1);
                    getVoteList(1,1);*/
                    //getVoteResult(1);
                    //submitOption(1, 1, 1);
                    WebUtil.downloadFile(4, "a.exe");
                } catch (Exception e) {
                    Log.i("ca", e);
                }
            }
            
        }
        void run() {
            Thread.CurrentThread.Name = "background";
            while (true) {
                Thread.Sleep(800);
                var dt = DateTime.Now;
                ViewUtil.Find<SuperInfo>(this, "superInfo").time = dt.ToShortTimeString();
                //Dispatcher.Invoke(()=> Log.l("b", dt.ToLongTimeString()));

            }
        }


        void beginMeeting(int meetingId) {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict["meetingId"] = meetingId;
            WebUtil.post("/host/beginMeeting", dict);
        }


        void remoteSwitch(int mode) {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict["mode"] = mode;
            WebUtil.post("/host/programLimit", dict);
        }
        List<util.Vote> getVoteList(int meetingId, int deviceId) {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict["meetingId"] = meetingId;
            dict["deviceId"] = deviceId;
            string str = WebUtil.post("/vote/getVoteList", dict);
            return JsonConvert.DeserializeObject<List<util.Vote>>(str);
        }



        private void RadioButton_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show("hello");
            Grid g = this.FindName("container") as Grid;
            UserControl k = new pm_client.view.vote();
            Grid.SetRow(k, 1);
            Grid.SetColumn(k, 1);
            pm_client.util.Meeting j = new util.Meeting();
            j.meetingId = 20;
            g.DataContext = j;
            g.Children.Add(k);

        }
        void showBanner(UserControl newView) {
            Grid g = this.FindName("container") as Grid;
            Grid.SetRow(newView, 0);
            Grid.SetRowSpan(newView, 2);
            Grid.SetColumn(newView, 0);
            Grid.SetColumnSpan(newView, 3);
            Grid.SetZIndex(newView, 1288);
            g.Children.Add(newView);
        }

        private void toFile(object sender, RoutedEventArgs e) {
            (FindName("SettingsBtn") as RadioButton).IsChecked = false;

            replaceBy(ui["file"]);
        }
        private void toSettings(object sender, RoutedEventArgs e) {
            (FindName("RemoteBtn") as RadioButton).IsChecked = false;
            (FindName("FileBtn") as RadioButton).IsChecked = false;
            (FindName("VoteBtn") as RadioButton).IsChecked = false;
            (FindName("NoteBtn") as RadioButton).IsChecked = false;
            replaceBy(ui["settings"]);
        }
        async void t() {
            ClientWebSocket webSocket = new ClientWebSocket();
            await webSocket.ConnectAsync(new Uri("wss://echo.websocket.org"), CancellationToken.None);


            await webSocket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes("hello")), WebSocketMessageType.Binary, true, CancellationToken.None);
            //await webSocket.ReceiveAsync(null,null);
            await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "1", CancellationToken.None);
            webSocket.Dispose();
        }
        private void toVote(object sender, RoutedEventArgs e) {
            (FindName("SettingsBtn") as RadioButton).IsChecked = false;
            replaceBy(ui["vote"]);
        }
        private void toNote(object sender, RoutedEventArgs e) {
            (FindName("SettingsBtn") as RadioButton).IsChecked = false;
            replaceBy(ui["note"]);
        }
        private void toRemote(object sender, RoutedEventArgs e) {
            (FindName("SettingsBtn") as RadioButton).IsChecked = false;
            replaceBy(ui["remote"]);
        }

        private void replaceBy(Stack<UserControl> next) {
            removeFromShowing();
            current = next;
            addToShow(next.Peek());
        }
        private void removeFromShowing() {
            if (current != null) {
                Grid g = this.FindName("container") as Grid;
                g.Children.Remove(current.Peek());
            }
        }
        private void addToShow(UserControl newView) {
            Grid g = this.FindName("container") as Grid;
            Grid.SetRow(newView, 1);
            Grid.SetColumn(newView, 1);
            Grid.SetColumnSpan(newView, 2);
            g.Children.Add(newView);
        }


        private void Window_Initialized(object sender, EventArgs e) {
            ui.Add("file", new Stack<UserControl>());
            file_list_view flview = new file_list_view();
            flview.AddBoard(this);
            ui["file"].Push(flview);
            ui.Add("settings", new Stack<UserControl>());
            ui["settings"].Push(new view.logout());
            ui.Add("vote", new Stack<UserControl>());

            view.vote_list_view vlview = new view.vote_list_view();
            vlview.setVoteList(getVoteList(1, 1));
            vlview.AddBoard(this);
            //voteList = new List<Vote>();
            //(vlview.FindName("VoteListViewVoteList") as ListBox).ItemsSource = voteList;
            ui["vote"].Push(vlview);
            //ui["vote"].Push(new view.vote());
            ui.Add("note", new Stack<UserControl>());
            ui["note"].Push(new view.note());
            ui.Add("remote", new Stack<UserControl>());
            ui["remote"].Push(new view.remote());

            replaceBy(ui["file"]);


        }
        IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled) {
            //Log.l("msg", "" + msg);
            if (msg == 0x0400 + 7) {
                int proId = lParam.ToInt32();
                Log.i("hook", $"pid:{proId}");
            }
            return IntPtr.Zero;
        }

        public void Push(UserControl newView) {
            removeFromShowing();
            current.Push(newView);
            addToShow(newView);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            if (true) return;
            //you never got where it crashed
            p = new ProcessManager();
            HwndSource source = HwndSource.FromHwnd(new WindowInteropHelper(this).Handle);
            if (source != null) source.AddHook(WndProc); else Log.i("wndproc", "failed");
            p.StartupHook();
        }

        private void back(object sender, TouchEventArgs e) {
            //Log.l("main", "depth", "" + current.Count);
            if (current.Count >= 2) {
                removeFromShowing();
                current.Pop();
                addToShow(current.Peek());
            }
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e) {
            if (true) return;
            p.CloseHook();
        }
    }
}
