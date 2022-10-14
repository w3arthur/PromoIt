using MySql.Data.MySqlClient;
using PromotItLibrary.Classes;
using PromotItLibrary.Enums;
using PromotItLibrary.Interfaces;
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

        private readonly MySQL _mySQL;
        private readonly HTTPClient _httpClient;
        private readonly IUsers _user;
        private IActionsUser actionsUser;

        public ActionsUser(IUsers user, MySQL mySQL, HTTPClient httpClient)
        {
            _user = user;
            _mySQL = mySQL;
            _httpClient = httpClient;
        }

        private IActionsUser ActionMode(Modes _mode, IUsers user)
        {
            if ((_mode ?? Configuration.Mode) == Modes.Queue)
                actionsUser = new ActionsUser_Queue(user, _httpClient);
            else if ((_mode ?? Configuration.Mode) == Modes.Functions)
                actionsUser = new ActionsUser_Function(user, _mySQL, _httpClient);
            else if ((_mode ?? Configuration.DatabaseMode) == Modes.MySQL)
                actionsUser = new ActionsUser_MySql(user, _mySQL, _httpClient);
            return actionsUser;
        }

        public async Task<IUsers> LoginAsync(Modes mode = null)
        {
            return await ActionMode(mode, _user).LoginAsync();
        }

        public async Task<bool> RegisterAsync(Modes mode = null)
        {
            if (_user is ActivistUser)
                return await ActionMode(mode, (ActivistUser)_user).RegisterAsync();
            else if (_user is AdminUser)
                return await ActionMode(mode, (AdminUser)_user).RegisterAsync();
            else if (_user is NonProfitUser)
                return await ActionMode(mode, (NonProfitUser)_user).RegisterAsync();
            else if (_user is BusinessUser)
                return await ActionMode(mode, (BusinessUser)_user).RegisterAsync();
            return false;
        }


        public async Task<IActivistUser> GetCashAmountAsync(Modes mode = null)
        {
            if (_user == null) return null;
            return await ActionMode(mode, (ActivistUser)_user).GetCashAmountAsync();
        }

    }
}
