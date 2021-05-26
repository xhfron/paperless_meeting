using pm_client.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace pm_client.view {
    public class VotePages {
        public static Dictionary<Vote, vote> startingPage = new Dictionary<Vote, vote>();
        public static Dictionary<Vote, vote_result> resultPage = new Dictionary<Vote, vote_result>();
        public static vote getStartingPage(Vote vote) {
            if (!startingPage.ContainsKey(vote)) {
                vote v = new vote();
                v.setVote(vote);
                startingPage[vote] = v;
            }
            return startingPage[vote];
        }
        public static vote_result getResultPage(Vote vote) {
            if (!resultPage.ContainsKey(vote)) {
                vote_result vote_Result = new vote_result();
                vote_Result.setVote(vote);
                resultPage[vote] = vote_Result;
            }
            return resultPage[vote];
        }

    }
}
