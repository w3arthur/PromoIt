using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using PromotItLibrary.Enums;
using PromotItLibrary.Interfaces.DataTables;
using PromotItLibrary.Interfaces.LinkedList;
using PromotItLibrary.Interfaces.Users;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns.LinkedLists;
using PromotItLibrary.Patterns.LinkedLists.LinkedList_Function_State;
using PromotItLibrary.Patterns.LinkedLists.LinkedLists_MySql_State;
using PromotItLibrary.Patterns.LinkedLists.Queue_State;

namespace PromotItLibrary.Classes.Users
{
    public class AdminUser : Users, IAdminUser, ILinkeListUser_Admin, IDataTableUser_Admin
    {
        private readonly ILinkeListUser_Admin linkeListUser;
        private readonly IDataTableUser_Admin dataTableUser;

        public AdminUser() : base()
        {
            UserType = "admin";
            RunActions(this);

            //LinkedList States Admin
            if ((_mode ?? Configuration.Mode) == Modes.Queue)
                linkeListUser = new LinkeListUser_Queue(this, _httpClient);
            else if ((_mode ?? Configuration.Mode) == Modes.Functions)
                linkeListUser = new LinkeListUser_Function(this, _httpClient);
            if ((_mode ?? Configuration.DatabaseMode) == Modes.MySQL)
                linkeListUser = new LinkeListUser_MySql(this, _mySQL);

            //DataTable Admin
            dataTableUser = new DataTableUser_Admin(this);
        }

        public AdminUser(IUsers user) : this() { CopyUser(user); }

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
