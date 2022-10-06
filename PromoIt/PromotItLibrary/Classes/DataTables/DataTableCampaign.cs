using MySql.Data.MySqlClient;
using PromotItLibrary.Classes;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns.DataTables.DataTables_Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns.DataTables
{
    public class DataTableCampaign : IDataTableCampaign
    {

        private Campaign _campaign;

        public DataTableCampaign(Campaign campaign) 
        {
            _campaign = campaign;
        }

        public async Task<DataTable> GetAllCampaignsNonProfit_DataTableAsync()
        {
            DataTable dataTable = new DataTable();
            List<Campaign> campaignsList = await _campaign.MySql_GetAllCampaignsNonProfit_ListAsync();
            foreach (string culmn in new[] { "clmnCampaignName", "clmnHashtag", "clmnWebsite", "clmnCreator" })
                dataTable.Columns.Add(culmn);

            if (campaignsList == null)
            {
                while (Configuration.IsTries())
                    return await _campaign.GetAllCampaignsNonProfit_DataTableAsync();
                Loggings.ErrorLog($"Non Profit Organization Not have any campaigns to show from GetAllCampaigns, UserName ({_campaign.NonProfitUser.UserName})");
                Configuration.TriesReset();
                return dataTable;//no results
            }
            Configuration.TriesReset();

            foreach (Campaign campaign in campaignsList)
            {
                DataRow dataRow = dataTable.NewRow();
                foreach (var (key, value) in new[] { ("clmnCampaignName", campaign.Name), ("clmnHashtag", campaign.Hashtag), ("clmnWebsite", campaign.Url), ("clmnCreator", campaign.NonProfitUser.UserName) })
                    dataRow[key] = value;
                dataTable.Rows.Add(dataRow);
            }

            Loggings.ReportLog($"Non Profit Organization GetAllCampaigns, UserName ({_campaign.NonProfitUser.UserName})");
            return dataTable;
        }

        public async Task<DataTable> GetAllCampaigns_DataTableAsync()
        {
            DataTable dataTable = new DataTable();
            List<Campaign> campaignsList = await _campaign.MySQL_GetAllCampaigns_ListAsync();
            foreach (string culmn in new[] { "clmnHashtag", "clmnWebpage" }) dataTable.Columns.Add(culmn);

            if (campaignsList == null)
            {
                while (Configuration.IsTries()) return await GetAllCampaigns_DataTableAsync();
                Loggings.ErrorLog($"Cant find any campaign to show from GetAllCampaigns request");
                Configuration.TriesReset();
                return dataTable;//no results
            }
            Configuration.TriesReset();

            foreach (Campaign campaign in campaignsList)
            {
                DataRow dataRow = dataTable.NewRow();
                foreach (var (key, value) in new[] { ("clmnHashtag", campaign.Hashtag), ("clmnWebpage", campaign.Url) }) dataRow[key] = value;
                dataTable.Rows.Add(dataRow);
            }

            Loggings.ReportLog($"GetAllCampaigns Requested");

            return dataTable;
        }

    }
}
