using PromotItLibrary.Classes;
using PromotItLibrary.Enums;
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
    public class ActionsCampaign : IActionsCampaign
    {
        private readonly MySQL _mySQL;
        private readonly HTTPClient _httpClient;
        private readonly Campaign _campaign;
        private IActionsCampaign actionsCampaign;

        public ActionsCampaign(Campaign campaign, MySQL mySQL, HTTPClient httpClient)
        {
            _campaign = campaign;
            _mySQL = mySQL;
            _httpClient = httpClient;
        }

        private IActionsCampaign ActionMode(Modes _mode) 
        {
            if ((_mode ?? Configuration.Mode) == Modes.Queue)
                actionsCampaign = new ActionsCampaign_Queue(_campaign, _httpClient);
            else if ((_mode ?? Configuration.Mode) == Modes.Functions)
                actionsCampaign = new ActionsCampaign_Function(_campaign, _httpClient);
            if ((_mode ?? Configuration.DatabaseMode) == Modes.MySQL)
                actionsCampaign = new ActionsCampaign_MySql(_campaign, _mySQL);
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
