using PromotItLibrary.Classes;
using PromotItLibrary.Enums;
using PromotItLibrary.Interfaces.Actions;
using PromotItLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns.Actions.Actions_Fuction_State
{
    public class ActionsCampaign_Function : IActionsCampaign
    {
        private readonly HTTPClient _httpClient;
        private readonly Campaign _campaign;


        public ActionsCampaign_Function(Campaign campaign, HTTPClient httpClient)
        {
            _campaign = campaign;
            _httpClient = httpClient;
        }


        public async Task<bool> SetNewCampaignAsync(Modes mode = null)
        {
            return (bool)await _httpClient.PostSingleDataInsert(Configuration.PromoitCampaignFunctions, _campaign, "SetNewCampaign");
        }

        public async Task<bool> DeleteCampaignAsync(Modes mode = null)
        {
            return (bool)await _httpClient.PostSingleDataInsert(Configuration.PromoitCampaignFunctions, _campaign, "DeleteCampaign");
        }


    }
}
