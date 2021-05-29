using Newtonsoft.Json;
using pm_client.util;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace pm_client.view {
    /// <summary>
    /// vote.xaml 的交互逻辑
    /// </summary>
    public partial class vote : UserControl {
        static Dictionary<int, List<int>> localVotingResult;
        INavigator board;
        public void AddBoard(INavigator board) {
            this.board = board;
        }
        util.Vote _vote;
        public void setVote(util.Vote vote) {
            this._vote = vote;
            this.DataContext = vote;
            if (localVotingResult == null) {
                FileInfo file=new FileInfo(Path.Combine(Settings.tempDir,"xxx"));
                if (file.Exists) {
                    var reader = file.OpenText();
                    localVotingResult = JsonConvert.DeserializeObject<Dictionary<int, List<int>>>(reader.ReadToEnd());
                    reader.Close();
                } else {
                    localVotingResult = new Dictionary<int, List<int>>();
                }
            }
            if (localVotingResult.ContainsKey(vote.uid)) {
                List<int> selectedCid = localVotingResult[vote.uid];
                foreach (var c in this.choiceListBox.ItemsSource) {
                    VoteOption choice = (VoteOption)c;
                    if (selectedCid.Contains(choice.uid)) {
                        this.choiceListBox.SelectedItems.Add(choice);
                    }
                }
                this.choiceListBox.IsEnabled = false;
                this.userBtn.Visibility = Visibility.Hidden;
            }
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
                localVotingResult[_vote.uid] = new List<int>();
                foreach (var c in this.choiceListBox.SelectedItems) {
                    VoteOption choice = (VoteOption)c;
                    localVotingResult[_vote.uid].Add(choice.uid);
                    submitOption(_vote.uid, choice.uid, WebUtil.getDeviceId());
                }

                DirectoryInfo directoryInfo = new DirectoryInfo(Settings.tempDir);
                if (!directoryInfo.Exists) {
                    directoryInfo.Create();
                }
                FileInfo file = new FileInfo(Path.Combine(Settings.tempDir, "xxx"));
                byte[] data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(localVotingResult));
                FileStream writer = file.OpenWrite();
                writer.Write(data, 0, data.Length);
                writer.Close();

                ViewUtil.msg("投票成功");
                this.choiceListBox.IsEnabled = false;
                this.userBtn.Visibility = Visibility.Collapsed;
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
