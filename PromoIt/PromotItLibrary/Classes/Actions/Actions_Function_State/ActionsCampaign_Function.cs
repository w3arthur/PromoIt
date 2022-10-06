using PromotItLibrary.Classes;
using PromotItLibrary.Enums;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns.Actions.Actions_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns.Actions.Actions_Fuction_State
{
    public class ActionsCampaign_Function : IActionsCampaign
    {
        private static MySQL mySQL;
        private HTTPClient httpClient;
        private Campaign _campaign;

        private Modes _mode = null;

        public ActionsCampaign_Function(Campaign campaign, MySQL _mySQL, HTTPClient _httpClient)
        {
            _campaign = campaign;
            httpClient = _httpClient;
        }


        public async Task<bool> SetNewCampaignAsync(Modes mode = null)
        {
            return (bool)await httpClient.PostSingleDataInsert(Configuration.PromoitCampaignFunctions, _campaign, "SetNewCampaign");
        }

        public async Task<bool> DeleteCampaignAsync(Modes mode = null)
        {
            return (bool)await httpClient.PostSingleDataInsert(Configuration.PromoitCampaignFunctions, _campaign, "DeleteCampaign");
        }


    }
}
