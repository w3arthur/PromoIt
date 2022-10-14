using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using PromotItLibrary.Classes;
using PromotItLibrary.Enums;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns.LinkedLists.LinkedList_Function_State;
using PromotItLibrary.Patterns.LinkedLists.LinkedList_Function_State.LinkedLists_Interfaces;
using PromotItLibrary.Patterns.LinkedLists.LinkedLists_MySql_State;
using PromotItLibrary.Patterns.LinkedLists.Queue_State;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns.LinkedLists
{
    public class LinkedListTweet : ILinkedListTweet
    {

        private static MySQL mySQL;
        private HTTPClient httpClient;
        private Tweet _tweet;
        ILinkedListTweet linkedListTweet;

        public LinkedListTweet(Tweet tweet, MySQL _mySQL, HTTPClient _httpClient) 
        {
            mySQL = _mySQL;
            httpClient = _httpClient;
            _tweet = tweet;
        }

        private ILinkedListTweet LinkedListMode(Modes _mode)
        {
            if ((_mode ?? Configuration.Mode) == Modes.Queue)
                linkedListTweet = new LinkedListTweet_Queue(_tweet, mySQL, httpClient);
            else if ((_mode ?? Configuration.Mode) == Modes.Functions)
                linkedListTweet = new LinkedListTweet_Function(_tweet, mySQL, httpClient);
            if ((_mode ?? Configuration.DatabaseMode) == Modes.MySQL)
                linkedListTweet = new LinkedListTweet_MySql(_tweet, mySQL, httpClient);
            return linkedListTweet;
        }

        public async Task<List<Tweet>> GetAllTweets_ListAsync(Modes mode = null)
        {
            return await LinkedListMode(mode).GetAllTweets_ListAsync();
        }


    }
}
