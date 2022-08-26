using MySql.Data.MySqlClient;
using PromotItLibrary.Classes;
using PromotItLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PromotItLibrary.Patterns.LinkedLists;
using PromotItLibrary.Patterns.DataTables;
using PromotItLibrary.Patterns.Actions;

namespace PromotItLibrary.Patterns
{
    public class BuilderUser
    {
        private static MySQL mySQL = Configuration.MySQL;
        private HTTPClient httpClient = Configuration.HTTPClient;

        private Users _user;
        private ActivistUser _activistUser;
        private AdminUser _adminUser;
        private NonProfitUser _nonProfitUser;
        private BusinessUser _businessUser;

        private ActionsUser actionsUser;
        private LinkeListUser linkeListUser;
        private DataTableUser dataTableUser;

        //private List<Users> _userList;
        //private DataTable _userTable;
        //private string _logMessahe;
        //private bool _result;
        public BuilderUser(Users user) => actionsUser = new ActionsUser(user, mySQL, httpClient);
        public BuilderUser(ActivistUser activistUser) => actionsUser = new ActionsUser(activistUser, mySQL, httpClient);
        public BuilderUser(AdminUser adminUser) 
        { 
            _adminUser = adminUser;
            actionsUser = new ActionsUser(adminUser, mySQL, httpClient);
            linkeListUser = new LinkeListUser(adminUser, mySQL, httpClient);
            dataTableUser = new DataTableUser(adminUser);
        }
        public BuilderUser(NonProfitUser nonProfitUser) => actionsUser = new ActionsUser(nonProfitUser, mySQL, httpClient);
        public BuilderUser(BusinessUser businessUser) => actionsUser = new ActionsUser(businessUser, mySQL, httpClient);
        //public T Builder<T>(T _log){
        //    if (_logMessahe) return T;
        //    return T;
        //}


        //Actions
        public async Task<Users> LoginAsync(Modes mode = null) =>
            await actionsUser.LoginAsync(mode);
        public async Task<bool> RegisterAsync(Modes mode = null) =>
            await actionsUser.RegisterAsync(mode);
        public async Task<ActivistUser> GetCashAmountAsync(Modes mode = null) =>
            await actionsUser.GetCashAmountAsync(mode);

        //LinkedList and DataTable
        public async Task<List<Users>> MySQL_GetAllUsers_ListAsync(Modes mode = null) =>
            await linkeListUser.MySQL_GetAllUsers_ListAsync(mode);
        public async Task<DataTable> GetAllUsers_DataTableAsync() =>
            await dataTableUser.GetAllUsers_DataTableAsync();
        public async Task<DataTable> GetAllCampaignsAdmin_DataTableAsync() =>
            await dataTableUser.GetAllCampaignsAdmin_DataTableAsync();

    }
}
