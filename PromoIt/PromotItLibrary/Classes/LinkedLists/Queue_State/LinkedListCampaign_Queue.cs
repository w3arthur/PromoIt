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

namespace PromotItLibrary.Patterns.LinkedLists.Queue_State
{
    public class LinkedListCampaign_Queue : ILinkedListCampaign
    {

        private readonly HTTPClient _httpClient;
        private readonly ICampaign _campaign;

        public LinkedListCampaign_Queue(Campaign campaign, HTTPClient _httpClient) 
        {
            _campaign = campaign;
            this._httpClient = _httpClient;
        }

        public async Task<List<ICampaign>> GetAllCampaignsNonProfit_ListAsync(Modes mode = null)
        {
            return await _httpClient.GetMultipleDataRequest(Configuration.PromoitCampaignQueue, _campaign, "GetAllCampaignsNonProfit");
        }

        public async Task<List<ICampaign>> GetAllCampaigns_ListAsync(Modes mode = null)
        {
            return await _httpClient.GetMultipleDataRequest(Configuration.PromoitCampaignQueue, _campaign, "GetAllCampaigns");
        }

    }
}
