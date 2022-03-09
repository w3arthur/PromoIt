using MySql.Data.MySqlClient;
using PromotItLibrary.Classes;
using PromotItLibrary.Models;
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
        private static MySQL mySQL = Configuration.MySQL;
        private HTTPClient httpClient = Configuration.HTTPClient;

        private Campaign _campaign;
        private List<Campaign> _campaignList;
        private DataTable _campaignTable;
        private string _logMessahe;
        private bool _result;

        public ActionsCampaign(Campaign campaign) => _campaign = campaign;

        /*
        public T Builder<T>(T _log){
            if (_logMessahe) return T;
            return T;
        }*/
        

        public async Task<bool> SetNewCampaignAsync(Modes mode = null) 
        {
            try
            {   //Queue and Functions
                if ((mode ?? Configuration.Mode) == Modes.Queue)
                    return (bool)await httpClient.PostSingleDataInsert(Configuration.PromoitCampaignQueue, _campaign, "SetNewCampaign");
                else if ((mode ?? Configuration.Mode) == Modes.Functions)
                    return (bool)await httpClient.PostSingleDataInsert(Configuration.PromoitCampaignFunctions, _campaign, "SetNewCampaign");
            }
            catch { return false; }

            if ((mode ?? Configuration.DatabaseMode) == Modes.MySQL)
            {
                mySQL.Procedure("add_campaign");
                mySQL.SetParameter("_name", _campaign.Name);
                mySQL.SetParameter("_hashtag", _campaign.Hashtag);
                mySQL.SetParameter("_webpage", _campaign.Url);
                mySQL.SetParameter("_non_profit_user_name", _campaign.NonProfitUser.UserName);
                return await mySQL.ProceduteExecuteAsync();
            }

            return false;
        }

        public async Task<bool> DeleteCampaignAsync(Modes mode = null) 
        {
            try
            {   //Queue and Functions
                if ((mode ?? Configuration.Mode) == Modes.Queue)
                    return (bool)await httpClient.PostSingleDataInsert(Configuration.PromoitCampaignQueue, _campaign, "DeleteCampaign");
                else if ((mode ?? Configuration.Mode) == Modes.Functions)
                    return (bool)await httpClient.PostSingleDataInsert(Configuration.PromoitCampaignFunctions, _campaign, "DeleteCampaign");
            }
            catch { return false; }

            if ((mode ?? Configuration.DatabaseMode) == Modes.MySQL)
            {
                mySQL.Procedure("delete_campaign");
                mySQL.QuaryParameter("_hashtag", _campaign.Hashtag);
                return await mySQL.ProceduteExecuteAsync();
            }

            return false;
        }

        public async Task<List<Campaign>> MySql_GetAllCampaignsNonProfit_ListAsync(Modes mode = null)
        {
            try
            {   //Queue and Functions
                if ((mode ?? Configuration.Mode) == Modes.Queue)
                    return await httpClient.GetMultipleDataRequest(Configuration.PromoitCampaignQueue, _campaign, "GetAllCampaignsNonProfit");
                else if ((mode ?? Configuration.Mode) == Modes.Functions)
                    return await httpClient.GetMultipleDataRequest(Configuration.PromoitCampaignFunctions, _campaign, "GetAllCampaignsNonProfit");
            }
            catch { return null; }

            if ((mode ?? Configuration.DatabaseMode) == Modes.MySQL)
            {
                // Error, no npo user
                if (_campaign.NonProfitUser.UserName == null) throw new Exception("No set for npo User");
                mySQL.Quary("SELECT * FROM campaigns where non_profit_user_name=@np_user_name"); //replace with mySQL.Procedure() //add LIMIT 20 ~
                mySQL.ProcedureParameter("np_user_name", _campaign.NonProfitUser.UserName);
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

        public async Task<DataTable> GetAllCampaignsNonProfit_DataTableAsync()
        {
            DataTable dataTable = new DataTable();
            List<Campaign> campaignsList = await MySql_GetAllCampaignsNonProfit_ListAsync();
            foreach (string culmn in new[] { "clmnCampaignName", "clmnHashtag", "clmnWebsite", "clmnCreator" })
                dataTable.Columns.Add(culmn);

            if (campaignsList == null)
            {
                while (Configuration.IsTries())
                    return await new ActionsCampaign(_campaign).GetAllCampaignsNonProfit_DataTableAsync();
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

        public async Task<List<Campaign>> MySQL_GetAllCampaigns_ListAsync(Modes mode = null)
        {
            try
            {   //Queue and Functions
                if ((mode ?? Configuration.Mode) == Modes.Queue)
                    return await httpClient.GetMultipleDataRequest(Configuration.PromoitCampaignQueue, _campaign, "GetAllCampaigns");
                else if ((mode ?? Configuration.Mode) == Modes.Functions)
                    return await httpClient.GetMultipleDataRequest(Configuration.PromoitCampaignFunctions, _campaign, "GetAllCampaigns");
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

        public async Task<DataTable> GetAllCampaigns_DataTableAsync()
        {
            DataTable dataTable = new DataTable();
            List<Campaign> campaignsList = await new ActionsCampaign(_campaign).MySQL_GetAllCampaigns_ListAsync();
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
