using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PromotItLibrary.Enums;
using PromotItLibrary.Interfaces;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns.Actions;
using PromotItLibrary.Patterns.Actions.Actions_Fuction_State;
using PromotItLibrary.Patterns.Actions.Actions_MySql_State;
using PromotItLibrary.Patterns.Actions.Actions_Queue_State;

namespace PromotItLibrary.Classes
{
    public class NonProfitUser : Users, INonProfitUser
    { 
        public string Email { get; set; }
        public string WebSite { get; set; }

        public NonProfitUser() : base()
        {
            UserType = "non-profit";
            RunActions(this);
        }
        //public NonProfitUser(Users user) : base(user) { UserType = "non-profit"; actionsUser = new ActionsUser(this, mySQL, httpClient); }

    }
}
