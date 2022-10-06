using PromotItLibrary.Classes;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns.Actions.Actions_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns.Actions.Actions_Fuction_State
{
    public class ActionsTweet_Function : IActionsTweet
    {
        private static MySQL mySQL;
        private HTTPClient httpClient;

        private Tweet _tweet;

        public ActionsTweet_Function(Tweet tweet, MySQL _mySQL, HTTPClient _httpClient)
        {
            httpClient = _httpClient;
            _tweet = tweet;
        }

        public async Task<bool> SetTweetCashAsync(Modes mode = null)
        {
            return (bool)await httpClient.PostSingleDataInsert(Configuration.PromoitTweetFunctions, _tweet, "SetTweetCash");
        }
    }
}
