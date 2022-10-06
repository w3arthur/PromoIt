using PromotItLibrary.Classes;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns.Actions.Actions_Fuction_State;
using PromotItLibrary.Patterns.Actions.Actions_Interfaces;
using PromotItLibrary.Patterns.Actions.Actions_MySql_State;
using PromotItLibrary.Patterns.Actions.Actions_Queue_State;
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
        IActionsCampaign actionsCampaign;

        public ActionsCampaign(Campaign campaign, MySQL _mySQL, HTTPClient _httpClient)
        {
            _campaign = campaign;
            mySQL = _mySQL;
            httpClient = _httpClient;
        }

        private IActionsCampaign ActionMode(Modes _mode) 
        {
            if ((_mode ?? Configuration.Mode) == Modes.Queue)
                actionsCampaign = new ActionsCampaign_Queue(_campaign, mySQL, httpClient);
            else if ((_mode ?? Configuration.Mode) == Modes.Functions)
                actionsCampaign = new ActionsCampaign_Function(_campaign, mySQL, httpClient);
            if ((_mode ?? Configuration.DatabaseMode) == Modes.MySQL)
                actionsCampaign = new ActionsCampaign_MySql(_campaign, mySQL, httpClient);
            return actionsCampaign;
        }


        public async Task<bool> SetNewCampaignAsync(Modes mode = null)
        {
            return await ActionMode(mode).SetNewCampaignAsync();
        }

        public async Task<bool> DeleteCampaignAsync(Modes mode = null)
        {
            return await ActionMode(mode).DeleteCampaignAsync();
        }


    }
}
