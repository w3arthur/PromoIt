using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using PromotItLibrary.Classes;
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

namespace PromotItLibrary.Patterns.LinkedLists.LinkedLists_MySql_State
{
    public class LinkeListUser_MySql : ILinkeListUser_Admin
    {

        private readonly MySQL _mySQL;
        private AdminUser _adminUser;

        public LinkeListUser_MySql(AdminUser adminUser, MySQL _mySQL) 
        {
            _adminUser = adminUser;
            this._mySQL= _mySQL;
        }


        public async Task<List<IUsers>> GetAllUsers_ListAsync(Modes mode = null)
        {
            _mySQL.Quary("SELECT name,user_name,user_type FROM users");
            using MySqlDataReader results = await _mySQL.ProceduteExecuteMultyResultsAsync();
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
