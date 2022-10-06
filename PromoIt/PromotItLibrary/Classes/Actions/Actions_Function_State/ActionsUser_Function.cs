using MySql.Data.MySqlClient;
using PromotItLibrary.Classes;
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

        private static MySQL mySQL;
        private HTTPClient httpClient;

        private Users _user;
        private ActivistUser _activistUser;
        private AdminUser _adminUser;
        private NonProfitUser _nonProfitUser;
        private BusinessUser _businessUser;


        public ActionsUser_Function(Users user, MySQL _mySQL, HTTPClient _httpClient)
        {
            _user = user;
            mySQL = _mySQL;
            httpClient = _httpClient;
        }
        public ActionsUser_Function(ActivistUser activistUser, MySQL _mySQL, HTTPClient _httpClient)
        {
            _activistUser = activistUser;
            mySQL = _mySQL;
            httpClient = _httpClient;
        }
        public ActionsUser_Function(AdminUser adminUser, MySQL _mySQL, HTTPClient _httpClient)
        {
            _adminUser = adminUser;
            mySQL = _mySQL;
            httpClient = _httpClient;
        }
        public ActionsUser_Function(NonProfitUser nonProfitUser, MySQL _mySQL, HTTPClient _httpClient)
        {
            _nonProfitUser = nonProfitUser;
            mySQL = _mySQL;
            httpClient = _httpClient;
        }
        public ActionsUser_Function(BusinessUser businessUser, MySQL _mySQL, HTTPClient _httpClient)
        {
            _businessUser = businessUser;
            mySQL = _mySQL;
            httpClient = _httpClient;
        }

        public async Task<Users> LoginAsync()
        {
            return await httpClient.PostSingleDataRequest(Configuration.SetUserFunctions, _user, "Login");
        }

        public async Task<bool> RegisterAsync()
        {
            if (_activistUser != null)
            {
                return (bool)await httpClient.PostSingleDataInsert(Configuration.SetUserFunctions, _activistUser, "");
            }
            else if (_adminUser != null)
            {
                return (bool)await httpClient.PostSingleDataInsert(Configuration.SetUserFunctions, _adminUser, "");
            }
            else if (_nonProfitUser != null)
            {
                return (bool)await httpClient.PostSingleDataInsert(Configuration.SetUserFunctions, _nonProfitUser, "");
            }
            else if (_businessUser != null)
            {
                return (bool)await httpClient.PostSingleDataInsert(Configuration.SetUserFunctions, _businessUser, "");
            }
            return false;
        }


        public async Task<ActivistUser> GetCashAmountAsync()
        {
            return await httpClient.GetSingleDataRequest(Configuration.PromoitProductFunctions, _activistUser, "GetCashAmount");
        }

    }
}
