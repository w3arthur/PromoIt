using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using PromotItLibrary.Classes;
using PromotItLibrary.Enums;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns.LinkedLists.LinkedList_Function_State.LinkedLists_Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns.LinkedLists.LinkedList_Function_State
{
    public class LinkedListTweet_Function : ILinkedListTweet
    {

        private readonly HTTPClient _httpClient;
        private readonly Tweet _tweet;

        public LinkedListTweet_Function(Tweet tweet, HTTPClient _httpClient) 
        {
            this._httpClient = _httpClient;
            _tweet = tweet;
        }

        public async Task<List<Tweet>> GetAllTweets_ListAsync(Modes mode = null)
        {
            return await _httpClient.GetMultipleDataRequest(Configuration.PromoitTweetFunctions, _tweet, "GetAllTweets");
        }


    }
}
