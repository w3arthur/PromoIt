using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using PromotItLibrary.Enums;
using PromotItLibrary.Interfaces;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns;
using PromotItLibrary.Patterns.Actions;
using PromotItLibrary.Patterns.Actions.Actions_Fuction_State;
using PromotItLibrary.Patterns.Actions.Actions_Interfaces;
using PromotItLibrary.Patterns.Actions.Actions_MySql_State;
using PromotItLibrary.Patterns.Actions.Actions_Queue_State;
using PromotItLibrary.Patterns.DataTables;
using PromotItLibrary.Patterns.LinkedLists;
using PromotItLibrary.Patterns.LinkedLists.LinkedList_Function_State.LinkedLists_Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PromotItLibrary.Classes
{
    public class Campaign : ICampaign, IActionsCampaign, ILinkedListCampaign
    {
        //Move to Interfaces
        private static MySQL _mySQL = Configuration.MySQL;
        private HTTPClient _httpClient = Configuration.HTTPClient;
        Modes _mode;
        private IActionsCampaign actionsCampaign;
        private LinkedListCampaign linkedListCampaign;
        private DataTableCampaign dataTableCampaign;

        public string Name { get; set; }
        public string Hashtag { get; set; }
        public string Url { get; set; }
        public IUsers NonProfitUser { get; set; }




        public Campaign() 
        {
            //Action
            if ((_mode ?? Configuration.Mode) == Modes.Queue)
                actionsCampaign = new ActionsCampaign_Queue(this, _httpClient);
            else if ((_mode ?? Configuration.Mode) == Modes.Functions)
                actionsCampaign = new ActionsCampaign_Function(this, _httpClient);
            if ((_mode ?? Configuration.DatabaseMode) == Modes.MySQL)
                actionsCampaign = new ActionsCampaign_MySql(this, _mySQL);



            linkedListCampaign = new LinkedListCampaign(this, _mySQL, _httpClient);
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