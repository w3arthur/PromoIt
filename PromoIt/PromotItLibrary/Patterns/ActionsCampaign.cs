using MySql.Data.MySqlClient;
using PromotItLibrary.Classes;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns.DataTables;
using PromotItLibrary.Patterns.LinkedLists;
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
        private LinkedListCampaign linkedListCampaign;
        private DataTableCampaign dataTableCampaign;


        private List<Campaign> _campaignList;
        private DataTable _campaignTable;
        private string _logMessage;
        private bool _result;

        public ActionsCampaign(Campaign campaign)
        { 
            _campaign = campaign;
            linkedListCampaign = new LinkedListCampaign(_campaign, mySQL, httpClient);
            dataTableCampaign = new DataTableCampaign(_campaign);
        }
        // private Campaign _campaign;
        // new ActionsCampaign(_campaign).foo();
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


        public async Task<List<Campaign>> MySql_GetAllCampaignsNonProfit_ListAsync(Modes mode = null) =>
            await linkedListCampaign.MySql_GetAllCampaignsNonProfit_ListAsync(mode);

        public async Task<DataTable> GetAllCampaignsNonProfit_DataTableAsync() =>
            await dataTableCampaign.GetAllCampaignsNonProfit_DataTableAsync();

        public async Task<List<Campaign>> MySQL_GetAllCampaigns_ListAsync(Modes mode = null) =>
            await linkedListCampaign.MySQL_GetAllCampaigns_ListAsync(mode);

        public async Task<DataTable> GetAllCampaigns_DataTableAsync() => 
            await dataTableCampaign.GetAllCampaigns_DataTableAsync();
    }
}
