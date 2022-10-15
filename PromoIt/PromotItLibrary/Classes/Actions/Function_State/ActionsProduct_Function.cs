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
    public class ActionsProduct_Function : IActionsProduct_ProductDonated, IActionsProduct_ProductInCampaign
    {

        private readonly HTTPClient _httpClient;
        private readonly ProductDonated _productDonated;
        private readonly ProductInCampaign _productInCampaign;

        public ActionsProduct_Function(ProductDonated productDonated, HTTPClient httpClient)
        {
            _httpClient = httpClient;
            _productDonated = productDonated;
        }

        public ActionsProduct_Function(ProductInCampaign productInCampaign, HTTPClient httpClient)
        {
            _httpClient = httpClient;
            _productInCampaign = productInCampaign;
        }

        public async Task<bool> SetBuyAnItemAsync(Modes mode = null)
        {
            return (bool)await _httpClient.PostSingleDataInsert(Configuration.PromoitProductFunctions, _productDonated, "SetBuyAnItem");
        }

        public async Task<bool> SetProductShippingAsync(Modes mode = null)
        {
            return (bool)await _httpClient.PostSingleDataInsert(Configuration.PromoitProductFunctions, _productDonated, "SetProductShipping");
        }

        public async Task<bool> SetNewProductAsync(Modes mode = null)
        {
            return (bool)await _httpClient.PostSingleDataInsert(Configuration.PromoitProductFunctions, _productInCampaign, "SetNewProduct");
        }

    }
}
