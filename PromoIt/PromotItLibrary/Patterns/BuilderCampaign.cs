using MySql.Data.MySqlClient;
using PromotItLibrary.Classes;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns.Actions;
using PromotItLibrary.Patterns.DataTables;
using PromotItLibrary.Patterns.LinkedLists;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns
{
    public class BuilderCampaign
    {
        private static MySQL mySQL = Configuration.MySQL;
        private HTTPClient httpClient = Configuration.HTTPClient;
        private Campaign _campaign;

        private ActionsCampaign actionsCampaign;
        private LinkedListCampaign linkedListCampaign;
        private DataTableCampaign dataTableCampaign;


        //private List<Campaign> _campaignList;
        //private DataTable _campaignTable;
        //private string _logMessage;
        //private bool _result;

        public BuilderCampaign(Campaign campaign)
        { 
            _campaign = campaign;
            actionsCampaign = new ActionsCampaign(_campaign, mySQL, httpClient);
            linkedListCampaign = new LinkedListCampaign(_campaign, mySQL, httpClient);
            dataTableCampaign = new DataTableCampaign(_campaign);
        }
        // private Campaign _campaign;
        // new ActionsCampaign(_campaign).foo();
        //public T Builder<T>(T _log){
        //    if (_logMessahe) return T;
        //    return T;
        //}


        //Actions
        public async Task<bool> SetNewCampaignAsync(Modes mode = null) =>
            await SetNewCampaignAsync(mode);

        public async Task<bool> DeleteCampaignAsync(Modes mode = null) =>
            await actionsCampaign.DeleteCampaignAsync(mode);

        //List and DataTable
        public async Task<List<Campaign>> MySql_GetAllCampaignsNonProfit_ListAsync(Modes mode = null) =>
            await linkedListCampaign.MySql_GetAllCampaignsNonProfit_ListAsync(mode);

        public async Task<DataTable> GetAllCampaignsNonProfit_DataTableAsync() =>
            await dataTableCampaign.GetAllCampaignsNonProfit_DataTableAsync();

        public async Task<List<Campaign>> MySQL_GetAllCampaigns_ListAsync(Modes mode = null) =>
            await linkedListCampaign.MySQL_GetAllCampaigns_ListAsync(mode);

        public async Task<DataTable> GetAllCampaigns_DataTableAsync() => 
            await dataTableCampaign.GetAllCampaigns_DataTableAsync();
    }
}
