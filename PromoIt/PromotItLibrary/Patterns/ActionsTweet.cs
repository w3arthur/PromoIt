using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using PromotItLibrary.Classes;
using PromotItLibrary.Models;
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

        public ActionsTweet(Tweet tweet) => _tweet = tweet;

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

        public async Task<List<Tweet>> MySQL_GetAllTweets_ListAsync(Modes mode = null)
        {
            try
            {   //Queue and Functions
                if ((mode ?? Configuration.Mode) == Modes.Queue)
                    return await httpClient.GetMultipleDataRequest(Configuration.PromoitTweetQueue, _tweet, "GetAllTweets");
                else if ((mode ?? Configuration.Mode) == Modes.Functions)
                    return await httpClient.GetMultipleDataRequest(Configuration.PromoitTweetFunctions, _tweet, "GetAllTweets");
            }
            catch { return null; }

            if ((mode ?? Configuration.DatabaseMode) == Modes.MySQL)
            {
                List<Tweet> tweetList = new List<Tweet>();
                mySQL.Quary("SELECT campaign_hashtag,activist_user_name,retweets FROM tweets");
                using MySqlDataReader results = await mySQL.GetQueryMultyResultsAsync();
                while (results != null && results.Read()) //for 1 result: if (mdr.Read())
                {
                    try
                    {
                        tweetList.Add
                            (
                                new Tweet()
                                {
                                    Campaign = new Campaign() { Hashtag = results.GetString("campaign_hashtag"), },
                                    ActivistUser = new ActivistUser() { UserName = results.GetString("activist_user_name"), },
                                    Retweets = int.Parse(results.GetString("retweets")),
                                }
                            );
                    }
                    catch { };
                }
                return tweetList;
            }

            return null;
        }

        public async Task<DataTable> GetAllTweets_DataTableAsync()
        {
            DataTable dataTable = new DataTable();
            List<Tweet> tweetList = await MySQL_GetAllTweets_ListAsync();
            foreach (string culmn in new[] { "Hashtag", "UserName", "Retweets" })
                dataTable.Columns.Add(culmn);

            if (tweetList == null)
            {
                while (Configuration.IsTries())
                    return await new ActionsTweet(_tweet).GetAllTweets_DataTableAsync();
                Loggings.ErrorLog($"Admin Requested to get all Tweets list, The list is empty, Reguested by ({Configuration.CorrentUser.UserName})");
                Configuration.TriesReset();
                return dataTable;//no results
            }
            Configuration.TriesReset();

            Loggings.TweeterLogs.LogInformation($"Tweet List, Reguested by ({Configuration.CorrentUser.UserName})");
            foreach (Tweet tweet in tweetList)
            {
                DataRow dataRow = dataTable.NewRow();
                foreach (var (key, value) in new[] { ("Hashtag", tweet.Campaign.Hashtag), ("UserName", tweet.ActivistUser.UserName), ("Retweets", tweet.Retweets.ToString()) }) dataRow[key] = value;
                dataTable.Rows.Add(dataRow);
                Loggings.TweeterLogs.LogInformation($"Tweet Campaign Hashtag (#{tweet.Campaign.Hashtag}) UserName ({tweet.ActivistUser.UserName}) Retweets ({tweet.Retweets})");
            }

            Loggings.TweeterLogs.LogInformation($"Report end");

            Loggings.ReportLog($"Admin Requested to get all Tweets list, Reguested by ({Configuration.CorrentUser.UserName})");

            return dataTable;
        }

    }
}
