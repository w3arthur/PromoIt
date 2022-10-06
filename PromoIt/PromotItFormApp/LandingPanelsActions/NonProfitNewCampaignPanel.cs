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
    public partial class NonProfitNewCampaignPanel : Form
    {

        public NonProfitNewCampaignPanel()
        {
            InitializeComponent();
        }

        private void buttonSaveCamp_Click(object sender, EventArgs e)
            => SetCampaignAsync();


        private async Task SetCampaignAsync() 
        {
            try
            {
                if (textBoxCampName.Text == "" || textBoxCampHashtag.Text == "" || textBoxCampURL.Text == "")
                    throw new Exception("Please fill the required fields");
                Campaign campaign = new Campaign() 
                {
                    Name = textBoxCampName.Text,
                    Hashtag = textBoxCampHashtag.Text,
                    Url = textBoxCampURL.Text,
                    NonProfitUser = Configuration.CorrentUser,
                };

                var result = await campaign.SetNewCampaignAsync();
                if (!result)
                {
                    Loggings.ErrorLog($"Fail to insert a campaign by Non Profit Organizatino User, UserName ({campaign.NonProfitUser.UserName}) Campaign (#{campaign.Hashtag}) WebPage ({campaign.Url})");
                    throw new Exception("Cant Set New Campagn");
                }

                Loggings.ReportLog($"Non Profit Organizatino User added a campaign, UserName ({campaign.NonProfitUser.UserName}) Campaign (#{campaign.Hashtag}) WebPage ({campaign.Url})");

                this.Hide();
                LandingPanels.NonProfitPanel NPOPanel = new LandingPanels.NonProfitPanel();
                NPOPanel.ShowDialog();
                this.Close();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
