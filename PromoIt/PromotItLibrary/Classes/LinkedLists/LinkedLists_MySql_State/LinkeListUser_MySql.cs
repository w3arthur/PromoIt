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

namespace PromotItLibrary.Patterns.LinkedLists.LinkedLists_MySql_State
{
    public class LinkeListUser_MySql : ILinkeListUser
    {

        private static MySQL mySQL;
        private HTTPClient httpClient;

        private AdminUser _adminUser;


        public LinkeListUser_MySql(AdminUser adminUser, MySQL _mySQL, HTTPClient _httpClient) 
        {
            _adminUser = adminUser;
            mySQL= _mySQL;
            httpClient = _httpClient;
        }


        public async Task<List<Users>> MySQL_GetAllUsers_ListAsync()
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

    }
}
