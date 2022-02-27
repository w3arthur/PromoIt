using PromotItLibrary.Classes;
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
        private Tweet _tweet;

        public ActionsTweet(Tweet tweet) => _tweet = tweet;

        public async Task<bool> SetTweetCashAsync(Modes mode = null)
        {
            return await _tweet.SetTweetCashAsync(mode);
        }

        public async Task<List<Tweet>> MySQL_GetAllTweets_ListAsync(Modes mode = null)
        {
            return await _tweet.MySQL_GetAllTweets_ListAsync(mode);
        }

        public async Task<DataTable> GetAllTweets_DataTableAsync()
        {
            return await _tweet.GetAllTweets_DataTableAsync();
        }




    }
}
