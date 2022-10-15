using Moq;
using PromoitTesting.TestClasses;
using PromotItLibrary.Classes;
using PromotItLibrary.Interfaces;
using PromotItLibrary.Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Tweetinvi;
using Tweetinvi.Parameters;
using PromotItLibrary.Patterns;
using PromotItLibrary.Classes.Users;

namespace PromoitTesting
{

    public class Tweet_TwitterTest
    {

        private static TwitterClient twitterUserClient = Configuration.TwitterUserClient;

        private static string guidNumber = Guid.NewGuid().ToString("n");

        [Fact]
        public async Task Tweet_Twitter_Test()
        {
            ProductDonated productDonated = new ProductDonated()
            {
                Quantity = "-",
                ActivistUser = new ActivistUser() { UserName = "Testing Procces For Twitter Addd", },
                ProductInCampaign = new ProductInCampaign()
                {
                    Name = "#" + guidNumber,  //instead # next when search
                    Id = "-",
                    BusinessUser = new BusinessUser() { UserName = "-", },
                },
            };

            await productDonated.SetTwitterMessagTweet_SetBuyAnItemAsync();

            int attempts = 10;
            bool isAtweet = false;
            var searchIterator = twitterUserClient.SearchV2.GetSearchTweetsV2Iterator(productDonated.ProductInCampaign.Name);  //#
            while (!searchIterator.Completed)
            {
                try
                {
                    var searchPage = await searchIterator.NextPageAsync();
                    if (searchPage.Content.Tweets.Length >= 1) { isAtweet = true; }
                    break;
                }
                catch { if (attempts-- <= 0) { break; } }
            }

            Assert.True(isAtweet, "Tweet Shoul Sert And found here https://twitter.com/MalulYaron");

        }

    }
}
