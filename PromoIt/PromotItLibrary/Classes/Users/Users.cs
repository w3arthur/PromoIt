
using System;
using System.Threading.Tasks;
using PromotItLibrary.Models;
using PromotItLibrary.Enums;
using PromotItLibrary.Patterns.Actions.Actions_Fuction_State;
using PromotItLibrary.Patterns.Actions.Actions_MySql_State;
using PromotItLibrary.Patterns.Actions.Actions_Queue_State;
using PromotItLibrary.Interfaces.Actions;
using PromotItLibrary.Interfaces.Users;

namespace PromotItLibrary.Classes.Users
{
    public class Users : IUsers, IActionsUser_AllUsers
    {
        protected readonly MySQL _mySQL = Configuration.MySQL;
        protected readonly HTTPClient _httpClient = Configuration.HTTPClient;
        protected readonly Modes _mode;
        protected IActionsUser actionsUser;

        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string Name { get; set; }
        public string UserType { get; set; }
        public string Token { get; set; }
        public Users()
        {
            //Action States
            RunActions(this);
        }

        public Users(IUsers user) : this()
        {
            CopyUser(user);
        }


        protected void RunActions<T>(T t_user) where T : IUsers //(AdminUser, BusinessUser, NonProfitUser, ActivistUser)
        {
            if ((_mode ?? Configuration.Mode) == Modes.Queue)
                actionsUser = new ActionsUser_Queue(t_user, _httpClient);
            else if ((_mode ?? Configuration.Mode) == Modes.Functions)
                actionsUser = new ActionsUser_Function(t_user, _mySQL, _httpClient);
            else if ((_mode ?? Configuration.DatabaseMode) == Modes.MySQL)
                actionsUser = new ActionsUser_MySql(t_user, _mySQL, _httpClient);
        }


        protected void CopyUser(IUsers user)
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
