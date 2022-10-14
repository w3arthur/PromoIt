using PromotItLibrary.Classes;
using PromotItLibrary.Enums;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns.Actions.Actions_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns.Actions.Actions_Queue_State
{
    public class ActionsTweet_Queue : IActionsTweet
    {
        private readonly HTTPClient _httpClient;
        private readonly Tweet _tweet;

        public ActionsTweet_Queue(Tweet tweet, HTTPClient httpClient)
        {
            _httpClient = httpClient;
            _tweet = tweet;
        }

        public async Task<bool> SetTweetCashAsync(Modes mode = null)
        {
            return (bool)await _httpClient.PostSingleDataInsert(Configuration.PromoitTweetQueue, _tweet, "SetTweetCash");
        }
    }
}
