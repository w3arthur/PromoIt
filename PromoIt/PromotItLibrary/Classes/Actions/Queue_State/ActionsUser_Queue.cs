using MySql.Data.MySqlClient;
using PromotItLibrary.Classes.Users;
using PromotItLibrary.Enums;
using PromotItLibrary.Interfaces.Actions;
using PromotItLibrary.Interfaces.Users;
using PromotItLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns.Actions.Actions_Queue_State
{
    public class ActionsUser_Queue : IActionsUser
    {

        private readonly HTTPClient _httpClient;
        private readonly dynamic @_user;

        public ActionsUser_Queue(IUsers user, HTTPClient httpClient)
        {
            _user = user;
            _httpClient = httpClient;
        }

        public async Task<IUsers> LoginAsync(Modes mode = null)
        {
            return await _httpClient.PostSingleDataRequest(Configuration.SetUserQueue, _user, "Login");
        }

        public async Task<bool> RegisterAsync(Modes mode = null)
        {
            return (bool)await _httpClient.PostSingleDataInsert(Configuration.SetUserQueue, @_user, "");
        }

        public async Task<IActivistUser> GetCashAmountAsync(Modes mode = null)
        {
            if (!(_user is ActivistUser)) return null;
            return await _httpClient.GetSingleDataRequest(Configuration.PromoitProductQueue, (ActivistUser)_user, "GetCashAmount");
        }

    }
}
