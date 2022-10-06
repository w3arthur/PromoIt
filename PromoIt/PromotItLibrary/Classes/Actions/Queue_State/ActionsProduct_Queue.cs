using PromotItLibrary.Classes;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns.Actions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns.Actions.Queue_State
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


        public async Task<bool> SetBuyAnItemAsync()
        {
            return (bool)await httpClient.PostSingleDataInsert(Configuration.PromoitProductQueue, _productDonated, "SetBuyAnItem");
        }

        public async Task<bool> SetProductShippingAsync()
        {
            return (bool)await httpClient.PostSingleDataInsert(Configuration.PromoitProductQueue, _productDonated, "SetProductShipping");
        }

        public async Task<bool> SetNewProductAsync()
        {
            return (bool)await httpClient.PostSingleDataInsert(Configuration.PromoitProductQueue, _productInCampaign, "SetNewProduct");
        }

    }
}
