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

namespace PromotItLibrary.Patterns.LinkedLists.LinkedList_Function_State
{
    public class LinkedListProduct_Function : ILinkedListProduct_ProductDonated, ILinkedListProduct_ProductInCampaign
    {

        private readonly HTTPClient _httpClient;
        private readonly ProductDonated _productDonated;
        private readonly ProductInCampaign _productInCampaign;

        public LinkedListProduct_Function(ProductDonated productDonated, HTTPClient httpClient) 
        {
            _httpClient = httpClient;
            _productDonated = productDonated;
        }


        public LinkedListProduct_Function(ProductInCampaign productInCampaign, HTTPClient httpClient)
        {
            _httpClient = httpClient;
            _productInCampaign = productInCampaign;
        }


        public async Task<List<ProductDonated>> GetDonatedProductForShipping_ListAsync(Modes mode = null)
        {
            return await _httpClient.GetMultipleDataRequest(Configuration.PromoitProductFunctions, _productDonated, "GetDonatedProductForShipping");
        }

        public async Task<List<ProductInCampaign>> GetProductList_ListAsync(Modes mode = null)
        {
            return await _httpClient.GetMultipleDataRequest(Configuration.PromoitProductFunctions, _productInCampaign, "GetProductList");
        }

    }
}
