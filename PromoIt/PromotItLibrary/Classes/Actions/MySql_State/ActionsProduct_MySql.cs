using PromotItLibrary.Classes;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns.Actions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns.Actions.MySql_State
{
    public class ActionsProduct_MySql : IActionsProduct
    {

        private static MySQL mySQL;
        private HTTPClient httpClient;

        private ProductDonated _productDonated;
        private ProductInCampaign _productInCampaign;

        public ActionsProduct_MySql(ProductDonated productDonated, ProductInCampaign productInCampaign, MySQL _mySQL, HTTPClient _httpClient)
        {
            mySQL = _mySQL;
            _productDonated = productDonated;
            _productInCampaign = productInCampaign;
        }

        public async Task<bool> SetBuyAnItemAsync()
        {
            mySQL.Procedure("buy_a_product");
            mySQL.SetParameter("_product_id", _productDonated.ProductInCampaign.Id);
            mySQL.SetParameter("_quantity", _productDonated.Quantity);
            mySQL.SetParameter("_activist_user_name", _productDonated.ActivistUser.UserName);
            mySQL.SetParameter("_shipping", "not_shipped");
            return await mySQL.ProceduteExecuteAsync();
        }

        public async Task<bool> SetProductShippingAsync()
        {
            mySQL.Quary("UPDATE `promoit`.`products_donated` SET `shipped` = @_shipping WHERE (`id2` = @_donated_product_id);");
            mySQL.SetParameter("_donated_product_id", _productDonated.Id);
            mySQL.SetParameter("_shipping", "shipped");
            return await mySQL.ProceduteExecuteAsync();
        }

        public async Task<bool> SetNewProductAsync()
        {
            mySQL.Quary("INSERT INTO `promoit`.`products_in_campaign` (`name`, `quantity`, `price`, `business_user_name`, `campaign_hashtag`) VALUES (@_name, @_quantity, @_price, @_business_user_name, @_campaign_hashtag);");
            mySQL.SetParameter("_name", _productInCampaign.Name);
            mySQL.SetParameter("_quantity", decimal.Parse(_productInCampaign.Quantity));
            mySQL.SetParameter("_business_user_name", _productInCampaign.BusinessUser.UserName);
            mySQL.SetParameter("_price", int.Parse(_productInCampaign.Price));
            mySQL.SetParameter("_campaign_hashtag", _productInCampaign.Campaign.Hashtag);
            return await mySQL.ProceduteExecuteAsync();
        }

    }
}
