using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using PromotItLibrary.Classes;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns.DataTables.DataTables_Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns.DataTables
{
    public  class DataTableTweet : IDataTableTweet
    {
        private readonly Tweet _tweet;

        public DataTableTweet(Tweet tweet) 
        {
            _tweet = tweet;
        }

        public async Task<DataTable> GetAllTweets_DataTableAsync()
        {
            DataTable dataTable = new DataTable();
            List<Tweet> tweetList = await _tweet.GetAllTweets_ListAsync();
            foreach (string culmn in new[] { "Hashtag", "UserName", "Retweets" })
                dataTable.Columns.Add(culmn);

            if (tweetList == null)
            {
                while (Configuration.IsTries())
                    return await _tweet.GetAllTweets_DataTableAsync();
                Loggings.ErrorLog($"Admin Requested to get all Tweets list, The list is empty, Reguested by ({Configuration.CorrentUser.UserName})");
                Configuration.TriesReset();
                return dataTable;//no results
            }
            Configuration.TriesReset();

            //???
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
