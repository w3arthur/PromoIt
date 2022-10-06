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
    public partial class BusinessProductListPanel : Form
    {

        public BusinessProductListPanel()
        {
            InitializeComponent();
        }

        private void ProductListBC_Shown(object sender, EventArgs e) => GetProductsInCampaignsAsync();
        
        private async Task GetProductsInCampaignsAsync()
        {
            try
            {
                ProductInCampaign productInCampaign = new ProductInCampaign() { Campaign = Configuration.CorrentCampaign, };
                dataGridProductList.DataSource = await productInCampaign.GetList_DataTableAsync();
                //dataGridProductList.Columns["clmnProductId"].Visible = false; //set as hidden
                //dataGridProductList.Columns["clmnBusinessUser"].Visible = false; //set as hidden
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

    }
}
