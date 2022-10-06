using MySql.Data.MySqlClient;
using PromotItLibrary.Classes;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns.LinkedLists.LinkedList_Function_State.LinkedLists_Interfaces;
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

        private static MySQL mySQL;
        private HTTPClient httpClient;
        private Campaign _campaign;

        public LinkedListCampaign_Function(Campaign campaign, MySQL _mySQL, HTTPClient _httpClient) 
        {
            _campaign = campaign;
            mySQL = _mySQL;
            httpClient = _httpClient;
        }

        public async Task<List<Campaign>> MySql_GetAllCampaignsNonProfit_ListAsync()
        {
            return await httpClient.GetMultipleDataRequest(Configuration.PromoitCampaignFunctions, _campaign, "GetAllCampaignsNonProfit");
        }

        public async Task<List<Campaign>> MySQL_GetAllCampaigns_ListAsync()
        {
            return await httpClient.GetMultipleDataRequest(Configuration.PromoitCampaignFunctions, _campaign, "GetAllCampaigns");
        }

    }
}
