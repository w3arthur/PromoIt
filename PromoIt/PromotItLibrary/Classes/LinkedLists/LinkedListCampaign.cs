using MySql.Data.MySqlClient;
using PromotItLibrary.Classes;
using PromotItLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns.LinkedLists
{
    public class LinkedListCampaign
    {

        private static MySQL mySQL;
        private HTTPClient httpClient;
        private Campaign _campaign;

        public LinkedListCampaign(Campaign campaign, MySQL _mySQL, HTTPClient _httpClient) 
        {
            _campaign = campaign;
            mySQL = _mySQL;
            httpClient = _httpClient;
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

    }
}
