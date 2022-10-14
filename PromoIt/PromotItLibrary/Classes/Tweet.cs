using System;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using PromotItLibrary.Enums;
using PromotItLibrary.Interfaces;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns.Actions.Actions_Fuction_State;
using PromotItLibrary.Patterns.Actions.Actions_Interfaces;
using PromotItLibrary.Patterns.Actions.Actions_MySql_State;
using PromotItLibrary.Patterns.Actions.Actions_Queue_State;
using PromotItLibrary.Patterns.DataTables;
using PromotItLibrary.Patterns.DataTables.DataTables_Interfaces;
using PromotItLibrary.Patterns.LinkedLists.LinkedList_Function_State;
using PromotItLibrary.Patterns.LinkedLists.LinkedList_Function_State.LinkedLists_Interfaces;
using PromotItLibrary.Patterns.LinkedLists.LinkedLists_MySql_State;
using PromotItLibrary.Patterns.LinkedLists.Queue_State;


using ITweet = PromotItLibrary.Interfaces.ITweet;

namespace PromotItLibrary.Classes
{
    public class Tweet : ITweet, IActionsTweet, ILinkedListTweet
    {
        private readonly MySQL _mySQL = Configuration.MySQL;
        private readonly HTTPClient _httpClient = Configuration.HTTPClient;

        private readonly Modes _mode;
        private readonly IActionsTweet actionsTweet;
        private readonly ILinkedListTweet linkedListTweet;
        private readonly IDataTableTweet dataTableTweet;

        public string Id { get; set; }
        public ICampaign Campaign { get; set; }
        public IUsers ActivistUser { get; set; }
        public decimal Cash { get; set; }
        public int Retweets { get; set; }
        public bool IsApproved { get; set; }

        public Tweet()
        {
            //Actions States
            //LinkedList States
            if ((_mode ?? Configuration.Mode) == Modes.Queue)
            {
                actionsTweet = new ActionsTweet_Queue(this, _httpClient);
                linkedListTweet = new LinkedListTweet_Queue(this, _httpClient);
            }
            else if ((_mode ?? Configuration.Mode) == Modes.Functions)
            {
                actionsTweet = new ActionsTweet_Function(this, _httpClient);
                linkedListTweet = new LinkedListTweet_Function(this, _httpClient);
            }
            else if ((_mode ?? Configuration.DatabaseMode) == Modes.MySQL)
            {
                actionsTweet = new ActionsTweet_MySql(this, _mySQL);
                linkedListTweet = new LinkedListTweet_MySql(this, _mySQL);
            }

            //DataTable States ?
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
