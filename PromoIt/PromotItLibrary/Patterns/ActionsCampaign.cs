using PromotItLibrary.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns
{
    public class ActionsCampaign
    {
        private Campaign _campaign;

        public ActionsCampaign(Campaign campaign) => _campaign = campaign;


        public async Task<bool> SetNewCampaignAsync(Modes mode = null) 
        {
            return await _campaign.SetNewCampaignAsync(mode); 
        }

        public async Task<bool> DeleteCampaignAsync(Modes mode = null) 
        {
            return await _campaign.DeleteCampaignAsync(mode); 
        }

        public async Task<List<Campaign>> MySql_GetAllCampaignsNonProfit_ListAsync(Modes mode = null)
        {
            return await _campaign.MySql_GetAllCampaignsNonProfit_ListAsync(mode);
        }

        public async Task<DataTable> GetAllCampaignsNonProfit_DataTableAsync()
        {
            return await _campaign.GetAllCampaignsNonProfit_DataTableAsync(); 
        }

        public async Task<List<Campaign>> MySQL_GetAllCampaigns_ListAsync(Modes mode = null)
        {
            return await _campaign.MySQL_GetAllCampaigns_ListAsync(mode);
        }

        public async Task<DataTable> GetAllCampaigns_DataTableAsync()
        {
            return await _campaign.GetAllCampaigns_DataTableAsync();
        }

    }
}
