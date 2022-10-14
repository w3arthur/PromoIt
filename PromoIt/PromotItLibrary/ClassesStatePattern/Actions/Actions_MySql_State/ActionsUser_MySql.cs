using MySql.Data.MySqlClient;
using PromotItLibrary.Classes;
using PromotItLibrary.Enums;
using PromotItLibrary.Interfaces;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns.Actions.Actions_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns.Actions.Actions_MySql_State
{
    public class ActionsUser_MySql : IActionsUser
    {

        private static MySQL mySQL;
        private HTTPClient httpClient;
        private IUsers _user;

        public ActionsUser_MySql(IUsers user, MySQL _mySQL, HTTPClient _httpClient)
        {
             _user = user;
            mySQL = _mySQL;
        }

        public async Task<IUsers> LoginAsync(Modes mode = null)
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
            return null;
        }

        public async Task<bool> RegisterAsync(Modes mode = null)
        {
            if (_user is ActivistUser)
            {
                ActivistUser _activistUser = (ActivistUser)_user;
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
            else if (_user is AdminUser)
            {
                AdminUser _adminUser = (AdminUser)_user;
                mySQL.Procedure("register_admin");
                mySQL.SetParameter("_name", _adminUser.Name);
                mySQL.SetParameter("_username", _adminUser.UserName);
                mySQL.SetParameter("_password", _adminUser.UserPassword);
                return await mySQL.ProceduteExecuteAsync();
            }
            else if (_user is NonProfitUser)
            {
                NonProfitUser _nonProfitUser = (NonProfitUser)_user;
                mySQL.Procedure("register_non_profit");
                mySQL.SetParameter("_username", _nonProfitUser.UserName);
                mySQL.SetParameter("_password", _nonProfitUser.UserPassword);
                mySQL.SetParameter("_name", _nonProfitUser.Name);
                mySQL.SetParameter("_email", _nonProfitUser.Email);
                mySQL.SetParameter("_website", _nonProfitUser.WebSite);
                return await mySQL.ProceduteExecuteAsync();
            }
            else if (_user is BusinessUser)
            {
                BusinessUser _businessUser = (BusinessUser)_user;
                mySQL.Procedure("register_business");
                mySQL.SetParameter("_username", _businessUser.UserName);
                mySQL.SetParameter("_password", _businessUser.UserPassword);
                mySQL.SetParameter("_name", _businessUser.Name);
                return await mySQL.ProceduteExecuteAsync();
            }
            return false;
        }


        public async Task<IActivistUser> GetCashAmountAsync(Modes mode = null)
        {
            if (!(_user is ActivistUser)) return null;
            ActivistUser _activistUser = (ActivistUser)_user;
            mySQL.Quary("SELECT cash FROM promoit.users_activists Where user_name = @_username LIMIT 1");
            mySQL.ProcedureParameter("_username", _activistUser.UserName);
            using MySqlDataReader results = await mySQL.GetQueryMultyResultsAsync();
            if (results == null) throw new Exception($"no cash {_activistUser.UserName}");
            if (results != null && results.Read())
            {
                try { return new ActivistUser() { Cash = results.GetString("cash"), }; }
                catch { throw new Exception($"error to get cash for {_activistUser.UserName}"); };
            }
            return null;
        }

    }
}
