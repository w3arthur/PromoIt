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

namespace PromotItLibrary.Patterns.LinkedLists.Queue_State
{
    public class LinkedListCampaign_Queue : ILinkedListCampaign
    {

        private static MySQL mySQL;
        private HTTPClient httpClient;
        private ICampaign _campaign;

        public LinkedListCampaign_Queue(Campaign campaign, MySQL _mySQL, HTTPClient _httpClient) 
        {
            _campaign = campaign;
            mySQL = _mySQL;
            httpClient = _httpClient;
        }

        public async Task<List<ICampaign>> GetAllCampaignsNonProfit_ListAsync(Modes mode = null)
        {
            return await httpClient.GetMultipleDataRequest(Configuration.PromoitCampaignQueue, _campaign, "GetAllCampaignsNonProfit");
        }

        public async Task<List<ICampaign>> GetAllCampaigns_ListAsync(Modes mode = null)
        {
            return await httpClient.GetMultipleDataRequest(Configuration.PromoitCampaignQueue, _campaign, "GetAllCampaigns");
        }

    }
}
