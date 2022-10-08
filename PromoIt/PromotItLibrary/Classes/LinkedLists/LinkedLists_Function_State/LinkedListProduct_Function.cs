using MySql.Data.MySqlClient;
using PromotItLibrary.Classes;
using PromotItLibrary.Enums;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns.LinkedLists.LinkedList_Function_State.LinkedLists_Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns.LinkedLists.LinkedList_Function_State
{
    public class LinkedListProduct_Function : ILinkedListProduct, ILinkedListProduct_ProductDonated
    {

        private static MySQL mySQL;
        private HTTPClient httpClient;
        private ProductDonated _productDonated;
        private ProductInCampaign _productInCampaign;

        public LinkedListProduct_Function(ProductDonated productDonated, ProductInCampaign productInCampaign, MySQL _mySQL, HTTPClient _httpClient) 
        {
            mySQL = _mySQL;
            httpClient = _httpClient;
            _productDonated = productDonated;
            _productInCampaign = productInCampaign;
        }


        public async Task<List<ProductDonated>> GetDonatedProductForShipping_ListAsync(Modes mode = null)
        {
            return await httpClient.GetMultipleDataRequest(Configuration.PromoitProductFunctions, _productDonated, "GetDonatedProductForShipping");
        }

        public async Task<List<ProductInCampaign>> GetProductList_ListAsync(Modes mode = null)
        {
            return await httpClient.GetMultipleDataRequest(Configuration.PromoitProductFunctions, _productInCampaign, "GetProductList");
        }

    }
}
