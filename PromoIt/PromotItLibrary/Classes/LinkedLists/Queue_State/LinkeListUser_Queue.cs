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

namespace PromotItLibrary.Patterns.LinkedLists.Queue_State
{
    public class LinkeListUser_Queue : ILinkeListUser_Admin
    {

        private readonly HTTPClient _httpClient;
        private readonly AdminUser _adminUser;

        public LinkeListUser_Queue(AdminUser adminUser, HTTPClient _httpClient) 
        {
            this._httpClient = _httpClient;
        }


        public async Task<List<IUsers>> GetAllUsers_ListAsync(Modes mode = null)
        {
            return await _httpClient.GetMultipleDataRequest<IUsers>(Configuration.SetUserQueue, null, "GetAllUsers");
        }

    }
}
