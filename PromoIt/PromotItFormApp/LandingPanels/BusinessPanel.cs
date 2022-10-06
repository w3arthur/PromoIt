using MySql.Data.MySqlClient;
using PromotItFormApp.LandingPanels;
using PromotItFormApp.LandingPanelsActions;
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

namespace PromotItFormApp.LandingPanels
{
   
    public partial class BusinessPanel : Form
    {

        public BusinessPanel()
        {
            InitializeComponent();
            GetCampaignsAsync();
            GetProductsForShippingAsync();
        }

        private void dataGridBC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
                SetNewProductPage(e);
            else if (e.ColumnIndex == 0)
                GetProductListPage(e);
        }

        private void panelBCR_Paint(object sender, PaintEventArgs e)
        {
            pnlPanelTop.BackColor = ThemeColor.PrimaryColor;
            pnlPanelTop.ForeColor = Color.White;
        }

        private void dataGridBuyers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
                SetProductAsShippedAsync(e);
        }

        private void SetNewProductPage(DataGridViewCellEventArgs e)
        {
            Campaign campaign = new Campaign() { Hashtag = dgrdCampains["clmnHashtag", e.RowIndex].Value.ToString(), };
            Configuration.CorrentCampaign = campaign;
            (new BusinessNewProductPanel()).ShowDialog(); //Pannel
        }

        private void GetProductListPage(DataGridViewCellEventArgs e)
        {
            Configuration.CorrentCampaign = new Campaign()
            {
                Hashtag = dgrdCampains["clmnHashtag", e.RowIndex].Value.ToString(),
            };
            (new BusinessProductListPanel()).ShowDialog(); //Pannel
        }

        private async Task GetCampaignsAsync()
        {
            try
            {
                dgrdCampains.DataSource = await (new Campaign()).GetAllCampaigns_DataTableAsync(); ;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private async Task GetProductsForShippingAsync()
        {
            try
            {
                ProductDonated productDonated = new ProductDonated()
                {
                    ProductInCampaign =new ProductInCampaign() { BusinessUser = Configuration.CorrentUser, }
                };
                dgrdActivists.DataSource = await productDonated.GetDonatedProductForShipping_DataTableAsync();
                //dataGridBuyers.Columns["clmnProductDonatedId"].Visible = false;   //hidden
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }


        private async Task SetProductAsShippedAsync(DataGridViewCellEventArgs e) 
        {
            try
            {
                ProductDonated productDonated = new ProductDonated()
                {
                    Id = dgrdActivists["clmnProductDonatedId", e.RowIndex].Value.ToString(),
                };
                bool result = await productDonated.SetProductShippingAsync();
                if (result) GetProductsForShippingAsync();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
