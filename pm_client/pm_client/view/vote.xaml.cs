using pm_client.util;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace pm_client.view {
    /// <summary>
    /// vote.xaml 的交互逻辑
    /// </summary>
    public partial class vote : UserControl {
        INavigator board;
        public void AddBoard(INavigator board) {
            this.board = board;
        }
        util.Vote _vote;
        public void setVote(util.Vote vote) {
            this._vote = vote;
            this.DataContext = vote;
        }
        public vote() {
            InitializeComponent();

            if (ViewUtil.Find<Role>(this, "role").name == "主持人") {
                this.choiceListBox.IsEnabled = false;
                this.userBtn.Visibility = Visibility.Hidden;
            } else {
                this.countingPanel.Visibility = Visibility.Hidden;
                this.adminBtn.Visibility = Visibility.Hidden;
            }

        }

        private void shootVote(object sender, RoutedEventArgs e) {
            if (this.choiceListBox.SelectedItems.Count == 0) {
                ViewUtil.msg("你至少选一个啊");
                return;
            }
            try {
                foreach (var c in this.choiceListBox.SelectedItems) {
                    VoteOption choice = (VoteOption)c;
                    submitOption(_vote.uid, choice.uid, WebUtil.getDeviceId());
                }
                ViewUtil.msg("投票成功");
            } catch (NetworkException) {
                ViewUtil.msg("投票失败");
            }
        }
        void beginVote(int voteId) {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict["voteId"] = voteId;
            WebUtil.post("/host/beginVote", dict);
        }
        void submitOption(int voteId, int optionId, int deviceId) {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict["optionId"] = optionId;
            dict["voteId"] = voteId;
            dict["deviceId"] = deviceId;
            try {
                WebUtil.post("/vote/submitOption", dict);
            } catch (NetworkException e) {
                ViewUtil.msg($"投票失败:{e.message}");
            }
        }

        private void startVote(object sender, TouchEventArgs e) {
            beginVote(this._vote.uid);
            ViewUtil.msg("投票开始");
            vote_result t = new vote_result();
            t.setVote(_vote);
            t.AddBoard(board);
            board.Replace(t);
        }

        private void fakeClick(object sender, RoutedEventArgs e) {
            startVote(null, null);
        }
    }
}
