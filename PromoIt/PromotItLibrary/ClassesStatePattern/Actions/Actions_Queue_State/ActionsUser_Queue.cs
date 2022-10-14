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

namespace PromotItLibrary.Patterns.Actions.Actions_Queue_State
{
    public class ActionsUser_Queue : IActionsUser
    {

        private static MySQL mySQL;
        private HTTPClient httpClient;
        private IUsers _user;


        public ActionsUser_Queue(IUsers user, MySQL _mySQL, HTTPClient _httpClient)
        {
            _user = user;
            httpClient = _httpClient;
        }

        public async Task<IUsers> LoginAsync(Modes mode = null)
        {
            return await httpClient.PostSingleDataRequest(Configuration.SetUserQueue, _user, "Login");
        }

        public async Task<bool> RegisterAsync(Modes mode = null)
        {
            if (_user is ActivistUser)
                return (bool)await httpClient.PostSingleDataInsert(Configuration.SetUserQueue, (ActivistUser)_user, "");
            else if (_user is AdminUser)
                return (bool)await httpClient.PostSingleDataInsert(Configuration.SetUserQueue, (AdminUser)_user, "");
            else if (_user is NonProfitUser)
                return (bool)await httpClient.PostSingleDataInsert(Configuration.SetUserQueue, (NonProfitUser)_user, "");
            else if (_user is BusinessUser)
                return (bool)await httpClient.PostSingleDataInsert(Configuration.SetUserQueue, (BusinessUser)_user, "");
            return false;
        }

        public async Task<IActivistUser> GetCashAmountAsync(Modes mode = null)
        {
            if (!(_user is ActivistUser)) return null;
            return await httpClient.GetSingleDataRequest(Configuration.PromoitProductQueue, (ActivistUser)_user, "GetCashAmount");
        }

    }
}
