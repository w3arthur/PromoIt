using PromotItLibrary.Classes;
using PromotItLibrary.Enums;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns.Actions.Actions_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns.Actions.Actions_Fuction_State
{
    public class ActionsProduct_Function : IActionsProduct
    {

        private static MySQL mySQL;
        private HTTPClient httpClient;

        private ProductDonated _productDonated;
        private ProductInCampaign _productInCampaign;

        public ActionsProduct_Function(ProductDonated productDonated, ProductInCampaign productInCampaign, MySQL _mySQL, HTTPClient _httpClient)
        {
            httpClient = _httpClient;
            _productDonated = productDonated;
            _productInCampaign = productInCampaign;
        }


        public async Task<bool> SetBuyAnItemAsync(Modes mode = null)
        {
            return (bool)await httpClient.PostSingleDataInsert(Configuration.PromoitProductFunctions, _productDonated, "SetBuyAnItem");
        }

        public async Task<bool> SetProductShippingAsync(Modes mode = null)
        {
            return (bool)await httpClient.PostSingleDataInsert(Configuration.PromoitProductFunctions, _productDonated, "SetProductShipping");
        }

        public async Task<bool> SetNewProductAsync(Modes mode = null)
        {
            return (bool)await httpClient.PostSingleDataInsert(Configuration.PromoitProductFunctions, _productInCampaign, "SetNewProduct");
        }

    }
}
