using MySql.Data.MySqlClient;
using PromotItLibrary.Classes;
using PromotItLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PromotItLibrary.Patterns.LinkedLists;
using PromotItLibrary.Patterns.DataTables;

namespace PromotItLibrary.Patterns
{
    public class ActionsUser
    {
        private static MySQL mySQL = Configuration.MySQL;
        private HTTPClient httpClient = Configuration.HTTPClient;

        private Users _user;
        private ActivistUser _activistUser;
        private AdminUser _adminUser;
        private NonProfitUser _nonProfitUser;
        private BusinessUser _businessUser;

        private LinkeListUser linkeListUser;
        private DataTableUser dataTableUser;

        private List<Users> _userList;
        private DataTable _userTable;
        private string _logMessahe;
        private bool _result;

        public ActionsUser(Users user) => _user = user;
        public ActionsUser(ActivistUser activistUser) => _activistUser = activistUser;
        public ActionsUser(AdminUser adminUser) 
        { 
            _adminUser = adminUser;
            linkeListUser = new LinkeListUser(adminUser, mySQL, httpClient);
            dataTableUser = new DataTableUser(adminUser);
        }
        public ActionsUser(NonProfitUser nonProfitUser) => _nonProfitUser = nonProfitUser;
        public ActionsUser(BusinessUser businessUser) => _businessUser = businessUser;


        /*
        public T Builder<T>(T _log){
            if (_logMessahe) return T;
            return T;
        }*/


        public async Task<Users> LoginAsync(Modes mode = null) 
        {
            if(_user == null) return null;  //throw

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

        public async Task<List<Users>> MySQL_GetAllUsers_ListAsync(Modes mode = null) =>
            await linkeListUser.MySQL_GetAllUsers_ListAsync(mode);

        public async Task<DataTable> GetAllUsers_DataTableAsync() =>
            await dataTableUser.GetAllUsers_DataTableAsync();

        public async Task<DataTable> GetAllCampaignsAdmin_DataTableAsync() =>
       await dataTableUser.GetAllCampaignsAdmin_DataTableAsync();

    }
}
