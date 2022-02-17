using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromotItLibrary.Models;

namespace PromotItLibrary.Classes
{
    public class BusinessUser : Users
    {
        private MySQL mySQL = Configuration.MySQL;
        private HTTPClient httpClient = Configuration.HTTPClient;



        public BusinessUser() : base() { UserType = "business"; }
        public BusinessUser(Users user) : base(user) { }



        public async Task<bool> RegisterAsync(Modes mode = null)
        {
            try
            {   //Queue and Functions
                if ((mode ?? Configuration.Mode) == Modes.Queue)
                    return (bool)await httpClient.PostSingleDataInsert(Configuration.SetUserQueue, this, "");
                else if ((mode ?? Configuration.Mode) == Modes.Functions)
                    return (bool)await httpClient.PostSingleDataInsert(Configuration.SetUserFunctions, this, "");
            }
            catch { return false; }

            if ((mode ?? Configuration.DatabaseMode) == Modes.MySQL)
            {
                mySQL.Procedure("register_business");
                mySQL.SetParameter("_username", UserName);
                mySQL.SetParameter("_password", UserPassword);
                mySQL.SetParameter("_name", Name);
                return await mySQL.ProceduteExecuteAsync();
            }

            return false;
        }

    }
}
