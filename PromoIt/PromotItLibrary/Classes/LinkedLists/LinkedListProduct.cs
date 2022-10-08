using MySql.Data.MySqlClient;
using PromotItLibrary.Classes;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns.Actions.Actions_Fuction_State;
using PromotItLibrary.Patterns.Actions.Actions_Interfaces;
using PromotItLibrary.Patterns.Actions.Actions_MySql_State;
using PromotItLibrary.Patterns.Actions.Actions_Queue_State;
using PromotItLibrary.Patterns.Actions;
using PromotItLibrary.Patterns.LinkedLists.LinkedList_Function_State.LinkedLists_Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromotItLibrary.Patterns.LinkedLists.Queue_State;
using PromotItLibrary.Patterns.LinkedLists.LinkedList_Function_State;
using PromotItLibrary.Patterns.LinkedLists.LinkedLists_MySql_State;
using PromotItLibrary.Enums;

namespace PromotItLibrary.Patterns.LinkedLists
{
    public class LinkedListProduct : ILinkedListProduct
    {

        private static MySQL mySQL;
        private HTTPClient httpClient;
        private ProductDonated _productDonated;
        private ProductInCampaign _productInCampaign;
        ILinkedListProduct linkedListProduct;

        public LinkedListProduct(ProductDonated productDonated, ProductInCampaign productInCampaign, MySQL _mySQL, HTTPClient _httpClient) 
        {
            mySQL = _mySQL;
            httpClient = _httpClient;
            _productDonated = productDonated;
            _productInCampaign = productInCampaign;
        }

        private ILinkedListProduct LinkedListMode(Modes _mode)
        {
            if ((_mode ?? Configuration.Mode) == Modes.Queue)
                linkedListProduct = new LinkedListProduct_Queue(_productDonated, _productInCampaign, mySQL, httpClient);
            else if ((_mode ?? Configuration.Mode) == Modes.Functions)
                linkedListProduct = new LinkedListProduct_Function(_productDonated, _productInCampaign, mySQL, httpClient);
            if ((_mode ?? Configuration.DatabaseMode) == Modes.MySQL)
                linkedListProduct = new LinkedListProduct_MySql(_productDonated, _productInCampaign, mySQL, httpClient);
            return linkedListProduct;
        }

        public async Task<List<ProductDonated>> GetDonatedProductForShipping_ListAsync(Modes mode = null)
        {
            if (_productDonated == null) return null;
            return await LinkedListMode(mode).GetDonatedProductForShipping_ListAsync();
        }

        public async Task<List<ProductInCampaign>> GetProductList_ListAsync(Modes mode = null)
        {
            if (_productInCampaign == null) return null;
            return await LinkedListMode(mode).GetProductList_ListAsync();
        }

    }
}
