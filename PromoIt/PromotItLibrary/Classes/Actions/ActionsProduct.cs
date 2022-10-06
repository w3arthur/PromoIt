using PromotItLibrary.Classes;
using PromotItLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns.Actions
{
    public class ActionsProduct
    {

        private static MySQL mySQL;
        private HTTPClient httpClient;

        private ProductDonated _productDonated;
        private ProductInCampaign _productInCampaign;

        public ActionsProduct(ProductDonated productDonated, ProductInCampaign productInCampaign, MySQL _mySQL, HTTPClient _httpClient)
        {
            mySQL = _mySQL;
            httpClient = _httpClient;
            _productDonated = productDonated;
            _productInCampaign = productInCampaign;
        }


        public async Task SetTwitterMessagTweet_SetBuyAnItemAsync()
        {
            if (_productDonated == null) return;

            try
            {
                await Twitter.SetTwitterMessage_SetBuyAnItemAsync($"Product: {_productDonated.ProductInCampaign.Name}, Quantity {_productDonated.Quantity}" +
                    $"\nOrdered by Social Activist: @{_productDonated.ActivistUser.UserName}" +
                    $"\nFrom Business: {_productDonated.ProductInCampaign.BusinessUser.UserName}");
                Loggings.ReportLog($"Trying To Set a tweet for buying an item, Activist UserName ({_productDonated.ActivistUser.UserName}) CampaignName ({_productDonated.ProductInCampaign.Name}) BuisnessUserName ({_productDonated.ProductInCampaign.BusinessUser.UserName})" +
                    $"\nProductId ({_productDonated.ProductInCampaign.Id}) Quantity ({_productDonated.Quantity})");
            }
            catch
            {  //Twitter exeption
                Loggings.ErrorLog($"Some error to set a tweet for buying an item, Activist UserName ({_productDonated.ActivistUser.UserName}) CampaignName ({_productDonated.ProductInCampaign.Name}) BuisnessUserName ({_productDonated.ProductInCampaign.BusinessUser.UserName})" +
                    $"\nProductId ({_productDonated.ProductInCampaign.Id}) Quantity ({_productDonated.Quantity})");
            }
        }

        public async Task<bool> SetBuyAnItemAsync(Modes mode = null)
        {
            if (_productDonated == null) return false;

            try
            {   //Queue and Functions
                if ((mode ?? Configuration.Mode) == Modes.Queue)
                    return (bool)await httpClient.PostSingleDataInsert(Configuration.PromoitProductQueue, _productDonated, "SetBuyAnItem");
                else if ((mode ?? Configuration.Mode) == Modes.Functions)
                    return (bool)await httpClient.PostSingleDataInsert(Configuration.PromoitProductFunctions, _productDonated, "SetBuyAnItem");
            }
            catch { return false; }

            if ((mode ?? Configuration.DatabaseMode) == Modes.MySQL)
            {
                mySQL.Procedure("buy_a_product");
                mySQL.SetParameter("_product_id", _productDonated.ProductInCampaign.Id);
                mySQL.SetParameter("_quantity", _productDonated.Quantity);
                mySQL.SetParameter("_activist_user_name", _productDonated.ActivistUser.UserName);
                mySQL.SetParameter("_shipping", "not_shipped");
                return await mySQL.ProceduteExecuteAsync();
            }

            return false;
        }

        public async Task<bool> SetProductShippingAsync(Modes mode = null)
        {
            if (_productDonated == null) return false;

            try
            {   //Queue and Functions
                if ((mode ?? Configuration.Mode) == Modes.Queue)
                    return (bool)await httpClient.PostSingleDataInsert(Configuration.PromoitProductQueue, _productDonated, "SetProductShipping");
                else if ((mode ?? Configuration.Mode) == Modes.Functions)
                    return (bool)await httpClient.PostSingleDataInsert(Configuration.PromoitProductFunctions, _productDonated, "SetProductShipping");
            }
            catch { return false; }

            if ((mode ?? Configuration.DatabaseMode) == Modes.MySQL)
            {
                mySQL.Quary("UPDATE `promoit`.`products_donated` SET `shipped` = @_shipping WHERE (`id2` = @_donated_product_id);");
                mySQL.SetParameter("_donated_product_id", _productDonated.Id);
                mySQL.SetParameter("_shipping", "shipped");
                return await mySQL.ProceduteExecuteAsync();
            }

            return false;
        }

        public async Task<bool> SetNewProductAsync(Modes mode = null)
        {
            if (_productInCampaign == null) return false;

            try
            {   //Queue and Functions
                if ((mode ?? Configuration.Mode) == Modes.Queue)
                    return (bool)await httpClient.PostSingleDataInsert(Configuration.PromoitProductQueue, _productInCampaign, "SetNewProduct");
                else if ((mode ?? Configuration.Mode) == Modes.Functions)
                    return (bool)await httpClient.PostSingleDataInsert(Configuration.PromoitProductFunctions, _productInCampaign, "SetNewProduct");
            }
            catch { return false; }

            if ((mode ?? Configuration.DatabaseMode) == Modes.MySQL)
            {
                mySQL.Quary("INSERT INTO `promoit`.`products_in_campaign` (`name`, `quantity`, `price`, `business_user_name`, `campaign_hashtag`) VALUES (@_name, @_quantity, @_price, @_business_user_name, @_campaign_hashtag);");
                mySQL.SetParameter("_name", _productInCampaign.Name);
                mySQL.SetParameter("_quantity", decimal.Parse(_productInCampaign.Quantity));
                mySQL.SetParameter("_business_user_name", _productInCampaign.BusinessUser.UserName);
                mySQL.SetParameter("_price", int.Parse(_productInCampaign.Price));
                mySQL.SetParameter("_campaign_hashtag", _productInCampaign.Campaign.Hashtag);
                return await mySQL.ProceduteExecuteAsync();
            }
            return false;
        }


    }
}
