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
    public class ActionsProduct : IActionsProduct
    {

        private static MySQL mySQL;
        private HTTPClient httpClient;
        private ProductDonated _productDonated;
        private ProductInCampaign _productInCampaign;
        IActionsProduct actionsProduct;

        public ActionsProduct(ProductDonated productDonated, ProductInCampaign productInCampaign, MySQL _mySQL, HTTPClient _httpClient)
        {
            mySQL = _mySQL;
            httpClient = _httpClient;
            _productDonated = productDonated;
            _productInCampaign = productInCampaign;
        }

        private IActionsProduct ActionMode(Modes _mode)
        {
            if ((_mode ?? Configuration.Mode) == Modes.Queue)
                actionsProduct = new ActionsProduct_Queue(_productDonated, _productInCampaign, mySQL, httpClient);
            else if ((_mode ?? Configuration.Mode) == Modes.Functions)
                actionsProduct = new ActionsProduct_Function(_productDonated, _productInCampaign, mySQL, httpClient);
            if ((_mode ?? Configuration.DatabaseMode) == Modes.MySQL)
                actionsProduct = new ActionsProduct_MySql(_productDonated, _productInCampaign, mySQL, httpClient);
            return actionsProduct;
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
            return await ActionMode(mode).SetBuyAnItemAsync();
        }

        public async Task<bool> SetProductShippingAsync(Modes mode = null)
        {
            if (_productDonated == null) return false;
            return await ActionMode(mode).SetProductShippingAsync();
        }

        public async Task<bool> SetNewProductAsync(Modes mode = null)
        {
            if (_productInCampaign == null) return false;
            return await ActionMode(mode).SetNewProductAsync();
        }


    }
}
