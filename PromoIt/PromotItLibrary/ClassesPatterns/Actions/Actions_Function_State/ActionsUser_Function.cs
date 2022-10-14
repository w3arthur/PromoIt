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

namespace PromotItLibrary.Patterns.Actions.Actions_Fuction_State
{
    public class ActionsUser_Function : IActionsUser
    {

        private readonly MySQL _mySQL;
        private readonly HTTPClient httpClient;
        private readonly dynamic @_user;


        public ActionsUser_Function(IUsers user, MySQL mySQL, HTTPClient _httpClient)
        {
            _user = user;
            _mySQL = mySQL;
            httpClient = _httpClient;
        }

        public async Task<IUsers> LoginAsync(Modes mode = null)
        {
            return await httpClient.PostSingleDataRequest(Configuration.SetUserFunctions, _user, "Login");
        }

        public async Task<bool> RegisterAsync(Modes mode = null)
        {
            return (bool)await httpClient.PostSingleDataInsert(Configuration.SetUserFunctions, @_user, "");
        }


        public async Task<IActivistUser> GetCashAmountAsync(Modes mode = null)
        {
            if (!(_user is ActivistUser)) return null;
            return await httpClient.GetSingleDataRequest(Configuration.PromoitProductFunctions, (ActivistUser)_user, "GetCashAmount");
        }

    }
}
