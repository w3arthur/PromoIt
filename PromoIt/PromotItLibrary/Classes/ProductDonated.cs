using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromotItLibrary.Models;

namespace PromotItLibrary.Classes
{
    public class ProductDonated
    {
        private MySQL mySQL = Configuration.MySQL;
        private HTTPClient httpClient = Configuration.HTTPClient;


        public ProductInCampaign ProductInCampaign { get; set; }
        public Users ActivistUser { get; set; }
        public string Quantity { get; set; }
        public string Shipped { get; set; }
        public string Id { get; set; }


        public async Task SetTwitterMessagTweet_SetBuyAnItemAsync()
        {
            try
            {
                await Twitter.SetTwitterMessage_SetBuyAnItemAsync($"Product: {ProductInCampaign.Name}, Quantity {Quantity}" +
                    $"\nOrdered by Social Activist: @{ActivistUser.UserName}" +
                    $"\nFrom Business: {ProductInCampaign.BusinessUser.UserName}");
                Loggings.ReportLog($"Trying To Set a tweet for buying an item, Activist UserName ({ActivistUser.UserName}) CampaignName ({ProductInCampaign.Name}) BuisnessUserName ({ProductInCampaign.BusinessUser.UserName})" +
                    $"\nProductId ({ProductInCampaign.Id}) Quantity ({Quantity})");
            }
            catch
            {  //Twitter exeption
                Loggings.ErrorLog($"Some error to set a tweet for buying an item, Activist UserName ({ActivistUser.UserName}) CampaignName ({ProductInCampaign.Name}) BuisnessUserName ({ProductInCampaign.BusinessUser.UserName})" +
                    $"\nProductId ({ProductInCampaign.Id}) Quantity ({Quantity})");
            }
        }


        public async Task<bool> SetBuyAnItemAsync(Modes mode = null)
        {

            try
            {   //Queue and Functions
                if ((mode ?? Configuration.Mode) == Modes.Queue)
                    return (bool)await httpClient.PostSingleDataInsert(Configuration.PromoitProductQueue, this, "SetBuyAnItem");
                else if ((mode ?? Configuration.Mode) == Modes.Functions)
                    return (bool)await httpClient.PostSingleDataInsert(Configuration.PromoitProductFunctions, this, "SetBuyAnItem");
            }
            catch { return false; }

            if ((mode ?? Configuration.DatabaseMode) == Modes.MySQL)
            {
                mySQL.Procedure("buy_a_product");
                mySQL.SetParameter("_product_id", ProductInCampaign.Id);
                mySQL.SetParameter("_quantity", Quantity);
                mySQL.SetParameter("_activist_user_name", ActivistUser.UserName);
                mySQL.SetParameter("_shipping", "not_shipped");
                return await mySQL.ProceduteExecuteAsync();
            }

            return false;

        }

        public async Task<bool> SetProductShippingAsync(Modes mode = null)
        {

            try
            {   //Queue and Functions
                if ((mode ?? Configuration.Mode) == Modes.Queue)
                    return (bool)await httpClient.PostSingleDataInsert(Configuration.PromoitProductQueue, this, "SetProductShipping");
                else if ((mode ?? Configuration.Mode) == Modes.Functions)
                    return (bool)await httpClient.PostSingleDataInsert(Configuration.PromoitProductFunctions, this, "SetProductShipping");
            }
            catch { return false; }

            if ((mode ?? Configuration.DatabaseMode) == Modes.MySQL)
            {
                mySQL.Quary("UPDATE `promoit`.`products_donated` SET `shipped` = @_shipping WHERE (`id2` = @_donated_product_id);");
                mySQL.SetParameter("_donated_product_id", Id);
                mySQL.SetParameter("_shipping", "shipped");
                return await mySQL.ProceduteExecuteAsync();
            }
            
            return false;

        }

        public async Task<List<ProductDonated>> MySQL_GetDonatedProductForShipping_ListAsync(Modes mode = null)
        {
            try
            {   //Queue and Functions
                if ((mode ?? Configuration.Mode) == Modes.Queue)
                    return await httpClient.GetMultipleDataRequest(Configuration.PromoitProductQueue, this, "GetDonatedProductForShipping");

                else if ((mode ?? Configuration.Mode) == Modes.Functions)
                    return await httpClient.GetMultipleDataRequest(Configuration.PromoitProductFunctions, this, "GetDonatedProductForShipping");
            }
            catch { return null; }

            if ((mode ?? Configuration.DatabaseMode) == Modes.MySQL)
            {
                // Error, no business user
                if (ProductInCampaign.BusinessUser.UserType != "business" && ProductInCampaign.BusinessUser.UserName == null) throw new Exception("No set for business User");
                mySQL.Quary(" SELECT * FROM products_in_campaign pic JOIN products_donated pd on pic.id = pd.product_in_campaign_id WHERE pd.shipped = @_shipped AND pic.business_user_name = @_business_user_name LIMIT @_limit"); //replace with mySQL.Procedure() //add LIMIT 20 ~
                mySQL.ProcedureParameter("_shipped", "not_shipped");
                mySQL.ProcedureParameter("_business_user_name", ProductInCampaign.BusinessUser.UserName);
                mySQL.ProcedureParameter("_limit", 10);
                using MySqlDataReader results = await mySQL.ProceduteExecuteMultyResultsAsync();

                List<ProductDonated> productDonatedList = new List<ProductDonated>();
                while (results != null && results.Read())
                {
                    try
                    {
                        productDonatedList.Add
                                (
                                    new ProductDonated()
                                    {
                                        ActivistUser = new ActivistUser() { UserName = results.GetString("activist_user_name"), },
                                        ProductInCampaign = new ProductInCampaign() { Name = results.GetString("name"), },
                                        Id = results.GetString("id2"),
                                    }
                                );
                    }
                    catch { };
                }
                return productDonatedList;
            }

            return null;

        }


        public async Task<DataTable> GetDonatedProductForShipping_DataTableAsync()
        {
            DataTable dataTable = new DataTable();
            List<ProductDonated> productDonatedList = await MySQL_GetDonatedProductForShipping_ListAsync();
            foreach (string culmn in new[] { "clmnActivist", "clmnProduct", "clmnProductDonatedId" })
                dataTable.Columns.Add(culmn);

            if (productDonatedList == null)
            {
                while (Configuration.IsTries())
                    return await GetDonatedProductForShipping_DataTableAsync();
                Loggings.ErrorLog($"Business user Got Empty list of donated products waiting for shipping, UserName ({ProductInCampaign.BusinessUser.UserName})");
                Configuration.TriesReset();
                return dataTable;//no results
            }
            Configuration.TriesReset();

            foreach (ProductDonated productDonated in productDonatedList)
            {
                DataRow dataRow = dataTable.NewRow();
                foreach (var (key, value) in new[] { ("clmnActivist", productDonated.ActivistUser.UserName), ("clmnProduct", productDonated.ProductInCampaign.Name), ("clmnProductDonatedId", productDonated.Id) })
                    dataRow[key] = value;
                dataTable.Rows.Add(dataRow);
            }
            Loggings.ReportLog($"Business user Get All donated products waiting for shipping, UserName ({ProductInCampaign.BusinessUser.UserName})");

            return dataTable;
        }

    }
}
