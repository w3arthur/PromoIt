using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using PromotItLibrary.Classes;
using PromotItLibrary.Enums;
using PromotItLibrary.Interfaces;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns.LinkedLists.LinkedList_Function_State;
using PromotItLibrary.Patterns.LinkedLists.LinkedList_Function_State.LinkedLists_Interfaces;
using PromotItLibrary.Patterns.LinkedLists.LinkedLists_MySql_State;
using PromotItLibrary.Patterns.LinkedLists.Queue_State;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns.LinkedLists
{
    public class LinkeListUser_Admin : ILinkeListUser_Admin
    {

        private static MySQL mySQL;
        private HTTPClient httpClient;
        private AdminUser _adminUser;
        ILinkeListUser_Admin linkeListUser;

        public LinkeListUser_Admin(AdminUser adminUser, MySQL _mySQL, HTTPClient _httpClient) 
        {
            _adminUser = adminUser;
            mySQL= _mySQL;
            httpClient = _httpClient;
        }
        private ILinkeListUser_Admin LinkedListMode(Modes _mode)  //only for admin
        {
            if ((_mode ?? Configuration.Mode) == Modes.Queue)
                linkeListUser = new LinkeListUser_Queue(_adminUser, mySQL, httpClient);
            else if ((_mode ?? Configuration.Mode) == Modes.Functions)
                linkeListUser = new LinkeListUser_Function(_adminUser, mySQL, httpClient);
            if ((_mode ?? Configuration.DatabaseMode) == Modes.MySQL)
                linkeListUser = new LinkeListUser_MySql(_adminUser, mySQL, httpClient);
            return linkeListUser;
        }

        public async Task<List<IUsers>> GetAllUsers_ListAsync(Modes mode = null)
        {
            if (_adminUser == null) return null;
            return await LinkedListMode(mode).GetAllUsers_ListAsync();
        }

    }
}
