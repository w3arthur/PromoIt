using PromotItLibrary.Classes;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns.Actions.Actions_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns.Actions.Actions_MySql_State
{
    public class ActionsCampaign_MySql : IActionsCampaign
    {
        private static MySQL mySQL;
        private HTTPClient httpClient;
        private Campaign _campaign;

        private Modes _mode = null;

        public ActionsCampaign_MySql(Campaign campaign, MySQL _mySQL, HTTPClient _httpClient)
        {
            _campaign = campaign;
            mySQL = _mySQL;
        }


        public async Task<bool> SetNewCampaignAsync()
        {
            mySQL.Procedure("add_campaign");
            mySQL.SetParameter("_name", _campaign.Name);
            mySQL.SetParameter("_hashtag", _campaign.Hashtag);
            mySQL.SetParameter("_webpage", _campaign.Url);
            mySQL.SetParameter("_non_profit_user_name", _campaign.NonProfitUser.UserName);
            return await mySQL.ProceduteExecuteAsync();
        }

        public async Task<bool> DeleteCampaignAsync()
        {
            mySQL.Procedure("delete_campaign");
            mySQL.QuaryParameter("_hashtag", _campaign.Hashtag);
            return await mySQL.ProceduteExecuteAsync();
        }

    }
}
