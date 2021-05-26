using Newtonsoft.Json;
using pm_client.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    public partial class vote_result : UserControl {
        INavigator board;
        public void AddBoard(INavigator board) {
            this.board = board;
        }
        volatile bool stop = false;

        public vote_result() {
            InitializeComponent();
        }
        public void refresh() {
            int total = 0;
            VoteResultCollection voteResultCollection = WebUtil.getVoteResult(vote.uid);
            foreach (VoteResult s in voteResultCollection.res) total += s.number;
            foreach (VoteResult voteResult in voteResultCollection.res) {
                foreach (VoteOption option in vote.options) {
                    if (option.uid != voteResult.optionId) continue;
                    ChoiceResultViewData viewData = dict[option.uid];
                    viewData.number = voteResult.number;
                    viewData.optionId = voteResult.optionId;
                    viewData.percent = (int)(100.0 * viewData.number / total);
                    viewData.total = total;

                }
            }
        }
        public async Task loop() {
            await Task.Run(() => {

                while (true) {
                    Thread.Sleep(500);
                    if (stop) {
                        break;
                    }

                    refresh();
                }
            });
        }
        Vote vote;
            Dictionary<int, ChoiceResultViewData> dict = new Dictionary<int, ChoiceResultViewData>();
        public void setVote(Vote vote) {
            this.vote = vote;
            VoteResultCollection res= WebUtil.getVoteResult(vote.uid);
            int total=0;
            foreach (VoteResult s in res.res) total += s.number;
            List<ChoiceResultViewData> list = new List<ChoiceResultViewData>();
            foreach(VoteOption option in this.vote.options){
                ChoiceResultViewData choiceResultViewData = new ChoiceResultViewData();
                choiceResultViewData.number = 0;
                choiceResultViewData.option = option.content;
                choiceResultViewData.optionId = option.uid;
                choiceResultViewData.percent = 0;
                list.Add(choiceResultViewData);
                dict[option.uid] = choiceResultViewData;
            }
            this.DataContext = vote;
            this.ResultList.ItemsSource = list;

            refresh();
            if (vote.state == Vote.VOTED) {
                this.closeBtn.Visibility = Visibility.Collapsed;
            } else {
                loop();
            }
        }
        

        private void Button_Click(object sender, RoutedEventArgs e) {
            try {
                WebUtil.closeVote(vote.uid);
                stop = true;
                board.Pop();
                this.closeBtn.Visibility = Visibility.Collapsed;
            } catch (NetworkException) {
                ViewUtil.msg("操作失败");
            }

        }

        private void checkDetail(object sender, SelectionChangedEventArgs e) {
            vote_result_detail v = new vote_result_detail();
            ChoiceResultViewData selected = (ChoiceResultViewData)this.ResultList.SelectedItem;
            if (selected == null) {
                return;
            }
            VoteResult voteResultToPick = null;
            VoteResultCollection voteResultCollection = WebUtil.getVoteResult(vote.uid);
            foreach (VoteResult voteResult in voteResultCollection.res) {
                if (selected.optionId == voteResult.optionId) {
                    voteResultToPick = voteResult;
                    break;
                }
            }
            if (voteResultToPick == null) {
                voteResultToPick = new VoteResult();
                voteResultToPick.number = 0;
                voteResultToPick.devices = new List<string>();
                voteResultToPick.optionId = selected.optionId;
            }
            v.setVoteResultDetail(voteResultToPick, this.vote,selected);
            board.Push(v);
            this.ResultList.SelectedItem = null;
        }
    }
}
