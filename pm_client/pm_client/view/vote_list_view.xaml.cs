using pm_client.util;
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
    /// vote_list_view.xaml 的交互逻辑
    /// </summary>
    public partial class vote_list_view : UserControl
    {
        INavigator board;
        public void AddBoard(INavigator board)
        {
            this.board = board;
        }

        public vote_list_view()
        {
            InitializeComponent();
        }

        private void VoteListViewVoteList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach(object k in e.AddedItems){
                System.Console.WriteLine(k);
            }
        }

        private void toVoteDetail(object sender, SelectionChangedEventArgs e)
        {
            vote v = new vote();
            v.AddBoard(this.board);
            board.Push(v);
        }
    }
}
