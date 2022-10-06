using MySql.Data.MySqlClient;
using PromotItLibrary.Classes;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns.Actions.Actions_Fuction_State;
using PromotItLibrary.Patterns.Actions.Actions_Interfaces;
using PromotItLibrary.Patterns.Actions.Actions_MySql_State;
using PromotItLibrary.Patterns.Actions.Actions_Queue_State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns.Actions
{
    public class ActionsUser : IActionsUser
    {

        private static MySQL mySQL;
        private HTTPClient httpClient;
        private Users _user;
        private ActivistUser _activistUser;
        private AdminUser _adminUser;
        private NonProfitUser _nonProfitUser;
        private BusinessUser _businessUser;
        IActionsUser actionsUser;

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

        private IActionsUser ActionMode(Modes _mode, dynamic @user)
        {
            if ((_mode ?? Configuration.Mode) == Modes.Queue)
                actionsUser = new ActionsUser_Queue(@user, mySQL, httpClient);
            else if ((_mode ?? Configuration.Mode) == Modes.Functions)
                actionsUser = new ActionsUser_Function(@user, mySQL, httpClient);
            if ((_mode ?? Configuration.DatabaseMode) == Modes.MySQL)
                actionsUser = new ActionsUser_MySql(@user, mySQL, httpClient);
            return actionsUser;
        }

        public async Task<Users> LoginAsync(Modes mode = null)
        {
            return await ActionMode(mode, _user).LoginAsync();
        }

        public async Task<bool> RegisterAsync(Modes mode = null)
        {
            if (_activistUser != null)
            {
                return await ActionMode(mode, _activistUser).RegisterAsync();
            }
            else if (_adminUser != null)
            {
                return await ActionMode(mode, _adminUser).RegisterAsync();
            }
            else if (_nonProfitUser != null)
            {
                return await ActionMode(mode, _nonProfitUser).RegisterAsync();
            }
            else if (_businessUser != null)
            {
                return await ActionMode(mode, _businessUser).RegisterAsync();
            }
            return false;
        }


        public async Task<ActivistUser> GetCashAmountAsync(Modes mode = null)
        {
            if (_activistUser == null) return null;
            return await ActionMode(mode, _activistUser).GetCashAmountAsync();
        }

    }
}
