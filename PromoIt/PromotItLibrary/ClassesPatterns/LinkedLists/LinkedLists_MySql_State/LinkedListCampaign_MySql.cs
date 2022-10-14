using MySql.Data.MySqlClient;
using PromotItLibrary.Classes;
using PromotItLibrary.Enums;
using PromotItLibrary.Interfaces;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns.LinkedLists.LinkedList_Function_State.LinkedLists_Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns.LinkedLists.LinkedLists_MySql_State
{
    public class LinkedListCampaign_MySql : ILinkedListCampaign
    {

        private readonly MySQL _mySQL;
        private readonly Campaign _campaign;

        public LinkedListCampaign_MySql(Campaign campaign, MySQL mySQL) 
        {
            _campaign = campaign;
            _mySQL = mySQL;
        }

        public async Task<List<ICampaign>> GetAllCampaignsNonProfit_ListAsync(Modes mode = null)
        {
            // Error, no npo user
            if (_campaign.NonProfitUser.UserName == null) throw new Exception("No set for npo User");
            _mySQL.Quary("SELECT * FROM campaigns where non_profit_user_name=@np_user_name"); //replace with mySQL.Procedure() //add LIMIT 20 ~
            _mySQL.ProcedureParameter("np_user_name", _campaign.NonProfitUser.UserName);
            using MySqlDataReader results = await _mySQL.ProceduteExecuteMultyResultsAsync();
            List<ICampaign> campaignsList = new List<ICampaign>();
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

        public async Task<List<ICampaign>> GetAllCampaigns_ListAsync(Modes mode = null)
        {
            _mySQL.Quary("SELECT * FROM campaigns");
            using MySqlDataReader results = await _mySQL.ProceduteExecuteMultyResultsAsync();
            List<ICampaign> campaignsList = new List<ICampaign>();
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

    }
}
