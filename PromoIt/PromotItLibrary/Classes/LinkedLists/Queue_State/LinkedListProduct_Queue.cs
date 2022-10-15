using MySql.Data.MySqlClient;
using PromotItLibrary.Classes;
using PromotItLibrary.Enums;
using PromotItLibrary.Interfaces.LinkedList;
using PromotItLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns.LinkedLists.Queue_State
{
    public class LinkedListProduct_Queue : ILinkedListProduct_ProductDonated, ILinkedListProduct_ProductInCampaign
    {

        private readonly HTTPClient _httpClient;
        private readonly ProductDonated _productDonated;
        private readonly ProductInCampaign _productInCampaign;

        public LinkedListProduct_Queue(ProductDonated productDonated, HTTPClient _httpClient) 
        {
            this._httpClient = _httpClient;
            _productDonated = productDonated;
        }

        public LinkedListProduct_Queue(ProductInCampaign productInCampaign, HTTPClient _httpClient)
        {
            this._httpClient = _httpClient;
            _productInCampaign = productInCampaign;
        }


        public async Task<List<ProductDonated>> GetDonatedProductForShipping_ListAsync(Modes mode = null)
        {
            return await _httpClient.GetMultipleDataRequest(Configuration.PromoitProductQueue, _productDonated, "GetDonatedProductForShipping");
        }

        public async Task<List<ProductInCampaign>> GetProductList_ListAsync(Modes mode = null)
        {
            return await _httpClient.GetMultipleDataRequest(Configuration.PromoitProductQueue, _productInCampaign, "GetProductList");
        }

    }
}
