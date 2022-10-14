using PromotItLibrary.Classes;
using PromotItLibrary.Enums;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns.Actions.Actions_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns.Actions.Actions_MySql_State
{
    public class ActionsTweet_MySql : IActionsTweet
    {
        private readonly MySQL _mySQL;
        private readonly Tweet _tweet;

        public ActionsTweet_MySql(Tweet tweet, MySQL mySQL)
        {
            _mySQL = mySQL;
            _tweet = tweet;
        }

        public async Task<bool> SetTweetCashAsync(Modes mode = null)
        {
            _mySQL.Procedure("add_tweet");
            _mySQL.ProcedureParameter("_tweeter_id", long.Parse(_tweet.Id));
            _mySQL.ProcedureParameter("_campaign_hashtag", _tweet.Campaign.Hashtag);
            _mySQL.ProcedureParameter("_activist_user_name", _tweet.ActivistUser.UserName);
            _mySQL.ProcedureParameter("_added_cash", _tweet.Cash);
            _mySQL.ProcedureParameter("_tweeter_retweets", _tweet.Retweets);
            return await _mySQL.ProceduteExecuteAsync();
        }
    }
}
