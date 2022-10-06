using PromotItLibrary.Classes;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns.Actions.Actions_Fuction_State;
using PromotItLibrary.Patterns.Actions.Actions_Interfaces;
using PromotItLibrary.Patterns.Actions.Actions_MySql_State;
using PromotItLibrary.Patterns.Actions.Actions_Queue_State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns.Actions
{
    public class ActionsTweet : IActionsTweet
    {
        private static MySQL mySQL;
        private HTTPClient httpClient;
        private Tweet _tweet;
        IActionsTweet actionsTweet;

        public ActionsTweet(Tweet tweet, MySQL _mySQL, HTTPClient _httpClient)
        {
            mySQL = _mySQL;
            httpClient = _httpClient;
            _tweet = tweet;
        }
        private IActionsTweet ActionMode(Modes _mode)
        {
            if ((_mode ?? Configuration.Mode) == Modes.Queue)
                actionsTweet = new ActionsTweet_Queue(_tweet, mySQL, httpClient);
            else if ((_mode ?? Configuration.Mode) == Modes.Functions)
                actionsTweet = new ActionsTweet_Function(_tweet, mySQL, httpClient);
            if ((_mode ?? Configuration.DatabaseMode) == Modes.MySQL)
                actionsTweet = new ActionsTweet_MySql(_tweet, mySQL, httpClient);
            return actionsTweet;
        }

        public async Task<bool> SetTweetCashAsync(Modes mode = null)
        {
            return await ActionMode(mode).SetTweetCashAsync();
        }
    }
}
