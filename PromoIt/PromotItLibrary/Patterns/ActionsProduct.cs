using PromotItLibrary.Classes;
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
        private ProductDonated _productDonated;
        private ProductInCampaign _productInCampaign;

        public ActionsProduct(ProductDonated productDonated) => _productDonated = productDonated;
        public ActionsProduct(ProductInCampaign productInCampaign) => _productInCampaign = productInCampaign;


        public async Task SetTwitterMessagTweet_SetBuyAnItemAsync()
        {
            if (_productDonated == null) return;
            await _productDonated.SetTwitterMessagTweet_SetBuyAnItemAsync();
        }

        public async Task<bool> SetBuyAnItemAsync(Modes mode = null)
        {
            if (_productDonated == null) return false;
            return await _productDonated.SetBuyAnItemAsync(mode);
        }

        public async Task<bool> SetProductShippingAsync(Modes mode = null)
        {
            if (_productDonated == null) return false;
            return await _productDonated.SetProductShippingAsync(mode);
        }

        public async Task<List<ProductDonated>> MySQL_GetDonatedProductForShipping_ListAsync(Modes mode = null)
        {
            if (_productDonated == null) return null;
            return await _productDonated.MySQL_GetDonatedProductForShipping_ListAsync(mode);
        }

        public async Task<DataTable> GetDonatedProductForShipping_DataTableAsync()
        {
            if (_productDonated == null) return null;
            return await _productDonated.GetDonatedProductForShipping_DataTableAsync();
        }

        public async Task<bool> SetNewProductAsync(Modes mode = null)
        {
            if (_productInCampaign == null) return false;
            return await _productInCampaign.SetNewProductAsync(mode);
        }

        public async Task<DataTable> GetList_DataTableAsync()
        {
            if (_productInCampaign == null) return null;
            return await _productInCampaign.GetList_DataTableAsync();
        }

        public async Task<List<ProductInCampaign>> MySQL_GetProductList_ListAsync(Modes mode = null)
        {
            if (_productInCampaign == null) return null;
            return await _productInCampaign.MySQL_GetProductList_ListAsync(mode);
        }


    }
}
