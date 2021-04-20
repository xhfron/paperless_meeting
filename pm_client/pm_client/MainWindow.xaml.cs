using Newtonsoft.Json;
using pm_client.util;
using pm_client.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace pm_client
{
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
    public partial class MainWindow : Window, INavigator
    {
        Stack<UserControl> current;
        Dictionary<string, Stack<UserControl>> ui = new Dictionary<string, Stack<UserControl>>();
        List<Vote> voteList;
        public MainWindow()
        {
            InitializeComponent();
            showBanner(new SuperSplash());
            Log.i("hello", "hello");
            new Thread(new ThreadStart(this.run)).Start();
            if (false)
            {
                try
                {

                    /*getMeeting(1,1);
                    getFileList(1, 1);
                    beginMeeting(1);
                    beginVote(1);
                    getVoteList(1,1);*/
                    //getVoteResult(1);
                    //submitOption(1, 1, 1);
                    WebUtil.downloadFile(4, "a.exe");
                }catch(Exception e)
                {
                    Log.i("ca", e);
                }
            }
        }
        void run()
        {
            Thread.CurrentThread.Name="background";
            while (true)
            {
                Thread.Sleep(800);
                var dt = DateTime.Now;
                ViewUtil.Find<SuperInfo > (this,"superInfo").time = dt.ToLongTimeString();
                //Dispatcher.Invoke(()=> Log.l("b", dt.ToLongTimeString()));
                
            }
        }
        bool getMeeting(int id,int deviceId)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict["meetingId"] = id;
            dict["deviceId"] = deviceId;
            string s = WebUtil.post("/meeting/info", dict);
            //Log.i("hi", JsonConvert.DeserializeObject(s));
            return true;
        }
        List<File> getFileList(int meetingId,int roleId)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict["meetingId"] = meetingId;
            dict["roleId"] = roleId;
            string str = WebUtil.post("/file/getFileList", dict);
            return JsonConvert.DeserializeObject<List<File>>(str);
        }
        void beginMeeting(int meetingId)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict["meetingId"] = meetingId;
            WebUtil.post("/host/beginMeeting", dict);
        }
        void beginVote(int voteId)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict["voteId"] = voteId;
            WebUtil.post("/host/beginVote", dict);
        }
        VoteResult getVoteResult(int voteId)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict["voteId"] = voteId;
            string str = WebUtil.post("/host/getVoteRes", dict);
            return JsonConvert.DeserializeObject<VoteResult>(str);
        }
        void remoteSwitch(int mode)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict["mode"] = mode;
            WebUtil.post("/host/programLimit", dict);
        }
        List<util.Vote> getVoteList(int meetingId,int deviceId)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict["meetingId"] = meetingId;
            dict["deviceId"] = deviceId;
            string str = WebUtil.post("/vote/getVoteList", dict);
            return JsonConvert.DeserializeObject<List<util.Vote>>(str);
        }
        void submitOption(int voteId,int optionId,int deviceId)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict["optionId"] = optionId;
            dict["voteId"] = voteId;
            dict["deviceId"] = deviceId;
            WebUtil.post("/vote/submitOption", dict);
        }


        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
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
        splash s;
        void showBanner(UserControl newView)
        {
            Grid g = this.FindName("container") as Grid;
            Grid.SetRow(newView, 0);
            Grid.SetRowSpan(newView, 2);
            Grid.SetColumn(newView, 0);
            Grid.SetColumnSpan(newView, 3);
            Grid.SetZIndex(newView, 1288);
            g.Children.Add(newView);
        }
        RadioButton lastOne;

        private void toFile(object sender, RoutedEventArgs e)
        {
            (FindName("SettingsBtn") as RadioButton).IsChecked = false;
            
            replaceBy(ui["file"]);
        }
        private void toSettings(object sender, RoutedEventArgs e)
        {
            (FindName("RemoteBtn") as RadioButton).IsChecked = false;
            (FindName("FileBtn") as RadioButton).IsChecked = false;
            (FindName("VoteBtn") as RadioButton).IsChecked = false;
            (FindName("NoteBtn") as RadioButton).IsChecked = false;
            replaceBy(ui["settings"]);
        }
        async void t()
        {
            ClientWebSocket webSocket = new ClientWebSocket();
            await webSocket.ConnectAsync(new Uri("ws://10.10.13.140:8080/"),CancellationToken.None);

            await webSocket.SendAsync(new ArraySegment<byte>(bsend), WebSocketMessageType.Binary, true, CancellationToken.None);
            await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "1", CancellationToken.None);
            webSocket.Dispose();
        }
        private void toVote(object sender, RoutedEventArgs e)
        {
            (FindName("SettingsBtn") as RadioButton).IsChecked = false;
            replaceBy(ui["vote"]);
        }
        private void toNote(object sender, RoutedEventArgs e)
        {
            (FindName("SettingsBtn") as RadioButton).IsChecked = false;
            replaceBy(ui["note"]);
        }
        private void toRemote(object sender, RoutedEventArgs e)
        {
            (FindName("SettingsBtn") as RadioButton).IsChecked = false;
            replaceBy(ui["remote"]);
        }
       
        private void replaceBy(Stack<UserControl> next)
        {
            removeFromShowing();
            current = next;
            addToShow(next.Peek());
        }
        private void removeFromShowing()
        {
            if (current != null)
            {
                Grid g = this.FindName("container") as Grid;
                g.Children.Remove(current.Peek());
            }
        }
        private void addToShow(UserControl newView)
        {
            Grid g = this.FindName("container") as Grid;
            Grid.SetRow(newView, 1);
            Grid.SetColumn(newView, 1);
            Grid.SetColumnSpan(newView, 2);
            g.Children.Add(newView);
        }

       
        private void Window_Initialized(object sender, EventArgs e)
        {
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
        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            System.Console.WriteLine("hello");
            if (msg == 0x0400 + 7)
            {
                int proId = lParam.ToInt32();
                System.Console.WriteLine("" + proId + ":started");
            }
            return IntPtr.Zero;
        }

        public void Push(UserControl newView)
        {
            removeFromShowing();
            current.Push(newView);
            addToShow(newView);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           //you never got where it crashed
        }

        private void back(object sender, TouchEventArgs e)
        {
            if (current.Count >= 2)
            {
                removeFromShowing();
                current.Pop();
                addToShow(current.Peek());
            }
        }
    }
}
