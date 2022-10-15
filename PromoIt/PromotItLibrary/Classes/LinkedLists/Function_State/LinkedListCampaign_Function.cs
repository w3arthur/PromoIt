using MySql.Data.MySqlClient;
using PromotItLibrary.Classes;
using PromotItLibrary.Enums;
using PromotItLibrary.Interfaces;
using PromotItLibrary.Interfaces.LinkedList;
using PromotItLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns.LinkedLists.LinkedList_Function_State
{
    public class LinkedListCampaign_Function : ILinkedListCampaign
    {

        private readonly HTTPClient _httpClient;
        private readonly ICampaign _campaign;

        public LinkedListCampaign_Function(ICampaign campaign, HTTPClient httpClient) 
        {
            _campaign = campaign;
            _httpClient = httpClient;
        }

        public async Task<List<ICampaign>> GetAllCampaignsNonProfit_ListAsync(Modes mode = null)
        {
            return await _httpClient.GetMultipleDataRequest(Configuration.PromoitCampaignFunctions, _campaign, "GetAllCampaignsNonProfit");
        }

        public async Task<List<ICampaign>> GetAllCampaigns_ListAsync(Modes mode = null)
        {
            return await _httpClient.GetMultipleDataRequest(Configuration.PromoitCampaignFunctions, _campaign, "GetAllCampaigns");
        }

    }
}
