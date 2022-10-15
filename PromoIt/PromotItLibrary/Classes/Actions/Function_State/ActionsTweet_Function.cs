using PromotItLibrary.Classes;
using PromotItLibrary.Enums;
using PromotItLibrary.Interfaces.Actions;
using PromotItLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns.Actions.Actions_Fuction_State
{
    public class ActionsTweet_Function : IActionsTweet
    {
        private readonly HTTPClient _httpClient;
        private readonly Tweet _tweet;

        public ActionsTweet_Function(Tweet tweet, HTTPClient httpClient)
        {
            _httpClient = httpClient;
            _tweet = tweet;
        }

        public async Task<bool> SetTweetCashAsync(Modes mode = null)
        {
            return (bool)await _httpClient.PostSingleDataInsert(Configuration.PromoitTweetFunctions, _tweet, "SetTweetCash");
        }
    }
}
