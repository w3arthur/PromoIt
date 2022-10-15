using System;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using PromotItLibrary.Enums;
using PromotItLibrary.Interfaces;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns.Actions.Actions_Fuction_State;
using PromotItLibrary.Patterns.Actions.Actions_MySql_State;
using PromotItLibrary.Patterns.Actions.Actions_Queue_State;
using PromotItLibrary.Patterns.DataTables;
using PromotItLibrary.Patterns.LinkedLists.LinkedList_Function_State;
using PromotItLibrary.Patterns.LinkedLists.LinkedLists_MySql_State;
using PromotItLibrary.Patterns.LinkedLists.Queue_State;
using PromotItLibrary.Interfaces.Actions;
using PromotItLibrary.Interfaces.DataTables;
using PromotItLibrary.Interfaces.LinkedList;
using PromotItLibrary.Interfaces.Users;

namespace PromotItLibrary.Classes
{
    public class Campaign : ICampaign, IActionsCampaign, ILinkedListCampaign
    {
        //Move to Interfaces
        private readonly MySQL _mySQL = Configuration.MySQL;
        private readonly HTTPClient _httpClient = Configuration.HTTPClient;
        private readonly Modes _mode;
        private readonly IActionsCampaign actionsCampaign;
        private readonly ILinkedListCampaign linkedListCampaign;
        private readonly IDataTableCampaign dataTableCampaign;

        public string Name { get; set; }
        public string Hashtag { get; set; }
        public string Url { get; set; }
        public IUsers NonProfitUser { get; set; }

        public Campaign() 
        {
            //Action States
            //LinkedList States
            if ((_mode ?? Configuration.Mode) == Modes.Queue)
            {
                actionsCampaign = new ActionsCampaign_Queue(this, _httpClient);
                linkedListCampaign = new LinkedListCampaign_Queue(this,  _httpClient);
            }
            else if ((_mode ?? Configuration.Mode) == Modes.Functions)
            {
                actionsCampaign = new ActionsCampaign_Function(this, _httpClient);
                linkedListCampaign = new LinkedListCampaign_Function(this,  _httpClient);
            }
            else if ((_mode ?? Configuration.DatabaseMode) == Modes.MySQL)
            {
                actionsCampaign = new ActionsCampaign_MySql(this, _mySQL);
                linkedListCampaign = new LinkedListCampaign_MySql(this, _mySQL);
            }
               
            //DataTable States
            dataTableCampaign = new DataTableCampaign(this);
        }


        //Actions
        public async Task<bool> SetNewCampaignAsync(Modes mode = null) =>
            await actionsCampaign.SetNewCampaignAsync(mode);

        public async Task<bool> DeleteCampaignAsync(Modes mode = null) =>
            await actionsCampaign.DeleteCampaignAsync(mode);

        //List
        public async Task<List<ICampaign>> GetAllCampaignsNonProfit_ListAsync(Modes mode = null) =>
            await linkedListCampaign.GetAllCampaignsNonProfit_ListAsync(mode);
        public async Task<List<ICampaign>> GetAllCampaigns_ListAsync(Modes mode = null) =>
            await linkedListCampaign.GetAllCampaigns_ListAsync(mode);


        //DataTable
        public async Task<DataTable> GetAllCampaignsNonProfit_DataTableAsync() =>
            await dataTableCampaign.GetAllCampaignsNonProfit_DataTableAsync();
        public async Task<DataTable> GetAllCampaigns_DataTableAsync() =>
            await dataTableCampaign.GetAllCampaigns_DataTableAsync();
    }
}