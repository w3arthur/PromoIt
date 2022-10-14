using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using PromotItLibrary.Enums;
using PromotItLibrary.Interfaces;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns;
using PromotItLibrary.Patterns.Actions;
using PromotItLibrary.Patterns.Actions.Actions_Fuction_State;
using PromotItLibrary.Patterns.Actions.Actions_MySql_State;
using PromotItLibrary.Patterns.Actions.Actions_Queue_State;
using PromotItLibrary.Patterns.LinkedLists;
using PromotItLibrary.Patterns.LinkedLists.DataTables_Interfaces;
using PromotItLibrary.Patterns.LinkedLists.LinkedList_Function_State;
using PromotItLibrary.Patterns.LinkedLists.LinkedList_Function_State.LinkedLists_Interfaces;
using PromotItLibrary.Patterns.LinkedLists.LinkedLists_MySql_State;
using PromotItLibrary.Patterns.LinkedLists.Queue_State;

namespace PromotItLibrary.Classes
{
    public class AdminUser : Users, IAdminUser, ILinkeListUser_Admin, IDataTableUser_Admin
    {
        private readonly ILinkeListUser_Admin linkeListUser;
        private readonly IDataTableUser_Admin dataTableUser;

        public AdminUser() : base() {
            UserType = "admin";
            RunActions(this);

            //LinkedList States
            if ((_mode ?? Configuration.Mode) == Modes.Queue)
                linkeListUser = new LinkeListUser_Queue(this, _mySQL, _httpClient);
            else if ((_mode ?? Configuration.Mode) == Modes.Functions)
                linkeListUser = new LinkeListUser_Function(this, _mySQL, _httpClient);
            if ((_mode ?? Configuration.DatabaseMode) == Modes.MySQL)
                linkeListUser = new LinkeListUser_MySql(this, _mySQL, _httpClient);

            //DataTable States ?
            dataTableUser = new DataTableUser_Admin(this);
        }

        public AdminUser(IUsers user) : this() {
            CopyUser(user);
        }

        //LinkedList
        public async Task<List<IUsers>> GetAllUsers_ListAsync(Modes mode = null) =>
            await linkeListUser.GetAllUsers_ListAsync(mode);

        //DataTable
        public async Task<DataTable> GetAllUsers_DataTableAsync() =>
            await dataTableUser.GetAllUsers_DataTableAsync();
        public async Task<DataTable> GetAllCampaignsAdmin_DataTableAsync() =>
            await dataTableUser.GetAllCampaignsAdmin_DataTableAsync();

    }
}
