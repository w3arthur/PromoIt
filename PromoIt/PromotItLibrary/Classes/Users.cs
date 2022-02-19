using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromotItLibrary.Models;
using PromotItLibrary.Interfaces;

namespace PromotItLibrary.Classes
{
    public class Users : IUsers
    {


        private static MySQL mySQL = Configuration.MySQL;
        private HTTPClient httpClient = Configuration.HTTPClient;

        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string Name { get; set; }
        public string UserType { get; set; }
        public string Token { get; set; }

        public Users() { }

        public Users(Users user) : this()
        {
            UserName = user.UserName;
            UserPassword = user.UserPassword;
            UserType = user.UserType;
            Name = user.Name;
            Token = user.Token;
        }

        public async Task<Users> LoginAsync(Modes mode = null)
        {
            try
            {   //Queue and Functions
                if ((mode ?? Configuration.Mode) == Modes.Queue)
                    return await httpClient.PostSingleDataRequest(Configuration.SetUserQueue, this, "Login") ;
                else if ((mode ?? Configuration.Mode) == Modes.Functions)
                    return await httpClient.PostSingleDataRequest(Configuration.SetUserFunctions, this, "Login");
            }
            catch { return null; }; //throw instead

            if ((mode ?? Configuration.DatabaseMode) == Modes.MySQL)
            {
                mySQL.SetQuary("SELECT * FROM users where user_name=@username and user_password=@password limit 1");
                mySQL.QuaryParameter("@username", UserName);
                mySQL.QuaryParameter("@password", UserPassword);
                using MySqlDataReader results = await mySQL.ProceduteExecuteMultyResultsAsync();
                if (results == null) throw new Exception($"no User Name {UserName}");
                if (results != null && results.Read())
                {
                    try
                    {
                        return new Users() 
                            {
                                UserName = results.GetString("user_name"),
                                UserPassword = results.GetString("user_password"),
                                UserType = results.GetString("user_type"),
                                Name = results.GetString("name"),
                            };
                    }
                    catch { throw new Exception($"error to set {UserName}"); };
                }
            }

            return null;
        }


    }
}
