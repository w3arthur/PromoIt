using PromotItLibrary.Classes;
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
        private static MySQL mySQL;
        private HTTPClient httpClient;

        private Tweet _tweet;

        public ActionsTweet_MySql(Tweet tweet, MySQL _mySQL, HTTPClient _httpClient)
        {
            mySQL = _mySQL;
            _tweet = tweet;
        }

        public async Task<bool> SetTweetCashAsync()
        {
            mySQL.Procedure("add_tweet");
            mySQL.ProcedureParameter("_tweeter_id", long.Parse(_tweet.Id));
            mySQL.ProcedureParameter("_campaign_hashtag", _tweet.Campaign.Hashtag);
            mySQL.ProcedureParameter("_activist_user_name", _tweet.ActivistUser.UserName);
            mySQL.ProcedureParameter("_added_cash", _tweet.Cash);
            mySQL.ProcedureParameter("_tweeter_retweets", _tweet.Retweets);
            return await mySQL.ProceduteExecuteAsync();
        }
    }
}
