using PromotItLibrary.Classes;
using PromotItLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns.Actions
{
    public class ActionsCampaign
    {
        private static MySQL mySQL;
        private HTTPClient httpClient;
        private Campaign _campaign;

        private Modes _mode = null;


        public ActionsCampaign(Campaign campaign, MySQL _mySQL, HTTPClient _httpClient)
        {
            _campaign = campaign;
            mySQL = _mySQL;
            httpClient = _httpClient;
        }


        public async Task<bool> SetNewCampaignAsync(Modes mode = null)
        {
            _mode = mode;

            try
            {   //Queue and Functions
                if ((_mode ?? Configuration.Mode) == Modes.Queue)
                    return (bool)await httpClient.PostSingleDataInsert(Configuration.PromoitCampaignQueue, _campaign, "SetNewCampaign");
                else if ((_mode ?? Configuration.Mode) == Modes.Functions)
                    return (bool)await httpClient.PostSingleDataInsert(Configuration.PromoitCampaignFunctions, _campaign, "SetNewCampaign");
            }
            catch { return false; }

            if ((_mode ?? Configuration.DatabaseMode) == Modes.MySQL)
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


    }
}
