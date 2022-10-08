using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using PromotItLibrary.Enums;
using PromotItLibrary.Interfaces;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns;
using PromotItLibrary.Patterns.Actions;
using PromotItLibrary.Patterns.Actions.Actions_Interfaces;
using PromotItLibrary.Patterns.DataTables;
using PromotItLibrary.Patterns.LinkedLists;
using PromotItLibrary.Patterns.LinkedLists.LinkedList_Function_State.LinkedLists_Interfaces;
using System;
using System.Collections.Generic;

using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi.Core.Models;

namespace PromotItLibrary.Classes
{
    public class Tweet : ITweet, IActionsTweet, ILinkedListTweet
    {
        private static MySQL mySQL = Configuration.MySQL;
        private HTTPClient httpClient = Configuration.HTTPClient;

        private LinkedListTweet linkedListTweet;
        private DataTableTweet dataTableTweet;
        private ActionsTweet actionsTweet;

        public string Id { get; set; }
        public ICampaign Campaign { get; set; }
        public IUsers ActivistUser { get; set; }
        public decimal Cash { get; set; }
        public int Retweets { get; set; }
        public bool IsApproved { get; set; }

        public Tweet()
        {
            actionsTweet = new ActionsTweet( this, mySQL, httpClient);
            linkedListTweet = new LinkedListTweet(this, mySQL, httpClient);
            dataTableTweet = new DataTableTweet(this);
        }

        //Actions
        public async Task<bool> SetTweetCashAsync(Modes mode = null) =>
            await actionsTweet.SetTweetCashAsync(mode);

        //LinkedList
        public async Task<List<Tweet>> GetAllTweets_ListAsync(Modes mode = null) =>
            await linkedListTweet.GetAllTweets_ListAsync(mode);

        //DataTable
        public async Task<DataTable> GetAllTweets_DataTableAsync() =>
            await dataTableTweet.GetAllTweets_DataTableAsync();


    }
}
