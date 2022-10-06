using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using PromotItLibrary.Classes;
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
    public class LinkeListUser
    {

        private static MySQL mySQL;
        private HTTPClient httpClient;
        private AdminUser _adminUser;
        ILinkeListUser linkeListUser;

        public LinkeListUser(AdminUser adminUser, MySQL _mySQL, HTTPClient _httpClient) 
        {
            _adminUser = adminUser;
            mySQL= _mySQL;
            httpClient = _httpClient;
        }
        private ILinkeListUser LinkedListMode(Modes _mode)  //only for admin
        {
            if ((_mode ?? Configuration.Mode) == Modes.Queue)
                linkeListUser = new LinkeListUser_Queue(_adminUser, mySQL, httpClient);
            else if ((_mode ?? Configuration.Mode) == Modes.Functions)
                linkeListUser = new LinkeListUser_Function(_adminUser, mySQL, httpClient);
            if ((_mode ?? Configuration.DatabaseMode) == Modes.MySQL)
                linkeListUser = new LinkeListUser_MySql(_adminUser, mySQL, httpClient);
            return linkeListUser;
        }

        public async Task<List<Users>> MySQL_GetAllUsers_ListAsync(Modes mode = null)
        {
            if (_adminUser == null) return null;
            return await LinkedListMode(mode).MySQL_GetAllUsers_ListAsync();
        }

    }
}
