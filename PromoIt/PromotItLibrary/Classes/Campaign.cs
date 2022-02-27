using MySql.Data.MySqlClient;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Classes
{
    public class Campaign
    {
        private static MySQL mySQL = Configuration.MySQL;
        private HTTPClient httpClient = Configuration.HTTPClient;

        public string Name { get; set; }
        public string Hashtag { get; set; }
        public string Url { get; set; }
        public Users NonProfitUser { get; set; }


        public async Task<bool> SetNewCampaignAsync(Modes mode = null)
        {
            try
            {   //Queue and Functions
                if ((mode ?? Configuration.Mode) == Modes.Queue)
                    return (bool)await httpClient.PostSingleDataInsert(Configuration.PromoitCampaignQueue, this, "SetNewCampaign");
                else if ((mode ?? Configuration.Mode) == Modes.Functions)
                    return (bool)await httpClient.PostSingleDataInsert(Configuration.PromoitCampaignFunctions, this, "SetNewCampaign");
            } 
            catch { return false;}

            if ((mode ?? Configuration.DatabaseMode) == Modes.MySQL)
            {
                mySQL.Procedure("add_campaign");
                mySQL.SetParameter("_name", Name);
                mySQL.SetParameter("_hashtag", Hashtag);
                mySQL.SetParameter("_webpage", Url);
                mySQL.SetParameter("_non_profit_user_name", NonProfitUser.UserName);
                return await mySQL.ProceduteExecuteAsync();
            }

            return false;
        }
        public async Task<bool> DeleteCampaignAsync(Modes mode = null)
        {

            try
            {   //Queue and Functions
                if ((mode ?? Configuration.Mode) == Modes.Queue)
                    return (bool)await httpClient.PostSingleDataInsert(Configuration.PromoitCampaignQueue, this, "DeleteCampaign");
                else if ((mode ?? Configuration.Mode) == Modes.Functions)
                    return (bool)await httpClient.PostSingleDataInsert(Configuration.PromoitCampaignFunctions, this, "DeleteCampaign");
            }
            catch { return false; }

            if ((mode ?? Configuration.DatabaseMode) == Modes.MySQL)
            {
                mySQL.Procedure("delete_campaign");
                mySQL.QuaryParameter("_hashtag", Hashtag);
                return await mySQL.ProceduteExecuteAsync();
            }

            return false;
        }


        public async Task<List<Campaign>> MySql_GetAllCampaignsNonProfit_ListAsync(Modes mode = null) //Non profit
        {
            try
            {   //Queue and Functions
                if ((mode ?? Configuration.Mode) == Modes.Queue)
                return await httpClient.GetMultipleDataRequest(Configuration.PromoitCampaignQueue, this, "GetAllCampaignsNonProfit");
            else if ((mode ?? Configuration.Mode) == Modes.Functions)
                return await httpClient.GetMultipleDataRequest(Configuration.PromoitCampaignFunctions, this, "GetAllCampaignsNonProfit");
            }
            catch { return null; }

            if ((mode ?? Configuration.DatabaseMode) == Modes.MySQL)
            {
                // Error, no npo user
                if (NonProfitUser.UserName == null) throw new Exception("No set for npo User");
                mySQL.Quary("SELECT * FROM campaigns where non_profit_user_name=@np_user_name"); //replace with mySQL.Procedure() //add LIMIT 20 ~
                mySQL.ProcedureParameter("np_user_name", NonProfitUser.UserName);
                using MySqlDataReader results = await mySQL.ProceduteExecuteMultyResultsAsync();
                List<Campaign> campaignsList = new List<Campaign>();
                while (results != null && results.Read()) //for 1 result: if (mdr.Read())
                {
                    try
                    {
                        campaignsList.Add
                            (
                                new Campaign()
                                {
                                    Name = results.GetString("name"),
                                    Hashtag = results.GetString("hashtag"),
                                    Url = results.GetString("webpage"),
                                    NonProfitUser = new NonProfitUser() { UserName = results.GetString("non_profit_user_name"), },
                                }
                            );
                    }
                    catch { };
                }
                return campaignsList;
            }

            return null;
        }

        public async Task<DataTable> GetAllCampaignsNonProfit_DataTableAsync() //Non profit
        {
            DataTable dataTable = new DataTable();
            List<Campaign> campaignsList = await MySql_GetAllCampaignsNonProfit_ListAsync();
            foreach (string culmn in new[] { "clmnCampaignName", "clmnHashtag", "clmnWebsite", "clmnCreator" })
                dataTable.Columns.Add(culmn);

            if (campaignsList == null)
            {
                while (Configuration.IsTries())
                    return await new ActionsCampaign(this).GetAllCampaignsNonProfit_DataTableAsync();
                Loggings.ErrorLog($"Non Profit Organization Not have any campaigns to show from GetAllCampaigns, UserName ({NonProfitUser.UserName})");
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

            Loggings.ReportLog($"Non Profit Organization GetAllCampaigns, UserName ({NonProfitUser.UserName})");

            return dataTable;
        }

        public async Task<List<Campaign>> MySQL_GetAllCampaigns_ListAsync(Modes mode = null)//Activist, business, admin, tweets
        {
            try
            {   //Queue and Functions
                if ((mode ?? Configuration.Mode) == Modes.Queue)
                return await httpClient.GetMultipleDataRequest(Configuration.PromoitCampaignQueue, this, "GetAllCampaigns"); 
            else if ((mode ?? Configuration.Mode) == Modes.Functions)
                return await httpClient.GetMultipleDataRequest(Configuration.PromoitCampaignFunctions, this, "GetAllCampaigns");
            }
            catch 
            {
                return null;
            }

            if ((mode ?? Configuration.DatabaseMode) == Modes.MySQL)
            {
                mySQL.Quary("SELECT * FROM campaigns");
                using MySqlDataReader results = await mySQL.ProceduteExecuteMultyResultsAsync();
                List<Campaign> campaignsList = new List<Campaign>();
                while (results != null && results.Read())
                {
                    try
                    {
                        campaignsList.Add
                            (
                                new Campaign()
                                {
                                    Hashtag = results.GetString("hashtag"),
                                    Url = results.GetString("webpage"),
                                    NonProfitUser = new NonProfitUser() { UserName = results.GetString("non_profit_user_name"), },
                                }
                            );
                    }
                    catch { };
                }
                return campaignsList;
            }

            return null;
        }

        public async Task<DataTable> GetAllCampaigns_DataTableAsync() //Activist and business

        {
            DataTable dataTable = new DataTable();
            List<Campaign> campaignsList = await new ActionsCampaign(this).MySQL_GetAllCampaigns_ListAsync();
            foreach (string culmn in new[] {  "clmnHashtag", "clmnWebpage" }) dataTable.Columns.Add(culmn);

            if (campaignsList == null)
            {
                while (Configuration.IsTries())  return await GetAllCampaigns_DataTableAsync();
                Loggings.ErrorLog($"Cant find any campaign to show from GetAllCampaigns request");
                Configuration.TriesReset();
                return dataTable;//no results
            }
            Configuration.TriesReset();

            foreach (Campaign campaign in campaignsList)
            {
                DataRow dataRow = dataTable.NewRow();
                foreach (var (key, value) in new[] { ("clmnHashtag", campaign.Hashtag), ("clmnWebpage", campaign.Url)}) dataRow[key] = value;
                dataTable.Rows.Add(dataRow);
            }

            Loggings.ReportLog($"GetAllCampaigns Requested");

            return dataTable;

        }

    }
}