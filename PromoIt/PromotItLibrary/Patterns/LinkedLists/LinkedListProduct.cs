using MySql.Data.MySqlClient;
using PromotItLibrary.Classes;
using PromotItLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns.LinkedLists
{
    public class LinkedListProduct
    {

        private static MySQL mySQL;
        private HTTPClient httpClient;
        private ProductDonated _productDonated;
        private ProductInCampaign _productInCampaign;

        public LinkedListProduct(ProductDonated productDonated, ProductInCampaign productInCampaign, MySQL _mySQL, HTTPClient _httpClient) 
        {
            mySQL = _mySQL;
            httpClient = _httpClient;
            _productDonated = productDonated;
            _productInCampaign = productInCampaign;
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
