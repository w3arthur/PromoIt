using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using PromotItLibrary.Classes;
using PromotItLibrary.Enums;
using PromotItLibrary.Interfaces;
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
    public class LinkeListUser_MySql : ILinkeListUser_Admin
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


        public async Task<List<IUsers>> MySQL_GetAllUsers_ListAsync(Modes mode = null)
        {
            mySQL.Quary("SELECT name,user_name,user_type FROM users");
            using MySqlDataReader results = await mySQL.ProceduteExecuteMultyResultsAsync();
            List<IUsers> userList = new List<IUsers>();
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
