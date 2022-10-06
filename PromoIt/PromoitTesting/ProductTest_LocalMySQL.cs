using Moq;
using PromoitTesting.TestClasses;
using PromotItLibrary.Classes;
using PromotItLibrary.Enums;
using PromotItLibrary.Interfaces;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PromoitTesting
{


    public class ProductTest_LocalMySQL
    {

        private MySQL mySQL = Configuration.MySQL;

        [Fact]
        public async Task Functions_MySQLUserRegisterLoginAsync()
        {
            Modes currentMode = Configuration.Mode;
            Modes currentLocalMode = Configuration.LocalMode;
            Modes currentLocalDatabase = Configuration.DatabaseMode;
            Configuration.Mode = Modes.Null;
            Configuration.LocalMode = Modes.Local;
            Configuration.DatabaseMode = Modes.MySQL;

            ProductInCampaign productInCampaign = new ProductInCampaign()
            {
                Name = "SomeTestedName",
                Quantity = "45",
                Price = "45",
                BusinessUser = new BusinessUser() { UserName = "b", },      //Awailable User
                Campaign = new Campaign { Hashtag = "nisayon", },      //Awailable  Hashtag
            };

            bool result1 = await productInCampaign.SetNewProductAsync();

            Assert.True(result1, "Campaign Should Entered to Database");

            await mySQL.QuaryExecuteAsync($"DELETE FROM `promoit`.`products_in_campaign` WHERE(`name` = '{productInCampaign.Name}');");

            //return to set values
            Configuration.Mode = currentMode;
            Configuration.LocalMode = currentLocalMode;
            Configuration.DatabaseMode = currentLocalDatabase;
        }

    }
}
