using PromotItLibrary.Classes;
using PromotItLibrary.Enums;
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
        private readonly MySQL _mySQL;
        private readonly Campaign _campaign;

        public ActionsCampaign_MySql(Campaign campaign, MySQL mySQL)
        {
            _campaign = campaign;
            _mySQL = mySQL;
        }


        public async Task<bool> SetNewCampaignAsync(Modes mode = null)
        {
            _mySQL.Procedure("add_campaign");
            _mySQL.SetParameter("_name", _campaign.Name);
            _mySQL.SetParameter("_hashtag", _campaign.Hashtag);
            _mySQL.SetParameter("_webpage", _campaign.Url);
            _mySQL.SetParameter("_non_profit_user_name", _campaign.NonProfitUser.UserName);
            return await _mySQL.ProceduteExecuteAsync();
        }

        public async Task<bool> DeleteCampaignAsync(Modes mode = null)
        {
            _mySQL.Procedure("delete_campaign");
            _mySQL.QuaryParameter("_hashtag", _campaign.Hashtag);
            return await _mySQL.ProceduteExecuteAsync();
        }

    }
}
