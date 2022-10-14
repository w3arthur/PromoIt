using PromotItLibrary.Classes;
using PromotItLibrary.Enums;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns.Actions.Actions_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns.Actions.Actions_MySql_State
{
    public class ActionsProduct_MySql : IActionsProduct
    {

        private readonly MySQL _mySQL;
        private readonly ProductDonated _productDonated;
        private readonly ProductInCampaign _productInCampaign;

        public ActionsProduct_MySql(ProductDonated productDonated, ProductInCampaign productInCampaign, MySQL mySQL)
        {
            _mySQL = mySQL;
            _productDonated = productDonated;
            _productInCampaign = productInCampaign;
        }

        public async Task<bool> SetBuyAnItemAsync(Modes mode = null)
        {
            _mySQL.Procedure("buy_a_product");
            _mySQL.SetParameter("_product_id", _productDonated.ProductInCampaign.Id);
            _mySQL.SetParameter("_quantity", _productDonated.Quantity);
            _mySQL.SetParameter("_activist_user_name", _productDonated.ActivistUser.UserName);
            _mySQL.SetParameter("_shipping", "not_shipped");
            return await _mySQL.ProceduteExecuteAsync();
        }

        public async Task<bool> SetProductShippingAsync(Modes mode = null)
        {
            _mySQL.Quary("UPDATE `promoit`.`products_donated` SET `shipped` = @_shipping WHERE (`id2` = @_donated_product_id);");
            _mySQL.SetParameter("_donated_product_id", _productDonated.Id);
            _mySQL.SetParameter("_shipping", "shipped");
            return await _mySQL.ProceduteExecuteAsync();
        }

        public async Task<bool> SetNewProductAsync(Modes mode = null)
        {
            _mySQL.Quary("INSERT INTO `promoit`.`products_in_campaign` (`name`, `quantity`, `price`, `business_user_name`, `campaign_hashtag`) VALUES (@_name, @_quantity, @_price, @_business_user_name, @_campaign_hashtag);");
            _mySQL.SetParameter("_name", _productInCampaign.Name);
            _mySQL.SetParameter("_quantity", decimal.Parse(_productInCampaign.Quantity));
            _mySQL.SetParameter("_business_user_name", _productInCampaign.BusinessUser.UserName);
            _mySQL.SetParameter("_price", int.Parse(_productInCampaign.Price));
            _mySQL.SetParameter("_campaign_hashtag", _productInCampaign.Campaign.Hashtag);
            return await _mySQL.ProceduteExecuteAsync();
        }

    }
}
