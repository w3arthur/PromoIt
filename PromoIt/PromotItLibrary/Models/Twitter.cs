using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Parameters;


namespace PromotItLibrary.Models
{
    public class Twitter
    {
        private static TwitterClient twitterUserClient = Configuration.TwitterUserClient;

        //Twitter Message
        public static async Task SetTwitterMessage_SetBuyAnItemAsync(string message)
            => await twitterUserClient.Tweets.PublishTweetAsync(new PublishTweetParameters { Text = message, });
    }
}
