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
    public partial class vote_list_view : UserControl, MessageListener {
        List<util.Vote> list;
        List<util.Vote> listToShow=new List<Vote>();

        #region util

        INavigator board;
        public void AddBoard(INavigator board) {
            this.board = board;
        }
        public vote_list_view() {
            InitializeComponent();
        }

        #endregion

        public void setVoteList(List<util.Vote> list) {
            if (list == null) return;
            this.list = list;
            if (ViewUtil.Find<Role>(this, "role").name.Contains("主持人")) {
                listToShow = list;
            } else {
                foreach (var v in list) if (v.state == Vote.VOTING) listToShow.Add(v);
                foreach (var v in list) if (v.state == Vote.VOTED) listToShow.Add(v);
            }
            this.VoteListViewVoteList.ItemsSource = listToShow;
        }


        private void toVoteDetail(object sender, SelectionChangedEventArgs e) {
            Vote selected = (Vote)this.VoteListViewVoteList.SelectedItem;
            if (selected == null) {
                return; //不懂为什么会调用两次，设置selected的时候也触发了？
            }
            if (ViewUtil.Find<Role>(this, "role").name != "主持人") {
                if (selected.state == Vote.IDLE) {
                    ViewUtil.msg("投票尚未开始");
                } else if (selected.state == Vote.VOTED) {
                    ViewUtil.msg("投票已结束");
                } else {
                    vote v = (vote)VotePages.getStartingPage(selected);
                    v.AddBoard(this.board);
                    board.Push(v);
                }
            } else {
                if (selected.state == Vote.IDLE) {
                    vote v = (vote)VotePages.getStartingPage(selected);
                    v.AddBoard(this.board);
                    board.Push(v);
                } else {
                    vote_result vote_Result = VotePages.getResultPage(selected);
                    vote_Result.AddBoard(this.board);
                    board.Push(vote_Result);
                }
            }
            this.VoteListViewVoteList.SelectedItem = null;
        }

        public void onMessage(Dictionary<string, object> json) {
            Log.l("vote list", json.ToString());
            string cmd = (string)json["cmd"];
            if (cmd.Contains("结束投票")) {
                int idx = cmd.IndexOf(":");
                int voteId = Int32.Parse(cmd.Substring(idx + 1));
                List<util.Vote> list = (List<Vote>)this.VoteListViewVoteList.ItemsSource;
                foreach (util.Vote v in list) {
                    if (v.uid == voteId) {
                        v.state = Vote.VOTED;
                        return;
                    }
                }
                ViewUtil.msg("vote not found");
            } else if (cmd.Contains("开始投票")) {
                if(ViewUtil.Find<Role>(this, "role").name.Contains("主持人")) {
                    int idx = cmd.IndexOf(":");
                    int voteId = Int32.Parse(cmd.Substring(idx + 1));
                    List<util.Vote> list = (List<Vote>)this.VoteListViewVoteList.ItemsSource;
                    foreach (util.Vote v in list) {
                        if (v.uid == voteId) {
                            v.state = Vote.VOTING;
                            return;
                        }
                    }
                    ViewUtil.msg("vote not found");
                } else {
                    int idx = cmd.IndexOf(":");
                    int voteId = Int32.Parse(cmd.Substring(idx + 1));
                    List<util.Vote> list = (List<Vote>)this.VoteListViewVoteList.ItemsSource;
                    Vote vote = null, voteShowing = null;
                    foreach (util.Vote v in this.list) {
                        if (v.uid == voteId) {
                            vote = v;
                            break;
                        }
                    }
                    foreach (util.Vote v in list) {
                        if (v.uid == voteId) {
                            voteShowing = v;
                            break;
                        }
                    }
                    if (voteShowing == null) {
                        list.Insert(0, vote);
                        vote.state = Vote.VOTING;
                        this.UpdateLayout();
                    }
                    ViewUtil.msg("vote not found");
                }
            }
        }
    }
}
