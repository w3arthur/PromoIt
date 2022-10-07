using MySql.Data.MySqlClient;
using PromotItLibrary.Enums;
using PromotItLibrary.Interfaces;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns;
using PromotItLibrary.Patterns.Actions;
using PromotItLibrary.Patterns.Actions.Actions_Interfaces;
using PromotItLibrary.Patterns.DataTables;
using PromotItLibrary.Patterns.LinkedLists;
using PromotItLibrary.Patterns.LinkedLists.LinkedList_Function_State.LinkedLists_Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Classes
{
    public class Campaign : ICampaign, IActionsCampaign, ILinkedListCampaign
    {
        //Move to Interfaces
        private static MySQL mySQL = Configuration.MySQL;
        private HTTPClient httpClient = Configuration.HTTPClient;

        private ActionsCampaign actionsCampaign;
        private LinkedListCampaign linkedListCampaign;
        private DataTableCampaign dataTableCampaign;

        public string Name { get; set; }
        public string Hashtag { get; set; }
        public string Url { get; set; }
        public IUsers NonProfitUser { get; set; }



        public Campaign() 
        {
            actionsCampaign = new ActionsCampaign(this, mySQL, httpClient);
            linkedListCampaign = new LinkedListCampaign(this, mySQL, httpClient);
            dataTableCampaign = new DataTableCampaign(this);
        }


        //Actions
        public async Task<bool> SetNewCampaignAsync(Modes mode = null) =>
        await actionsCampaign.SetNewCampaignAsync(mode);

        public async Task<bool> DeleteCampaignAsync(Modes mode = null) =>
            await actionsCampaign.DeleteCampaignAsync(mode);

        //List and DataTable
        public async Task<List<ICampaign>> MySql_GetAllCampaignsNonProfit_ListAsync(Modes mode = null) =>
            await linkedListCampaign.MySql_GetAllCampaignsNonProfit_ListAsync(mode);

        public async Task<DataTable> GetAllCampaignsNonProfit_DataTableAsync() =>
            await dataTableCampaign.GetAllCampaignsNonProfit_DataTableAsync();

        public async Task<List<ICampaign>> MySQL_GetAllCampaigns_ListAsync(Modes mode = null) =>
            await linkedListCampaign.MySQL_GetAllCampaigns_ListAsync(mode);

        public async Task<DataTable> GetAllCampaigns_DataTableAsync() =>
            await dataTableCampaign.GetAllCampaigns_DataTableAsync();
    }
}