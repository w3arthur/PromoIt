using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using PromotItLibrary.Classes.Users;
using PromotItLibrary.Enums;
using PromotItLibrary.Interfaces.LinkedList;
using PromotItLibrary.Interfaces.Users;
using PromotItLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns.LinkedLists.LinkedList_Function_State
{
    public class LinkeListUser_Function : ILinkeListUser_Admin
    {

        private readonly HTTPClient _httpClient;
        private readonly AdminUser _adminUser;

        public LinkeListUser_Function(AdminUser adminUser, HTTPClient httpClient) 
        {
            _httpClient = httpClient;
            _adminUser = adminUser;
        }


        public async Task<List<IUsers>> GetAllUsers_ListAsync(Modes mode = null)
        {
            return await _httpClient.GetMultipleDataRequest<IUsers>(Configuration.SetUserFunctions, null, "GetAllUsers");
        }

    }
}
