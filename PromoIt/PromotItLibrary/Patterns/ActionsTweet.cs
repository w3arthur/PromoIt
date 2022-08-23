using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using PromotItLibrary.Classes;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns.DataTables;
using PromotItLibrary.Patterns.LinkedLists;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns
{
    public class ActionsTweet
    {
        private static MySQL mySQL = Configuration.MySQL;
        private HTTPClient httpClient = Configuration.HTTPClient;

        private Tweet _tweet;

        private LinkedListTweet linkedListTweet;
        private DataTableTweet dataTableTweet;

        private List<Tweet> _tweetList;
        private DataTable _tweetTable;
        private string _logMessahe;
        private bool _result;

        /*
        public T Builder<T>(T _log){
            if (_logMessahe) return T;
            return T;
        }*/

        public ActionsTweet(Tweet tweet) 
        {
            linkedListTweet = new LinkedListTweet(tweet, mySQL, httpClient);
            dataTableTweet = new DataTableTweet(tweet);
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

        public async Task<List<Tweet>> MySQL_GetAllTweets_ListAsync(Modes mode = null) =>
            await linkedListTweet.MySQL_GetAllTweets_ListAsync(mode);

        public async Task<DataTable> GetAllTweets_DataTableAsync() =>
            await dataTableTweet.GetAllTweets_DataTableAsync();

    }
}
