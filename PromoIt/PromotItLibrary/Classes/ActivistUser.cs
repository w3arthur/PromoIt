using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PromotItLibrary.Enums;
using PromotItLibrary.Interfaces;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns.Actions;
using PromotItLibrary.Patterns.Actions.Actions_Fuction_State;
using PromotItLibrary.Patterns.Actions.Actions_Interfaces;
using PromotItLibrary.Patterns.Actions.Actions_MySql_State;
using PromotItLibrary.Patterns.Actions.Actions_Queue_State;
using PromotItLibrary.Patterns.LinkedLists.LinkedList_Function_State.LinkedLists_Interfaces;

namespace PromotItLibrary.Classes
{
    public class ActivistUser : Users, IActivistUser, IActionsUser_ActivistUser
    {
        public static string CashDefultSet { get; } = Configuration.ActivistCashDefultSet;

        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Cash { get; set; }

        public ActivistUser() : base()
        { 
            UserType = "activist";

            //Action States ? duplicated
            if ((_mode ?? Configuration.Mode) == Modes.Queue)
                actionsUser = new ActionsUser_Queue(this, _httpClient);
            else if ((_mode ?? Configuration.Mode) == Modes.Functions)
                actionsUser = new ActionsUser_Function(this, _mySQL, _httpClient);
            else if ((_mode ?? Configuration.DatabaseMode) == Modes.MySQL)
                actionsUser = new ActionsUser_MySql(this, _mySQL, _httpClient);
        }
        public ActivistUser(IUsers user) : base(user) 
        { 
            UserType = "activist";

            //Action States ? duplicated
            if ((_mode ?? Configuration.Mode) == Modes.Queue)
                actionsUser = new ActionsUser_Queue(this, _httpClient);
            else if ((_mode ?? Configuration.Mode) == Modes.Functions)
                actionsUser = new ActionsUser_Function(this, _mySQL, _httpClient);
            else if ((_mode ?? Configuration.DatabaseMode) == Modes.MySQL)
                actionsUser = new ActionsUser_MySql(this, _mySQL, _httpClient);
        }

        //Actions
        public async Task<IActivistUser> GetCashAmountAsync(Modes mode = null) =>
            await actionsUser.GetCashAmountAsync(mode);
    }
}
