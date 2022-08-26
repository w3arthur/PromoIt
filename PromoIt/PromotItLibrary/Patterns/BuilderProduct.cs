using MySql.Data.MySqlClient;
using PromotItLibrary.Classes;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns.LinkedLists;
using PromotItLibrary.Patterns.DataTables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromotItLibrary.Patterns.Actions;

namespace PromotItLibrary.Patterns
{
    public class BuilderProduct
    {
        private static MySQL mySQL = Configuration.MySQL;
        private HTTPClient httpClient = Configuration.HTTPClient;

        private ProductDonated _productDonated;
        private ProductInCampaign _productInCampaign;

        private ActionsProduct actionsProduct;
        private LinkedListProduct linkedListProduct;
        private DataTabletProduct dataTabletProduct;

        //private List<ProductDonated> _productDonatedList;
        //private List<ProductInCampaign> _productInCampaignList;
        //private DataTable _productDonatedTable;
        //private DataTable _productInCampaignTable;
        //private string _logMessahe;
        //private bool _result;

        public BuilderProduct(ProductDonated productDonated) 
        {
            _productDonated = productDonated;
            actionsProduct = new ActionsProduct(_productDonated, _productInCampaign, mySQL, httpClient);
            linkedListProduct = new LinkedListProduct(_productDonated, _productInCampaign, mySQL, httpClient);
            dataTabletProduct = new DataTabletProduct(_productDonated, _productInCampaign);
        }

        public BuilderProduct(ProductInCampaign productInCampaign) 
        {
            _productInCampaign = productInCampaign;
            actionsProduct = new ActionsProduct(_productDonated, _productInCampaign, mySQL, httpClient);
            linkedListProduct = new LinkedListProduct(_productDonated, _productInCampaign, mySQL, httpClient);
            dataTabletProduct = new DataTabletProduct(_productDonated, _productInCampaign);
        }

        //public T Builder<T>(T _log){
        //    if (_logMessahe) return T;
        //    return T;
        //}

        //Actions
        public async Task SetTwitterMessagTweet_SetBuyAnItemAsync() =>
            await actionsProduct.SetTwitterMessagTweet_SetBuyAnItemAsync();
        public async Task<bool> SetBuyAnItemAsync(Modes mode = null) =>
            await actionsProduct.SetBuyAnItemAsync(mode);
        public async Task<bool> SetProductShippingAsync(Modes mode = null) =>
            await actionsProduct.SetProductShippingAsync(mode);
        public async Task<bool> SetNewProductAsync(Modes mode = null) =>
            await actionsProduct.SetNewProductAsync(mode);

        // LinkedList and DataTable
        public async Task<List<ProductDonated>> MySQL_GetDonatedProductForShipping_ListAsync(Modes mode = null) =>
             await linkedListProduct.MySQL_GetDonatedProductForShipping_ListAsync(mode);
        public async Task<DataTable> GetDonatedProductForShipping_DataTableAsync() =>
             await dataTabletProduct.GetDonatedProductForShipping_DataTableAsync();
        public async Task<DataTable> GetList_DataTableAsync() =>
             await dataTabletProduct.GetList_DataTableAsync();
        public async Task<List<ProductInCampaign>> MySQL_GetProductList_ListAsync(Modes mode = null) =>
             await linkedListProduct.MySQL_GetProductList_ListAsync(mode);
    }
}
