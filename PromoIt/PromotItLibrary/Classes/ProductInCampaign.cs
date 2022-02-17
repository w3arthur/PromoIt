using MySql.Data.MySqlClient;
using PromotItLibrary.Models;
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


        public string Id { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
        public Users BusinessUser { get; set; }
        public Campaign Campaign { get; set; }


        public async Task<bool> SetNewProductAsync(Modes mode = null)
        {

            try
            {   //Queue and Functions
                if ((mode ?? Configuration.Mode) == Modes.Queue)
                    return (bool)await httpClient.PostSingleDataInsert(Configuration.PromoitProductQueue, this, "SetNewProduct");
                else if ((mode ?? Configuration.Mode) == Modes.Functions)
                    return (bool)await httpClient.PostSingleDataInsert(Configuration.PromoitProductFunctions, this, "SetNewProduct");
            }
            catch { return false; }

            if ((mode ?? Configuration.DatabaseMode) == Modes.MySQL)
            {
                mySQL.Quary("INSERT INTO `promoit`.`products_in_campaign` (`name`, `quantity`, `price`, `business_user_name`, `campaign_hashtag`) VALUES (@_name, @_quantity, @_price, @_business_user_name, @_campaign_hashtag);");
                mySQL.SetParameter("_name", Name);
                mySQL.SetParameter("_quantity", decimal.Parse(Quantity));
                mySQL.SetParameter("_business_user_name", BusinessUser.UserName);
                mySQL.SetParameter("_price", int.Parse(Price));
                mySQL.SetParameter("_campaign_hashtag", Campaign.Hashtag);
                return await mySQL.ProceduteExecuteAsync();
            }

            return false;

        }

        public async Task<DataTable> GetList_DataTableAsync() //for business and for activist
        {
            DataTable dataTable = new DataTable();
            List<ProductInCampaign> productInCampaignList = await MySQL_GetProductList_ListAsync();
            foreach (string culmn in new[] { "clmnProductId", "clmnBusinessUser", "clmnProductName", "clmnProductQuantity", "clmnProductPrice" })
                dataTable.Columns.Add(culmn);
            if (productInCampaignList == null)
            {
                while ( Configuration.IsTries() )
                    return await GetList_DataTableAsync();
                Loggings.ErrorLog($"No Products in Get products in campagign, Campaign (#{Campaign.Hashtag}) by ({Configuration.CorrentUser.UserName})");
                Configuration.TriesReset();
                return dataTable;//no results
            }
            Configuration.TriesReset();

            foreach (ProductInCampaign productInCampaign in productInCampaignList)
            {
                DataRow dataRow = dataTable.NewRow();
                foreach (var (key, value) in new[] { ("clmnProductName", productInCampaign.Name), ("clmnProductQuantity", productInCampaign.Quantity), ("clmnProductPrice", productInCampaign.Price)
                    , ("clmnProductId", productInCampaign.Id), ("clmnBusinessUser", productInCampaign.BusinessUser.UserName) }) //hidden
                    dataRow[key] = value;
                dataTable.Rows.Add(dataRow);
            }

            Loggings.ReportLog($"Get products in campagign, Campaign (#{Campaign.Hashtag}) by ({Configuration.CorrentUser.UserName})");

            return dataTable;
        }

        public async Task<List<ProductInCampaign>> MySQL_GetProductList_ListAsync(Modes mode = null) //for business and for activist
        {

            try
            {   //Queue and Functions
                if ((mode ?? Configuration.Mode) == Modes.Queue)
                    return await httpClient.GetMultipleDataRequest(Configuration.PromoitProductQueue, this, "GetProductList");
                else if ((mode ?? Configuration.Mode) == Modes.Functions)
                    return await httpClient.GetMultipleDataRequest(Configuration.PromoitProductFunctions, this, "GetProductList");
            }
            catch { return null; };

            if ((mode ?? Configuration.DatabaseMode) == Modes.MySQL)
            {
                if (Campaign.Hashtag == null) throw new Exception("No set for Campaign Hashtag");
                mySQL.SetQuary("SELECT * FROM products_in_campaign WHERE campaign_hashtag = @hashtag AND Quantity > 0");
                mySQL.QuaryParameter("@hashtag", Campaign.Hashtag);
                using MySqlDataReader results = await mySQL.ProceduteExecuteMultyResultsAsync();

                List<ProductInCampaign> productInCampaignList = new List<ProductInCampaign>();
                while (results != null && results.Read())
                {
                    try
                    {
                        productInCampaignList.Add
                            (
                                new ProductInCampaign()
                                {
                                    Name = results.GetString("name"),
                                    Quantity = results.GetString("quantity"),
                                    Price = results.GetString("price"),
                                    Id = results.GetString("id"),
                                    BusinessUser = new BusinessUser() { UserName = results.GetString("business_user_name"), },
                                }
                            );
                    }
                    catch { };
                }
                return productInCampaignList;
            }

            return null;

        }

    }
}
