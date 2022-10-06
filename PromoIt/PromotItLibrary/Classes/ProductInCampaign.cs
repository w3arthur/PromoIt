using MySql.Data.MySqlClient;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns;
using PromotItLibrary.Patterns.Actions;
using PromotItLibrary.Patterns.DataTables;
using PromotItLibrary.Patterns.LinkedLists;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PromotItLibrary.Classes
{
    public class ProductInCampaign
    {
        private static MySQL mySQL = Configuration.MySQL;
        private HTTPClient httpClient = Configuration.HTTPClient;

        private ActionsProduct actionsProduct;
        private LinkedListProduct linkedListProduct;
        private DataTabletProduct dataTabletProduct;


        public string Id { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
        public Users BusinessUser { get; set; }
        public Campaign Campaign { get; set; }

        public ProductInCampaign()
        {
            actionsProduct = new ActionsProduct(null, this, mySQL, httpClient);
            linkedListProduct = new LinkedListProduct(null, this, mySQL, httpClient);
            dataTabletProduct = new DataTabletProduct(null, this);
        }



        //Actions
        public async Task<bool> SetNewProductAsync(Modes mode = null) =>
            await actionsProduct.SetNewProductAsync(mode);

        // LinkedList and DataTable
        public async Task<DataTable> GetList_DataTableAsync() =>
             await dataTabletProduct.GetList_DataTableAsync();
        public async Task<List<ProductInCampaign>> MySQL_GetProductList_ListAsync(Modes mode = null) =>
             await linkedListProduct.MySQL_GetProductList_ListAsync(mode);

    }

}
