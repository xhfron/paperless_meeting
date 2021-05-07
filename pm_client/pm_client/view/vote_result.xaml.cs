using Newtonsoft.Json;
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

namespace pm_client.view {
    /// <summary>
    /// vote_result.xaml 的交互逻辑
    /// </summary>
    public partial class vote_result : UserControl {
        INavigator board;
        public void AddBoard(INavigator board) {
            this.board = board;
        }

        public vote_result() {
            InitializeComponent();
        }
        Vote vote;
        public void setVote(Vote vote) {
            this.vote = vote;
            VoteResultCollection res= getVoteResult(vote.id);
            int total=0;
            foreach (VoteResult s in res.res) total += s.number;
            List<ChoiceResult> list = new List<ChoiceResult>();
            foreach(VoteResult s in res.res){
                ChoiceResult c = new ChoiceResult();
                c.number = s.number;
                c.optionId= s.optionId;
                foreach(VoteOption o in vote.options) {
                    if (o.id == c.optionId) {
                        c.option = o.content;
                        break;
                    }
                }
                c.percent = c.number / total;
                c.total = total;
                list.Add(c);
            }
            this.ResultList.ItemsSource = list;
        }
        VoteResultCollection getVoteResult(int voteId) {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict["voteId"] = voteId;
            string str = WebUtil.post("/host/getVoteRes", dict);
            return JsonConvert.DeserializeObject<VoteResultCollection>(str);
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            board.Push(new vote_result_detail());
        }

        private void checkDetail(object sender, SelectionChangedEventArgs e) {
            board.Push(new vote_result_detail());
        }
    }
}
