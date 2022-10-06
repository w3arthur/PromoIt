using PromotItLibrary.Classes;
using PromotItLibrary.Enums;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns.Actions.Actions_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns.Actions.Actions_Queue_State
{
    public class ActionsProduct_Queue : IActionsProduct
    {

        private static MySQL mySQL;
        private HTTPClient httpClient;

        private ProductDonated _productDonated;
        private ProductInCampaign _productInCampaign;

        public ActionsProduct_Queue(ProductDonated productDonated, ProductInCampaign productInCampaign, MySQL _mySQL, HTTPClient _httpClient)
        {
            httpClient = _httpClient;
            _productDonated = productDonated;
            _productInCampaign = productInCampaign;
        }


        public async Task<bool> SetBuyAnItemAsync(Modes mode = null)
        {
            return (bool)await httpClient.PostSingleDataInsert(Configuration.PromoitProductQueue, _productDonated, "SetBuyAnItem");
        }

        public async Task<bool> SetProductShippingAsync(Modes mode = null)
        {
            return (bool)await httpClient.PostSingleDataInsert(Configuration.PromoitProductQueue, _productDonated, "SetProductShipping");
        }

        public async Task<bool> SetNewProductAsync(Modes mode = null)
        {
            return (bool)await httpClient.PostSingleDataInsert(Configuration.PromoitProductQueue, _productInCampaign, "SetNewProduct");
        }

    }
}
