using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using PromotItLibrary.Enums;
using PromotItLibrary.Interfaces;
using PromotItLibrary.Interfaces.Actions;
using PromotItLibrary.Interfaces.DataTables;
using PromotItLibrary.Interfaces.LinkedList;
using PromotItLibrary.Interfaces.Users;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns.Actions.Actions_Fuction_State;
using PromotItLibrary.Patterns.Actions.Actions_MySql_State;
using PromotItLibrary.Patterns.Actions.Actions_Queue_State;
using PromotItLibrary.Patterns.DataTables;
using PromotItLibrary.Patterns.LinkedLists.LinkedList_Function_State;
using PromotItLibrary.Patterns.LinkedLists.LinkedLists_MySql_State;
using PromotItLibrary.Patterns.LinkedLists.Queue_State;

namespace PromotItLibrary.Classes
{
    public class ProductInCampaign : IProductInCampaign, IActionsProduct_ProductInCampaign, ILinkedListProduct_ProductInCampaign, IDataTabletProduct_ProductInCampaign
    {
        private readonly MySQL _mySQL = Configuration.MySQL;
        private readonly HTTPClient _httpClient = Configuration.HTTPClient;

        private readonly Modes _mode;
        private readonly IActionsProduct_ProductInCampaign actionsProduct;
        private readonly ILinkedListProduct_ProductInCampaign linkedListProduct;
        private readonly IDataTabletProduct_ProductInCampaign dataTabletProduct;


        public string Id { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
        public IUsers BusinessUser { get; set; }
        public ICampaign Campaign { get; set; }

        public ProductInCampaign()
        {
            Campaign = new Campaign();

            //Actions State
            //LinkedList States
            if ((_mode ?? Configuration.Mode) == Modes.Queue)
            {
                actionsProduct = new ActionsProduct_Queue(this, _httpClient);
                linkedListProduct = new LinkedListProduct_Queue(this, _httpClient);
            }
            else if ((_mode ?? Configuration.Mode) == Modes.Functions)
            {
                actionsProduct = new ActionsProduct_Function(this, _httpClient);
                linkedListProduct = new LinkedListProduct_Function(this, _httpClient);
            }
            else if ((_mode ?? Configuration.DatabaseMode) == Modes.MySQL)
            {
                actionsProduct = new ActionsProduct_MySql(this, _mySQL);
                linkedListProduct = new LinkedListProduct_MySql(this, _mySQL);
            }
               
            //DataTable States ?
            dataTabletProduct = new DataTabletProduct(this);
        }


        //Actions
        public async Task<bool> SetNewProductAsync(Modes mode = null) =>
            await actionsProduct.SetNewProductAsync(mode);

        // LinkedList
        public async Task<DataTable> GetList_DataTableAsync() =>
             await dataTabletProduct.GetList_DataTableAsync();

        //DataTable
        public async Task<List<ProductInCampaign>> GetProductList_ListAsync(Modes mode = null) =>
             await linkedListProduct.GetProductList_ListAsync(mode);

    }

}
