using MySql.Data.MySqlClient;
using PromotItLibrary.Classes;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns.Actions.Actions_Fuction_State;
using PromotItLibrary.Patterns.Actions.Actions_Interfaces;
using PromotItLibrary.Patterns.Actions.Actions_MySql_State;
using PromotItLibrary.Patterns.Actions.Actions_Queue_State;
using PromotItLibrary.Patterns.Actions;
using PromotItLibrary.Patterns.LinkedLists.LinkedList_Function_State.LinkedLists_Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromotItLibrary.Patterns.LinkedLists.Queue_State;
using PromotItLibrary.Patterns.LinkedLists.LinkedList_Function_State;
using PromotItLibrary.Patterns.LinkedLists.LinkedLists_MySql_State;
using PromotItLibrary.Enums;
using PromotItLibrary.Interfaces;

namespace PromotItLibrary.Patterns.LinkedLists
{
    public class LinkedListCampaign : ILinkedListCampaign
    {

        private static MySQL mySQL;
        private HTTPClient httpClient;
        private Campaign _campaign;
        ILinkedListCampaign linkedListCampaign;

        public LinkedListCampaign(Campaign campaign, MySQL _mySQL, HTTPClient _httpClient) 
        {
            _campaign = campaign;
            mySQL = _mySQL;
            httpClient = _httpClient;
        }

        private ILinkedListCampaign LinkedListMode(Modes _mode)
        {
            if ((_mode ?? Configuration.Mode) == Modes.Queue)
                linkedListCampaign = new LinkedListCampaign_Queue(_campaign, mySQL, httpClient);
            else if ((_mode ?? Configuration.Mode) == Modes.Functions)
                linkedListCampaign = new LinkedListCampaign_Function(_campaign, mySQL, httpClient);
            if ((_mode ?? Configuration.DatabaseMode) == Modes.MySQL)
                linkedListCampaign = new LinkedListCampaign_MySql(_campaign, mySQL, httpClient);
            return linkedListCampaign;
        }

        public async Task<List<ICampaign>> MySql_GetAllCampaignsNonProfit_ListAsync(Modes mode = null)
        {
            return await LinkedListMode(mode).MySql_GetAllCampaignsNonProfit_ListAsync();
        }

        public async Task<List<ICampaign>> MySQL_GetAllCampaigns_ListAsync(Modes mode = null)
        {
            return await LinkedListMode(mode).MySQL_GetAllCampaigns_ListAsync();
        }

    }
}
