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
    /// vote_result_detail.xaml 的交互逻辑
    /// </summary>
    public partial class vote_result_detail : UserControl
    {
        public vote_result_detail()
        {
            InitializeComponent();
        }
        public void setVoteResultDetail(util.VoteResult voteResult,Vote vote,ChoiceResultViewData r) {
            this.fooBar.DataContext = r;
            this.hahaha.DataContext = vote;
            if (vote.anonymous == 0) {
                this.padContainer.Children.Clear();
                foreach(string pad in voteResult.devices) {
                    Button button = new Button();
                    button.Style = (Style)this.Resources["padBlockStyle"];
                    button.DataContext = pad;
                    button.Content = pad;
                    this.padContainer.Children.Add(button);
                }
            }
        }
    }
}
