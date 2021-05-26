﻿using Newtonsoft.Json;
using pm_client.util;
using pm_client.view;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using static pm_client.view.DiyMessageBox;

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
    public partial class MainWindow : Window, INavigator,MessageListener {
        Stack<UserControl> current;
        Dictionary<string, Stack<UserControl>> ui = new Dictionary<string, Stack<UserControl>>();
        HookManager p;
        string name = "MainWindow";
        SuperSplash superSplash;
        public MainWindow() {
            Log.fuckingCSharp = this.Dispatcher;
            var t = this.Dispatcher;

            InitializeComponent();

            this.Resources["STOMPClient"] = new STOMPClient();
            STOMPClient s = (this.Resources["STOMPClient"] as STOMPClient);
            s.connectWs("ws://paperless.ronwhite.online:10087/websocket");
            s.connect();
            s.subscribe("/topic/cmd");

            s.addJsonListener(this);


            superSplash = new SuperSplash();
            showBanner(superSplash);

            new Thread(new ThreadStart(this.run)).Start();
        }
        async void tryConnecting() {
            await Task.Run(() => {

            });
            int meetingId = -1;
            Meeting meeting = null;
            while (true) {
                try {
                    Thread.Sleep(1000);
                    meetingId = WebUtil.latestMeetingId();
                    //meetingId = 1;
                    meeting = WebUtil.getMeeting(meetingId, WebUtil.getDeviceId());
                    if (meeting == null) {
                        ViewUtil.msg("没会议，告辞");
                        await Task.Run(() => System.Environment.Exit(0));
                        return;
                    }
                    meeting.role.name = "主持人";
                    Log.i(name, "hello");
                    ViewUtil.Find<Meeting>(this, "meeting").load(meeting);
                    if (meeting.role == null) {

                    }Console.WriteLine("aeowifndlksvnzoijflksdjfewocdmsoiewvoi");
                    ViewUtil.Find<Role>(this, "role").load(meeting.role);
                    //ViewUtil.Find<Role>(this, "role").name = "mike";
                    break;
                } catch (NetworkException e) {
                    Log.i("supersplash", "connection failed,trying after 3 second");
                    Thread.Sleep(3000);
                }
            }
            STOMPClient s = (this.Resources["STOMPClient"] as STOMPClient);

            ui.Add("file", new Stack<UserControl>());
            file_list_view flview = new file_list_view();
            flview.loadFile(meetingId, meeting.role.id);
            flview.AddBoard(this);
            ui["file"].Push(flview);

            ui.Add("settings", new Stack<UserControl>());
            ui["settings"].Push(new view.logout());

            ui.Add("vote", new Stack<UserControl>());
            view.vote_list_view vlview = new view.vote_list_view();
            s.addJsonListener(vlview);
            vlview.setVoteList(WebUtil.getVoteList(meetingId, ViewUtil.Find<Role>(this, "role").id));
            vlview.AddBoard(this);
            //voteList = new List<Vote>();
            //(vlview.FindName("VoteListViewVoteList") as ListBox).ItemsSource = voteList;
            ui["vote"].Push(vlview);

            ui.Add("note", new Stack<UserControl>());
            ui["note"].Push(new view.note());
            ui.Add("remote", new Stack<UserControl>());
            ui["remote"].Push(new view.remote());

            replaceBy(ui["file"]);

            if (WebUtil.getMeetingState(meetingId) != 1) {
                //0-idle 1-start 2-end -1 invalid

            splash spl = new splash();
            s.addJsonListener(spl);
            showBanner(spl);
            }

            superSplash.Visibility = Visibility.Collapsed;
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
            tryConnecting();
        }
        IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled) {
            //Log.l("msg", "" + msg);
            if (msg == 0x0400 + 7) {
                int proId = lParam.ToInt32();
                Log.i("hook", $"pid:{proId}");
                Process p = Process.GetProcessById(proId);
                Log.i("hook", p.MainModule.FileName);
            }
            return IntPtr.Zero;
        }

        public void Push(UserControl newView) {
            removeFromShowing();
            current.Push(newView);
            addToShow(newView);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            //if (true) return;
            //you never got where it crashed
            p = new HookManager();
            HwndSource source = HwndSource.FromHwnd(new WindowInteropHelper(this).Handle);
            if (source != null) source.AddHook(WndProc); else Log.i("wndproc", "failed");
            p.StartupHook();
        }


        private void Window_Unloaded(object sender, RoutedEventArgs e) {
            if (true) return;
            p.CloseHook();
        }

        private void back(object sender, RoutedEventArgs e) {
            //Log.l("main", "depth", "" + current.Count);
            if (current.Count >= 2) {
                removeFromShowing();
                current.Pop();
                addToShow(current.Peek());
            }
        }

        public void Pop() {
            back(null, null);
        }

        public void Replace(UserControl newView) {
            back(null, null);
            Push(newView);
        }
        private void delete(DirectoryInfo root) {
            foreach (var x in root.GetDirectories()) {
                delete(x);
            }
            foreach (var x in root.GetFiles()) {
                x.Delete();
            }
            root.Delete();
        }

        public void onMessage(Dictionary<string, object> json) {
            string cmd = (string)json["cmd"];
            if (cmd.Contains("结束投票")) {
                DirectoryInfo directoryInfo=new DirectoryInfo(Settings.fileDir);
                if (directoryInfo.Exists) {
                    delete(directoryInfo);
                }
            }
        }
    }
}
