using PromotItLibrary.Classes;
using PromotItLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns.Actions
{
    public class ActionsTweet
    {
        private static MySQL mySQL;
        private HTTPClient httpClient;

        private Tweet _tweet;

        public ActionsTweet(Tweet tweet, MySQL _mySQL, HTTPClient _httpClient)
        {
            mySQL = _mySQL;
            httpClient = _httpClient;
            _tweet = tweet;
        }

        public async Task<bool> SetTweetCashAsync(Modes mode = null)
        {
            try
            {   //Queue and Functions
                if ((mode ?? Configuration.Mode) == Modes.Queue)
                    return (bool)await httpClient.PostSingleDataInsert(Configuration.PromoitTweetQueue, _tweet, "SetTweetCash");
                else if ((mode ?? Configuration.Mode) == Modes.Functions)
                    return (bool)await httpClient.PostSingleDataInsert(Configuration.PromoitTweetFunctions, _tweet, "SetTweetCash");
            }
            catch { return false; }

            if ((mode ?? Configuration.DatabaseMode) == Modes.MySQL)
            {
                mySQL.Procedure("add_tweet");
                mySQL.ProcedureParameter("_tweeter_id", long.Parse(_tweet.Id));
                mySQL.ProcedureParameter("_campaign_hashtag", _tweet.Campaign.Hashtag);
                mySQL.ProcedureParameter("_activist_user_name", _tweet.ActivistUser.UserName);
                mySQL.ProcedureParameter("_added_cash", _tweet.Cash);
                mySQL.ProcedureParameter("_tweeter_retweets", _tweet.Retweets);
                return await mySQL.ProceduteExecuteAsync();
            }
            return false;
        }
    }
}
