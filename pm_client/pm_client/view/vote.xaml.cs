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
    /// vote.xaml 的交互逻辑
    /// </summary>
    public partial class vote : UserControl
    {
        INavigator board;
        public void AddBoard(INavigator board)
        {
            this.board = board;
        }
        util.Vote _vote;
        public void setVote(util.Vote vote)
        {
            this._vote = vote;
            this.DataContext = vote;
        }

        public vote()
        {
            InitializeComponent();
            Vote v = new Vote();
            this.DataContext = v;
        }


        private void Button_Click(object sender, TouchEventArgs e)
        {
            vote_result t = new vote_result();
            t.AddBoard(board);
            board.Push(t);
        }
    }
}
