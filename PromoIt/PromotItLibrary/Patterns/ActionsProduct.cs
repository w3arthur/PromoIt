using MySql.Data.MySqlClient;
using PromotItLibrary.Classes;
using PromotItLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns
{
    public class ActionsProduct
    {
        private static MySQL mySQL = Configuration.MySQL;
        private HTTPClient httpClient = Configuration.HTTPClient;

        private ProductDonated _productDonated;
        private ProductInCampaign _productInCampaign;
        private List<ProductDonated> _productDonatedList;
        private List<ProductInCampaign> _productInCampaignList;
        private DataTable _productDonatedTable;
        private DataTable _productInCampaignTable;
        private string _logMessahe;
        private bool _result;

        public ActionsProduct(ProductDonated productDonated) => _productDonated = productDonated;
        public ActionsProduct(ProductInCampaign productInCampaign) => _productInCampaign = productInCampaign;


        /*
        public T Builder<T>(T _log){
            if (_logMessahe) return T;
            return T;
        }*/

        public async Task SetTwitterMessagTweet_SetBuyAnItemAsync()
        {
            if (_productDonated == null) return;

            try
            {
                await Twitter.SetTwitterMessage_SetBuyAnItemAsync($"Product: {_productDonated.ProductInCampaign.Name}, Quantity {_productDonated.Quantity}" +
                    $"\nOrdered by Social Activist: @{_productDonated.ActivistUser.UserName}" +
                    $"\nFrom Business: {_productDonated.ProductInCampaign.BusinessUser.UserName}");
                Loggings.ReportLog($"Trying To Set a tweet for buying an item, Activist UserName ({_productDonated.ActivistUser.UserName}) CampaignName ({_productDonated.ProductInCampaign.Name}) BuisnessUserName ({_productDonated.ProductInCampaign.BusinessUser.UserName})" +
                    $"\nProductId ({_productDonated.ProductInCampaign.Id}) Quantity ({_productDonated.Quantity})");
            }
            catch
            {  //Twitter exeption
                Loggings.ErrorLog($"Some error to set a tweet for buying an item, Activist UserName ({_productDonated.ActivistUser.UserName}) CampaignName ({_productDonated.ProductInCampaign.Name}) BuisnessUserName ({_productDonated.ProductInCampaign.BusinessUser.UserName})" +
                    $"\nProductId ({_productDonated.ProductInCampaign.Id}) Quantity ({_productDonated.Quantity})");
            }
        }

        public async Task<bool> SetBuyAnItemAsync(Modes mode = null)
        {
            if (_productDonated == null) return false;

            try
            {   //Queue and Functions
                if ((mode ?? Configuration.Mode) == Modes.Queue)
                    return (bool)await httpClient.PostSingleDataInsert(Configuration.PromoitProductQueue, _productDonated, "SetBuyAnItem");
                else if ((mode ?? Configuration.Mode) == Modes.Functions)
                    return (bool)await httpClient.PostSingleDataInsert(Configuration.PromoitProductFunctions, _productDonated, "SetBuyAnItem");
            }
            catch { return false; }

            if ((mode ?? Configuration.DatabaseMode) == Modes.MySQL)
            {
                mySQL.Procedure("buy_a_product");
                mySQL.SetParameter("_product_id", _productDonated.ProductInCampaign.Id);
                mySQL.SetParameter("_quantity", _productDonated.Quantity);
                mySQL.SetParameter("_activist_user_name", _productDonated.ActivistUser.UserName);
                mySQL.SetParameter("_shipping", "not_shipped");
                return await mySQL.ProceduteExecuteAsync();
            }

            return false;
        }

        public async Task<bool> SetProductShippingAsync(Modes mode = null)
        {
            if (_productDonated == null) return false;

            try
            {   //Queue and Functions
                if ((mode ?? Configuration.Mode) == Modes.Queue)
                    return (bool)await httpClient.PostSingleDataInsert(Configuration.PromoitProductQueue, _productDonated, "SetProductShipping");
                else if ((mode ?? Configuration.Mode) == Modes.Functions)
                    return (bool)await httpClient.PostSingleDataInsert(Configuration.PromoitProductFunctions, _productDonated, "SetProductShipping");
            }
            catch { return false; }

            if ((mode ?? Configuration.DatabaseMode) == Modes.MySQL)
            {
                mySQL.Quary("UPDATE `promoit`.`products_donated` SET `shipped` = @_shipping WHERE (`id2` = @_donated_product_id);");
                mySQL.SetParameter("_donated_product_id", _productDonated.Id);
                mySQL.SetParameter("_shipping", "shipped");
                return await mySQL.ProceduteExecuteAsync();
            }

            return false;
        }

        public async Task<List<ProductDonated>> MySQL_GetDonatedProductForShipping_ListAsync(Modes mode = null)
        {
            if (_productDonated == null) return null;

            try
            {   //Queue and Functions
                if ((mode ?? Configuration.Mode) == Modes.Queue)
                    return await httpClient.GetMultipleDataRequest(Configuration.PromoitProductQueue, _productDonated, "GetDonatedProductForShipping");

                else if ((mode ?? Configuration.Mode) == Modes.Functions)
                    return await httpClient.GetMultipleDataRequest(Configuration.PromoitProductFunctions, _productDonated, "GetDonatedProductForShipping");
            }
            catch { return null; }

            if ((mode ?? Configuration.DatabaseMode) == Modes.MySQL)
            {
                // Error, no business user
                if (_productDonated.ProductInCampaign.BusinessUser.UserType != "business" && _productDonated.ProductInCampaign.BusinessUser.UserName == null) throw new Exception("No set for business User");
                mySQL.Quary(" SELECT * FROM products_in_campaign pic JOIN products_donated pd on pic.id = pd.product_in_campaign_id WHERE pd.shipped = @_shipped AND pic.business_user_name = @_business_user_name LIMIT @_limit"); //replace with mySQL.Procedure() //add LIMIT 20 ~
                mySQL.ProcedureParameter("_shipped", "not_shipped");
                mySQL.ProcedureParameter("_business_user_name", _productDonated.ProductInCampaign.BusinessUser.UserName);
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
            if (_productDonated == null) return null;

            DataTable dataTable = new DataTable();
            List<ProductDonated> productDonatedList = await MySQL_GetDonatedProductForShipping_ListAsync();
            foreach (string culmn in new[] { "clmnActivist", "clmnProduct", "clmnProductDonatedId" })
                dataTable.Columns.Add(culmn);

            if (productDonatedList == null)
            {
                while (Configuration.IsTries())
                    return await new ActionsProduct(_productDonated).GetDonatedProductForShipping_DataTableAsync();
                Loggings.ErrorLog($"Business user Got Empty list of donated products waiting for shipping, UserName ({_productDonated.ProductInCampaign.BusinessUser.UserName})");
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
            Loggings.ReportLog($"Business user Get All donated products waiting for shipping, UserName ({_productDonated.ProductInCampaign.BusinessUser.UserName})");

            return dataTable;
        }

        public async Task<bool> SetNewProductAsync(Modes mode = null)
        {
            if (_productInCampaign == null) return false;

            try
            {   //Queue and Functions
                if ((mode ?? Configuration.Mode) == Modes.Queue)
                    return (bool)await httpClient.PostSingleDataInsert(Configuration.PromoitProductQueue, _productInCampaign, "SetNewProduct");
                else if ((mode ?? Configuration.Mode) == Modes.Functions)
                    return (bool)await httpClient.PostSingleDataInsert(Configuration.PromoitProductFunctions, _productInCampaign, "SetNewProduct");
            }
            catch { return false; }

            if ((mode ?? Configuration.DatabaseMode) == Modes.MySQL)
            {
                mySQL.Quary("INSERT INTO `promoit`.`products_in_campaign` (`name`, `quantity`, `price`, `business_user_name`, `campaign_hashtag`) VALUES (@_name, @_quantity, @_price, @_business_user_name, @_campaign_hashtag);");
                mySQL.SetParameter("_name", _productInCampaign.Name);
                mySQL.SetParameter("_quantity", decimal.Parse(_productInCampaign.Quantity));
                mySQL.SetParameter("_business_user_name", _productInCampaign.BusinessUser.UserName);
                mySQL.SetParameter("_price", int.Parse(_productInCampaign.Price));
                mySQL.SetParameter("_campaign_hashtag", _productInCampaign.Campaign.Hashtag);
                return await mySQL.ProceduteExecuteAsync();
            }
            return false;
        }

        public async Task<DataTable> GetList_DataTableAsync()
        {
            if (_productInCampaign == null) return null;

            DataTable dataTable = new DataTable();
            List<ProductInCampaign> productInCampaignList = await MySQL_GetProductList_ListAsync();
            foreach (string culmn in new[] { "clmnProductId", "clmnBusinessUser", "clmnProductName", "clmnProductQuantity", "clmnProductPrice" })
                dataTable.Columns.Add(culmn);
            if (productInCampaignList == null)
            {
                while (Configuration.IsTries())
                    return await new ActionsProduct(_productInCampaign).GetList_DataTableAsync();
                Loggings.ErrorLog($"No Products in Get products in campagign, Campaign (#{_productInCampaign.Campaign.Hashtag}) by ({Configuration.CorrentUser.UserName})");
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

            Loggings.ReportLog($"Get products in campagign, Campaign (#{_productInCampaign.Campaign.Hashtag}) by ({Configuration.CorrentUser.UserName})");
            return dataTable;
        }

        public async Task<List<ProductInCampaign>> MySQL_GetProductList_ListAsync(Modes mode = null)
        {
            if (_productInCampaign == null) return null;

            try
            {   //Queue and Functions
                if ((mode ?? Configuration.Mode) == Modes.Queue)
                    return await httpClient.GetMultipleDataRequest(Configuration.PromoitProductQueue, _productInCampaign, "GetProductList");
                else if ((mode ?? Configuration.Mode) == Modes.Functions)
                    return await httpClient.GetMultipleDataRequest(Configuration.PromoitProductFunctions, _productInCampaign, "GetProductList");
            }
            catch { return null; };

            if ((mode ?? Configuration.DatabaseMode) == Modes.MySQL)
            {
                if (_productInCampaign.Campaign.Hashtag == null) throw new Exception("No set for Campaign Hashtag");
                mySQL.SetQuary("SELECT * FROM products_in_campaign WHERE campaign_hashtag = @hashtag AND Quantity > 0");
                mySQL.QuaryParameter("@hashtag", _productInCampaign.Campaign.Hashtag);
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
