using MySql.Data.MySqlClient;
using PromotItFormApp.LandingPanels;
using PromotItFormApp.LandingPanelsActions;
using PromotItLibrary.Classes;
using PromotItLibrary.Models;
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
    public partial class ActivistPanel : Form
    {
        public ActivistPanel()
        {
            InitializeComponent();
            GetCampaignsAsync();
            GetCashAmountAsync();
        }
        
        private void dataGridSA_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                try
                {
                    if (string.IsNullOrEmpty(dgrdCampaigns["clmnHashtag", e.RowIndex].Value.ToString())) return;

                    Campaign campaign = new Campaign() { Hashtag = dgrdCampaigns["clmnHashtag", e.RowIndex].Value.ToString(), };
                    Configuration.CorrentCampaign = campaign;
                    
                    ActivistProductListPanel productList = new ActivistProductListPanel() { };

                    DialogResult result = productList.ShowDialog();
                    if (result == DialogResult.Cancel)
                    {
                        lblMessages.Text = Configuration.Message;
                        GetCashAmountAsync();
                    }
                }
                catch { }
            }
        }

        private void panelSA_Paint(object sender, PaintEventArgs e)
        {
            pnlPanelTop.BackColor = ThemeColor.PrimaryColor;
            pnlPanelTop.ForeColor = Color.White;
        }

        private async Task GetCashAmountAsync()
        {
            ActivistUser activistUser = new ActivistUser(Configuration.CorrentUser);
            try
            {
                ActivistUser result = (await activistUser.GetCashAmountAsync());
                if (result == null) throw new Exception($"Cant Receive Activist Cash report UserName ({activistUser.UserName})");
                activistUser.Cash = result?.Cash;
                txtCashBalanceCheck.Text = activistUser.Cash;
                Loggings.ReportLog($"Activist Cash report UserName ({activistUser.UserName}) Cash ({activistUser.Cash})");
            }
            catch (Exception ex) 
            {
                Loggings.ErrorLog(ex.Message);
            }
        }

        private async Task GetCampaignsAsync()
        {
            try
            {
                dgrdCampaigns.DataSource = await (new Campaign()).GetAllCampaigns_DataTableAsync();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }


    }
}
