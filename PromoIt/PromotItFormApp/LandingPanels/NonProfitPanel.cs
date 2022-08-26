using MySql.Data.MySqlClient;
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
using PromotItFormApp.LandingPanelsActions;
using PromotItLibrary.Patterns;

namespace PromotItFormApp.LandingPanels
{

    public partial class NonProfitPanel : Form
    {
        Campaign campaign = new Campaign();
        public NonProfitPanel()
        {
            InitializeComponent();
        }


        private void buttonNew_Click(object sender, EventArgs e)
        {
            this.Hide();
            NonProfitNewCampaignPanel newCamp = new NonProfitNewCampaignPanel();
            newCamp.ShowDialog();
        }

        private void panelNPO_Paint(object sender, PaintEventArgs e)
        {
            pnlPanelTop.BackColor = ThemeColor.PrimaryColor;
            pnlPanelTop.ForeColor = Color.White;
        }
        private void NPOrganizationPanel_Shown(object sender, EventArgs e)
        {
            GetAllCampaignsDisplayAsync();
        }

        private void dataGridNPO_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if(MessageBox.Show("Are you sure you want to delete this campaign?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    SetDeleteACampaignAsync(e);
                }
            }
        }


        private async Task SetDeleteACampaignAsync(DataGridViewCellEventArgs e) 
        {
            try
            {
                campaign = new Campaign()
                {
                NonProfitUser = Configuration.CorrentUser,
                Hashtag = dgrdNonProfit.Rows[e.RowIndex].Cells[2].Value.ToString(),
                };

                bool result = await new BuilderCampaign(campaign).DeleteCampaignAsync();
                if (!result)
                {
                    Loggings.ErrorLog($"Fail Non Profit Organization user to delete the campaign, UserName ({campaign.NonProfitUser.UserName}) Campaign (#{campaign.Hashtag})");
                    throw new Exception("Cant Delete The campaign");
                }

                Loggings.ReportLog($"Delete Campagin by Non Profit Organization user, UserName ({campaign.NonProfitUser.UserName}) Campaign (#{campaign.Hashtag})");
                GetAllCampaignsDisplayAsync();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private async Task GetAllCampaignsDisplayAsync()
        {
            try
            {
                DataTable tbl = await new BuilderCampaign(new Campaign() { NonProfitUser = Configuration.CorrentUser, }).GetAllCampaignsNonProfit_DataTableAsync();
                dgrdNonProfit.DataSource = tbl;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message);}
        }

    }
    
}
