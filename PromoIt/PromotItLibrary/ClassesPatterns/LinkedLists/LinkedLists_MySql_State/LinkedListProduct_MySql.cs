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

namespace PromotItLibrary.Patterns.LinkedLists.LinkedLists_MySql_State
{
    public class LinkedListProduct_MySql : ILinkedListProduct_ProductDonated, ILinkedListProduct_ProductInCampaign
    {

        private readonly MySQL _mySQL;
        private readonly ProductDonated _productDonated;
        private readonly ProductInCampaign _productInCampaign;

        public LinkedListProduct_MySql(ProductDonated productDonated, ProductInCampaign productInCampaign, MySQL mySQL) 
        {
            _mySQL = mySQL;
            _productDonated = productDonated;
            _productInCampaign = productInCampaign;
        }


        public async Task<List<ProductDonated>> GetDonatedProductForShipping_ListAsync(Modes mode = null)
        {
            // Error, no business user
            if (_productDonated.ProductInCampaign.BusinessUser.UserType != "business" && _productDonated.ProductInCampaign.BusinessUser.UserName == null) throw new Exception("No set for business User");
            _mySQL.Quary(" SELECT * FROM products_in_campaign pic JOIN products_donated pd on pic.id = pd.product_in_campaign_id WHERE pd.shipped = @_shipped AND pic.business_user_name = @_business_user_name LIMIT @_limit"); //replace with mySQL.Procedure() //add LIMIT 20 ~
            _mySQL.ProcedureParameter("_shipped", "not_shipped");
            _mySQL.ProcedureParameter("_business_user_name", _productDonated.ProductInCampaign.BusinessUser.UserName);
            _mySQL.ProcedureParameter("_limit", 10);
            using MySqlDataReader results = await _mySQL.ProceduteExecuteMultyResultsAsync();

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

        public async Task<List<ProductInCampaign>> GetProductList_ListAsync(Modes mode = null)
        {
            if (_productInCampaign.Campaign.Hashtag == null) throw new Exception("No set for Campaign Hashtag");
            _mySQL.SetQuary("SELECT * FROM products_in_campaign WHERE campaign_hashtag = @hashtag AND Quantity > 0");
            _mySQL.QuaryParameter("@hashtag", _productInCampaign.Campaign.Hashtag);
            using MySqlDataReader results = await _mySQL.ProceduteExecuteMultyResultsAsync();

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


    }
}
