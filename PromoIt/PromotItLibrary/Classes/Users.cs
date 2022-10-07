using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromotItLibrary.Models;
using PromotItLibrary.Interfaces;
using PromotItLibrary.Patterns.Actions;
using PromotItLibrary.Patterns.LinkedLists;
using Tweetinvi.Core.Models;
using PromotItLibrary.Patterns.LinkedLists.LinkedList_Function_State.LinkedLists_Interfaces;
using PromotItLibrary.Patterns.Actions.Actions_Interfaces;
using PromotItLibrary.Enums;

namespace PromotItLibrary.Classes
{
    public class Users : IUsers, IActionsUser_AllUsers
    {
        protected static MySQL mySQL = Configuration.MySQL;
        protected HTTPClient httpClient = Configuration.HTTPClient;

        protected ActionsUser actionsUser;
        protected LinkeListUser_Admin linkeListUser;
        protected DataTableUser_Admin dataTableUser;

        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string Name { get; set; }
        public string UserType { get; set; }
        public string Token { get; set; }
        public Users() 
        {
            actionsUser = new ActionsUser(this, mySQL, httpClient);
        }

        public Users(IUsers user) : this()
        {
            UserName = user.UserName;
            UserPassword = user.UserPassword;
            UserType = user.UserType;
            Name = user.Name;
            Token = user.Token;
        }

        //Actions
        public async Task<IUsers> LoginAsync(Modes mode = null) =>
            await actionsUser.LoginAsync(mode);
        public async Task<bool> RegisterAsync(Modes mode = null) =>
            await actionsUser.RegisterAsync(mode);

    }
}
