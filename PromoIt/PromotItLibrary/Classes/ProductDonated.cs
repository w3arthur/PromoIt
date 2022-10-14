using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns;
using PromotItLibrary.Patterns.Actions;
using PromotItLibrary.Patterns.DataTables;
using PromotItLibrary.Patterns.LinkedLists;
using PromotItLibrary.Patterns.LinkedLists.LinkedList_Function_State.LinkedLists_Interfaces;
using PromotItLibrary.Patterns.Actions.Actions_Interfaces;
using PromotItLibrary.Patterns.DataTables.DataTables_Interfaces;
using PromotItLibrary.Interfaces;
using PromotItLibrary.Enums;
using MySqlX.XDevAPI;
using PromotItLibrary.Patterns.Actions.Actions_Fuction_State;
using PromotItLibrary.Patterns.Actions.Actions_MySql_State;
using PromotItLibrary.Patterns.Actions.Actions_Queue_State;
using System.Net.Http;
using System.Xml.Linq;
using PromotItLibrary.Patterns.LinkedLists.LinkedList_Function_State;
using PromotItLibrary.Patterns.LinkedLists.LinkedLists_MySql_State;
using PromotItLibrary.Patterns.LinkedLists.Queue_State;

namespace PromotItLibrary.Classes
{
    public class ProductDonated : IProductDonated, IActionsProduct_ProductDonated, ILinkedListProduct_ProductDonated, IDataTabletProduct_ProductDonated
    {
        private readonly MySQL _mySQL = Configuration.MySQL;
        private readonly HTTPClient _httpClient = Configuration.HTTPClient;

        private readonly Modes _mode;
        private readonly IActionsProduct_ProductDonated actionsProduct;
        private readonly ILinkedListProduct_ProductDonated linkedListProduct;
        private readonly IDataTabletProduct_ProductDonated dataTabletProduct;

        public IProductInCampaign ProductInCampaign { get; set; }
        public IUsers ActivistUser { get; set; }
        public string Quantity { get; set; }
        public string Shipped { get; set; }
        public string Id { get; set; }

        public ProductDonated()
        {
            //Actions State
            if ((_mode ?? Configuration.Mode) == Modes.Queue)
                actionsProduct = new ActionsProduct_Queue(this, null, _httpClient);
            else if ((_mode ?? Configuration.Mode) == Modes.Functions)
                actionsProduct = new ActionsProduct_Function(this, null, _httpClient);
            if ((_mode ?? Configuration.DatabaseMode) == Modes.MySQL)
                actionsProduct = new ActionsProduct_MySql(this, null, _mySQL);

            //LinkdeList States
            if ((_mode ?? Configuration.Mode) == Modes.Queue)
                linkedListProduct = new LinkedListProduct_Queue(this, null, _mySQL, _httpClient);
            else if ((_mode ?? Configuration.Mode) == Modes.Functions)
                linkedListProduct = new LinkedListProduct_Function(this, null, _mySQL, _httpClient);
            if ((_mode ?? Configuration.DatabaseMode) == Modes.MySQL)
                linkedListProduct = new LinkedListProduct_MySql(this, null, _mySQL, _httpClient);

            //DataTable States ?
            dataTabletProduct = new DataTabletProduct(this, null);
        }


        //Actions
        public async Task SetTwitterMessagTweet_SetBuyAnItemAsync()
        {
            try
            {
                await Twitter.SetTwitterMessage_SetBuyAnItemAsync($"Product: {this.ProductInCampaign.Name}, Quantity {this.Quantity}" +
                    $"\nOrdered by Social Activist: @{this.ActivistUser.UserName}" +
                    $"\nFrom Business: {this.ProductInCampaign.BusinessUser.UserName}");
                Loggings.ReportLog($"Trying To Set a tweet for buying an item, Activist UserName ({this.ActivistUser.UserName}) CampaignName ({this.ProductInCampaign.Name}) BuisnessUserName ({this.ProductInCampaign.BusinessUser.UserName})" +
                    $"\nProductId ({this.ProductInCampaign.Id}) Quantity ({this.Quantity})");
            }
            catch
            {  //Twitter exeption
                Loggings.ErrorLog($"Some error to set a tweet for buying an item, Activist UserName ({this.ActivistUser.UserName}) CampaignName ({this.ProductInCampaign.Name}) BuisnessUserName ({this.ProductInCampaign.BusinessUser.UserName})" +
                    $"\nProductId ({this.ProductInCampaign.Id}) Quantity ({this.Quantity})");
            }
        }

        public async Task<bool> SetBuyAnItemAsync(Modes mode = null) =>
            await actionsProduct.SetBuyAnItemAsync(mode);
        public async Task<bool> SetProductShippingAsync(Modes mode = null) =>
            await actionsProduct.SetProductShippingAsync(mode);

        // LinkedList
        public async Task<List<ProductDonated>> GetDonatedProductForShipping_ListAsync(Modes mode = null) =>
             await linkedListProduct.GetDonatedProductForShipping_ListAsync(mode);

        //DataTable
        public async Task<DataTable> GetDonatedProductForShipping_DataTableAsync() =>
             await dataTabletProduct.GetDonatedProductForShipping_DataTableAsync();

    }
}
