using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using PromotItLibrary.Classes;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns.LinkedLists.LinkedList_Function_State.LinkedLists_Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns.LinkedLists.LinkedList_Function_State
{
    public class LinkeListUser_Function : ILinkeListUser
    {

        private static MySQL mySQL;
        private HTTPClient httpClient;

        private AdminUser _adminUser;


        public LinkeListUser_Function(AdminUser adminUser, MySQL _mySQL, HTTPClient _httpClient) 
        {
            _adminUser = adminUser;
            mySQL= _mySQL;
            httpClient = _httpClient;
        }


        public async Task<List<Users>> MySQL_GetAllUsers_ListAsync()
        {
            return await httpClient.GetMultipleDataRequest(Configuration.SetUserFunctions, new Users(), "GetAllUsers");
        }

    }
}
