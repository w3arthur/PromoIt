using MySql.Data.MySqlClient;
using PromotItLibrary.Classes;
using PromotItLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns.Actions
{
    public class ActionsUser
    {

        private static MySQL mySQL;
        private HTTPClient httpClient;

        private Users _user;
        private ActivistUser _activistUser;
        private AdminUser _adminUser;
        private NonProfitUser _nonProfitUser;
        private BusinessUser _businessUser;


        public ActionsUser(Users user, MySQL _mySQL, HTTPClient _httpClient)
        {
            _user = user;
            mySQL = _mySQL;
            httpClient = _httpClient;
        }
        public ActionsUser(ActivistUser activistUser, MySQL _mySQL, HTTPClient _httpClient)
        {
            _activistUser = activistUser;
            mySQL = _mySQL;
            httpClient = _httpClient;
        }
        public ActionsUser(AdminUser adminUser, MySQL _mySQL, HTTPClient _httpClient)
        {
            _adminUser = adminUser;
            mySQL = _mySQL;
            httpClient = _httpClient;
        }
        public ActionsUser(NonProfitUser nonProfitUser, MySQL _mySQL, HTTPClient _httpClient)
        {
            _nonProfitUser = nonProfitUser;
            mySQL = _mySQL;
            httpClient = _httpClient;
        }
        public ActionsUser(BusinessUser businessUser, MySQL _mySQL, HTTPClient _httpClient)
        {
            _businessUser = businessUser;
            mySQL = _mySQL;
            httpClient = _httpClient;
        }

        public async Task<Users> LoginAsync(Modes mode = null)
        {
            if (_user == null) return null;  //throw

            try
            {   //Queue and Functions
                if ((mode ?? Configuration.Mode) == Modes.Queue)
                    return await httpClient.PostSingleDataRequest(Configuration.SetUserQueue, _user, "Login");
                else if ((mode ?? Configuration.Mode) == Modes.Functions)
                    return await httpClient.PostSingleDataRequest(Configuration.SetUserFunctions, _user, "Login");
            }
            catch { return null; }; //throw instead

            if ((mode ?? Configuration.DatabaseMode) == Modes.MySQL)
            {
                mySQL.SetQuary("SELECT * FROM users where user_name=@username and user_password=@password limit 1");
                mySQL.QuaryParameter("@username", _user.UserName);
                mySQL.QuaryParameter("@password", _user.UserPassword);
                using MySqlDataReader results = await mySQL.GetQueryMultyResultsAsync();
                if (results == null) throw new Exception($"no User Name {_user.UserName}");
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
                    catch { throw new Exception($"error to set {_user.UserName}"); };
                }
            }

            return null;
        }

        public async Task<bool> RegisterAsync(Modes mode = null)
        {
            if (_activistUser != null)
            {
                try
                {
                    if ((mode ?? Configuration.Mode) == Modes.Queue)
                        return (bool)await httpClient.PostSingleDataInsert(Configuration.SetUserQueue, _activistUser, "");
                    else if ((mode ?? Configuration.Mode) == Modes.Functions)
                        return (bool)await httpClient.PostSingleDataInsert(Configuration.SetUserFunctions, _activistUser, "");
                }
                catch { return false; }

                if ((mode ?? Configuration.DatabaseMode) == Modes.MySQL)
                {
                    mySQL.Procedure("register_activist");
                    mySQL.ProcedureParameter("_username", _activistUser.UserName);
                    mySQL.ProcedureParameter("_password", _activistUser.UserPassword);
                    mySQL.ProcedureParameter("_name", _activistUser.Name);
                    mySQL.ProcedureParameter("_email", _activistUser.Email);
                    mySQL.ProcedureParameter("_address", _activistUser.Address);
                    mySQL.ProcedureParameter("_phone", _activistUser.PhoneNumber);
                    mySQL.ProcedureParameter("_cash", _activistUser.Cash ?? ActivistUser.CashDefultSet);
                    return await mySQL.ProceduteExecuteAsync();
                }

                return false;
            }
            else if (_adminUser != null)
            {
                try
                {   //Queue and Functions
                    if ((mode ?? Configuration.Mode) == Modes.Queue)
                        return (bool)await httpClient.PostSingleDataInsert(Configuration.SetUserQueue, _adminUser, "");
                    else if ((mode ?? Configuration.Mode) == Modes.Functions)
                        return (bool)await httpClient.PostSingleDataInsert(Configuration.SetUserFunctions, _adminUser, "");
                }
                catch { return false; }

                if ((mode ?? Configuration.DatabaseMode) == Modes.MySQL)
                {
                    mySQL.Procedure("register_admin");
                    mySQL.SetParameter("_name", _adminUser.Name);
                    mySQL.SetParameter("_username", _adminUser.UserName);
                    mySQL.SetParameter("_password", _adminUser.UserPassword);
                    return await mySQL.ProceduteExecuteAsync();
                }
                return false;
            }
            else if (_nonProfitUser != null)
            {
                try
                {   //Queue and Functions
                    if ((mode ?? Configuration.Mode) == Modes.Queue)
                        return (bool)await httpClient.PostSingleDataInsert(Configuration.SetUserQueue, _nonProfitUser, "");
                    else if ((mode ?? Configuration.Mode) == Modes.Functions)
                        return (bool)await httpClient.PostSingleDataInsert(Configuration.SetUserFunctions, _nonProfitUser, "");
                }
                catch
                {
                    return false;
                }

                if ((mode ?? Configuration.DatabaseMode) == Modes.MySQL)
                {
                    mySQL.Procedure("register_non_profit");
                    mySQL.SetParameter("_username", _nonProfitUser.UserName);
                    mySQL.SetParameter("_password", _nonProfitUser.UserPassword);
                    mySQL.SetParameter("_name", _nonProfitUser.Name);
                    mySQL.SetParameter("_email", _nonProfitUser.Email);
                    mySQL.SetParameter("_website", _nonProfitUser.WebSite);
                    return await mySQL.ProceduteExecuteAsync();
                }

                return false;
            }
            else if (_businessUser != null)
            {
                try
                {   //Queue and Functions
                    if ((mode ?? Configuration.Mode) == Modes.Queue)
                        return (bool)await httpClient.PostSingleDataInsert(Configuration.SetUserQueue, _businessUser, "");
                    else if ((mode ?? Configuration.Mode) == Modes.Functions)
                        return (bool)await httpClient.PostSingleDataInsert(Configuration.SetUserFunctions, _businessUser, "");
                }
                catch { return false; }

                if ((mode ?? Configuration.DatabaseMode) == Modes.MySQL)
                {
                    mySQL.Procedure("register_business");
                    mySQL.SetParameter("_username", _businessUser.UserName);
                    mySQL.SetParameter("_password", _businessUser.UserPassword);
                    mySQL.SetParameter("_name", _businessUser.Name);
                    return await mySQL.ProceduteExecuteAsync();
                }

                return false;
            }
            return false;
        }


        public async Task<ActivistUser> GetCashAmountAsync(Modes mode = null)
        {
            if (_activistUser == null) return null;

            try
            {
                if ((mode ?? Configuration.Mode) == Modes.Queue)
                    return await httpClient.GetSingleDataRequest(Configuration.PromoitProductQueue, _activistUser, "GetCashAmount");

                else if ((mode ?? Configuration.Mode) == Modes.Functions)
                    return await httpClient.GetSingleDataRequest(Configuration.PromoitProductFunctions, _activistUser, "GetCashAmount");
            }
            catch { return null; }

            if ((mode ?? Configuration.DatabaseMode) == Modes.MySQL)
            {
                mySQL.Quary("SELECT cash FROM promoit.users_activists Where user_name = @_username LIMIT 1");
                mySQL.ProcedureParameter("_username", _activistUser.UserName);
                using MySqlDataReader results = await mySQL.GetQueryMultyResultsAsync();
                if (results == null) throw new Exception($"no cash {_activistUser.UserName}");
                if (results != null && results.Read())
                {
                    try { return new ActivistUser() { Cash = results.GetString("cash"), }; }
                    catch { throw new Exception($"error to get cash for {_activistUser.UserName}"); };
                }
            }
            return null;
        }

    }
}
