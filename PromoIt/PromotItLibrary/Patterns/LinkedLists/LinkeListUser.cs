using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using PromotItLibrary.Classes;
using PromotItLibrary.Models;
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


        public LinkeListUser(AdminUser adminUser, MySQL _mySQL, HTTPClient _httpClient) 
        {
            _adminUser = adminUser;
            mySQL= _mySQL;
            httpClient = _httpClient;
        }


        public async Task<List<Users>> MySQL_GetAllUsers_ListAsync(Modes mode = null)
        {
            if (_adminUser == null) return null;

            try
            {   //Queue and Functions
                if ((mode ?? Configuration.Mode) == Modes.Queue)
                    return await httpClient.GetMultipleDataRequest(Configuration.SetUserQueue, new Users(), "GetAllUsers");
                if ((mode ?? Configuration.Mode) == Modes.Functions)
                    return await httpClient.GetMultipleDataRequest(Configuration.SetUserFunctions, new Users(), "GetAllUsers");
            }
            catch { return null; }

            if ((mode ?? Configuration.DatabaseMode) == Modes.MySQL)
            {
                mySQL.Quary("SELECT name,user_name,user_type FROM users");
                using MySqlDataReader results = await mySQL.ProceduteExecuteMultyResultsAsync();
                List<Users> userList = new List<Users>();
                while (results != null && results.Read()) //for 1 result: if (mdr.Read())
                {
                    try
                    {
                        userList.Add
                            (
                                new Users()
                                {
                                    Name = results.GetString("name"),
                                    UserName = results.GetString("user_name"),
                                    UserType = results.GetString("user_type"),
                                }
                            );
                    }
                    catch { };
                }
                return userList;
            }
            return null;
        }

    }
}
