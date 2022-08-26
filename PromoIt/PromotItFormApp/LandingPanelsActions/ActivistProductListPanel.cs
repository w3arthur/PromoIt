using MySql.Data.MySqlClient;
using PromotItLibrary.Classes;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PromotItFormApp.LandingPanelsActions
{
    public partial class ActivistProductListPanel : Form
    {
        public ActivistProductListPanel()
        {
            InitializeComponent();
            Configuration.Message = "";
        }


        private void dataGridProductList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0) SetBuyAProductAsync(e);
        }

        private void ProductList_Shown(object sender, EventArgs e) => GetProductsAsync();

        private async Task SetBuyAProductAsync(DataGridViewCellEventArgs e)
        {
            ProductDonated productDonated = new ProductDonated() 
            {
            ProductInCampaign = new ProductInCampaign() 
                {
                Id = dataGridProductList["clmnProductId", e.RowIndex].Value.ToString(),
                Name = dataGridProductList["clmnProductName", e.RowIndex].Value.ToString(),
                BusinessUser = new BusinessUser() { UserName = dataGridProductList["clmnBusinessUser", e.RowIndex].Value.ToString(), }   //Receive from database      
                },
            Quantity = "1",
            ActivistUser = Configuration.CorrentUser,
            };

            try
            {
                bool result = await new BuilderProduct(productDonated).SetBuyAnItemAsync();
                if (!result) throw new Exception("Cant Buy This Item");
                
                Configuration.Message = $"Thanks For ordering { productDonated.ProductInCampaign.Name} {productDonated.Quantity}pcs\n for Campaign #{Configuration.CorrentCampaign.Hashtag}";
                Task sendATweet = new BuilderProduct(productDonated).SetTwitterMessagTweet_SetBuyAnItemAsync();
                await sendATweet;
                Loggings.ReportLog($"Activist Bought an item, Activist UserName ({productDonated.ActivistUser.UserName}) CampaignName ({productDonated.ProductInCampaign.Name}) BuisnessUserName ({productDonated.ProductInCampaign.BusinessUser.UserName})" +
                    $"\nProductId ({productDonated.ProductInCampaign.Id}) Quantity ({productDonated.Quantity})");
                this.Dispose();
            }
            catch (Exception ex) 
            {
                Loggings.ErrorLog($"Fail to bought Activist an item, Activist UserName ({productDonated.ActivistUser.UserName}) CampaignName ({productDonated.ProductInCampaign.Name}) BuisnessUserName ({productDonated.ProductInCampaign.BusinessUser.UserName})" +
                                        $"\nProductId ({productDonated.ProductInCampaign.Id}) Quantity ({productDonated.Quantity})" +
                                        $"\nDatabase Exeption: ({ex})");
                MessageBox.Show(ex.Message);
            }
        }

        private async Task GetProductsAsync()
        {
            try
            {
                ProductInCampaign productInCampaign = new ProductInCampaign() 
                {
                    Campaign = Configuration.CorrentCampaign,
                };
                Configuration.CorrentProduct = productInCampaign;
                
                dataGridProductList.DataSource = await new BuilderProduct(productInCampaign).GetList_DataTableAsync();
                //dataGridProductList.Columns["clmnProductId"].Visible = false; //hidden
                //dataGridProductList.Columns["clmnBusinessUser"].Visible = false; //hidden
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
