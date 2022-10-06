using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using PromotItLibrary.Classes;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns.LinkedLists.LinkedList_Function_State.LinkedLists_Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns.LinkedLists.LinkedLists_MySql_State
{
    public class LinkedListTweet_MySql : ILinkedListTweet
    {

        private static MySQL mySQL;
        private HTTPClient httpClient;
        private Tweet _tweet;

        public LinkedListTweet_MySql(Tweet tweet, MySQL _mySQL, HTTPClient _httpClient) 
        {
            mySQL = _mySQL;
            httpClient = _httpClient;
            _tweet = tweet;
        }

        public async Task<List<Tweet>> MySQL_GetAllTweets_ListAsync(Modes mode = null)
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


    }
}
