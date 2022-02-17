using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PromotItLibrary.Models;

namespace PromotItLibrary.Classes
{
    public class ActivistUser : Users
    {
        private MySQL mySQL = Configuration.MySQL;
        private HTTPClient httpClient = Configuration.HTTPClient;

        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Cash { get; set; }


        public ActivistUser() : base() { UserType = "activist"; }
        public ActivistUser(Users user) : base(user) { }


        public async Task<ActivistUser> GetCashAmountAsync(Modes mode = null)
        {

            try
            {
                if ((mode ?? Configuration.Mode) == Modes.Queue)
                    return await httpClient.GetSingleDataRequest(Configuration.PromoitProductQueue, this, "GetCashAmount");

                else if ((mode ?? Configuration.Mode) == Modes.Functions)
                    return await httpClient.GetSingleDataRequest(Configuration.PromoitProductFunctions, this, "GetCashAmount");
            }
            catch { return null; }

            if ((mode ?? Configuration.DatabaseMode) == Modes.MySQL)
            {
                mySQL.Quary("SELECT cash FROM promoit.users_activists Where user_name = @_username LIMIT 1");
                mySQL.ProcedureParameter("_username", UserName);
                using MySqlDataReader results = await mySQL.GetQueryMultyResultsAsync();
                if (results == null) throw new Exception($"no cash {UserName}");
                if (results != null && results.Read())
                {
                    try { return new ActivistUser() { Cash = results.GetString("cash"), }; }
                    catch { throw new Exception($"error to get cash for {UserName}"); };
                }

            }
            return null;

        }

        public async Task<bool> RegisterAsync(Modes mode = null)
        {
            try
            {
                if ((mode ?? Configuration.Mode) == Modes.Queue)
                    return (bool)await httpClient.PostSingleDataInsert(Configuration.SetUserQueue, this, "");
                else if ((mode ?? Configuration.Mode) == Modes.Functions)
                    return (bool)await httpClient.PostSingleDataInsert(Configuration.SetUserFunctions, this, "");
            }
            catch { return false; }

            if ((mode ?? Configuration.DatabaseMode) == Modes.MySQL)
            {
                mySQL.Procedure("register_activist");
                mySQL.ProcedureParameter("_username", UserName);
                mySQL.ProcedureParameter("_password", UserPassword);
                mySQL.ProcedureParameter("_name", Name);
                mySQL.ProcedureParameter("_email", Email);
                mySQL.ProcedureParameter("_address", Address);
                mySQL.ProcedureParameter("_phone", PhoneNumber);
                mySQL.ProcedureParameter("_cash", Cash ?? "10000.0");
                return await mySQL.ProceduteExecuteAsync();
            }

            return false;

        }

    }
}
