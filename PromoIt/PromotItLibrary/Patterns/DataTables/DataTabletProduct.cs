using MySql.Data.MySqlClient;
using PromotItLibrary.Classes;
using PromotItLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns.DataTables
{
    public class DataTabletProduct
    {

        private ProductDonated _productDonated;
        private ProductInCampaign _productInCampaign;

        public DataTabletProduct(ProductDonated productDonated, ProductInCampaign productInCampaign) 
        {
            _productDonated = productDonated;
            _productInCampaign = productInCampaign;
        }

        public async Task<DataTable> GetDonatedProductForShipping_DataTableAsync()
        {
            if (_productDonated == null) return null;

            DataTable dataTable = new DataTable();
            List<ProductDonated> productDonatedList = await new ActionsProduct(_productDonated).MySQL_GetDonatedProductForShipping_ListAsync();
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

        public async Task<DataTable> GetList_DataTableAsync()
        {
            if (_productInCampaign == null) return null;

            DataTable dataTable = new DataTable();
            List<ProductInCampaign> productInCampaignList = await new ActionsProduct(_productInCampaign).MySQL_GetProductList_ListAsync();
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

    }
}
