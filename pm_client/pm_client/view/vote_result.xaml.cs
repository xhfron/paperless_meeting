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
    /// vote_result.xaml 的交互逻辑
    /// </summary>
    public partial class vote_result : UserControl
    {
        INavigator board;
        public void AddBoard(INavigator board)
        {
            this.board = board;
        }

        public vote_result()
        {
            InitializeComponent();
            ListBox l = this.FindName("ResultList") as ListBox;
            l.ItemsSource = new List<VoteChoiceResult>(new VoteChoiceResult[] { VoteChoiceResult.mock(),VoteChoiceResult.mock()});
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            board.Push(new vote_result_detail());
        }
    }
}
