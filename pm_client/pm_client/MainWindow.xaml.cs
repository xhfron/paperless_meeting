using pm_client.util;
using pm_client.view;
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
            showBanner();
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hello");
            Grid g = this.FindName("container") as Grid;
            UserControl k = new pm_client.view.vote();
            Grid.SetRow(k, 1);
            Grid.SetColumn(k, 1);
            pm_client.util.Meeting j = new util.Meeting();
            j.Id = "hello";
            g.DataContext = j;
            g.Children.Add(k);

        }
        splash s;
        void showBanner()
        {
            splash newView = new splash();
            Grid g = this.FindName("container") as Grid;
            Grid.SetRow(newView, 0);
            Grid.SetRowSpan(newView, 2);
            Grid.SetColumn(newView, 0);
            Grid.SetColumnSpan(newView, 3);
            Grid.SetZIndex(newView, 1288);
            g.Children.Add(newView);
        }
        
        private void toFile(object sender,RoutedEventArgs e)
        {
            replaceBy( ui["file"]);
        }
        private void toSettings(object sender, RoutedEventArgs e)
        {
            replaceBy( ui["settings"]);
        }
        private void toVote(object sender, RoutedEventArgs e)
        {
            replaceBy( ui["vote"]);
        }
        private void toNote(object sender, RoutedEventArgs e)
        {
            replaceBy( ui["note"]);
        }
        private void toRemote(object sender, RoutedEventArgs e)
        {
            replaceBy( ui["remote"]);
        }
        private void back(object sender, RoutedEventArgs e)
        {
            if (current.Count >= 2)
            {
                removeFromShowing();
                current.Pop();
                addToShow(current.Peek());
            }
            
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            ui.Add("file", new Stack<UserControl>());
            ui["file"].Push(new view.file_list_view());
            ui.Add("settings", new Stack<UserControl>());
            ui["settings"].Push(new view.logout());
            ui.Add("vote", new Stack<UserControl>());

            view.vote_list_view vlview = new view.vote_list_view();
            vlview.AddBoard(this);
            voteList = new List<Vote>();
            (vlview.FindName("VoteListViewVoteList") as ListBox).ItemsSource = voteList;
            voteList.Add(Vote.mock());
            voteList.Add(Vote.mock());
            ui["vote"].Push(vlview);
            //ui["vote"].Push(new view.vote());
            ui.Add("note", new Stack<UserControl>());
            ui["note"].Push(new view.note());
            ui.Add("remote", new Stack<UserControl>());
            ui["remote"].Push(new view.remote());

            replaceBy(ui["file"]);
        }

        public void Push(UserControl newView)
        {
            removeFromShowing();
            current.Push(newView);
            addToShow(newView);
        }
    }
}
