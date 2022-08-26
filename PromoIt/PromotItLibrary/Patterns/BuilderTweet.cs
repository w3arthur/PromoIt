using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using PromotItLibrary.Classes;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns.Actions;
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
    public class BuilderTweet
    {
        private static MySQL mySQL = Configuration.MySQL;
        private HTTPClient httpClient = Configuration.HTTPClient;

        private Tweet _tweet;

        private LinkedListTweet linkedListTweet;
        private DataTableTweet dataTableTweet;
        private ActionsTweet actionsTweet;

        //private List<Tweet> _tweetList;
        //private DataTable _tweetTable;
        //private string _logMessahe;
        //private bool _result;
        public BuilderTweet(Tweet tweet)
        {
            linkedListTweet = new LinkedListTweet(tweet, mySQL, httpClient);
            dataTableTweet = new DataTableTweet(tweet);
            _tweet = tweet;
        }
        /*
        public T Builder<T>(T _log){
            if (_logMessahe) return T;
            return T;
        }*/


        //Actions
        public async Task<bool> SetTweetCashAsync(Modes mode = null) =>
            await actionsTweet.SetTweetCashAsync(mode);
        
        //LinkedList and DataTable
        public async Task<List<Tweet>> MySQL_GetAllTweets_ListAsync(Modes mode = null) =>
            await linkedListTweet.MySQL_GetAllTweets_ListAsync(mode);
        public async Task<DataTable> GetAllTweets_DataTableAsync() =>
            await dataTableTweet.GetAllTweets_DataTableAsync();

    }
}
