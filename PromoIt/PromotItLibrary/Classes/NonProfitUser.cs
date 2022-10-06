using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PromotItLibrary.Interfaces;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns.Actions;

namespace PromotItLibrary.Classes
{
    public class NonProfitUser : Users, INonProfitUser
    { 
        public string Email { get; set; }
        public string WebSite { get; set; }

        public NonProfitUser() : base()
        {
            UserType = "non-profit";
            actionsUser = new ActionsUser(this, mySQL, httpClient);
        }
        //public NonProfitUser(Users user) : base(user) { UserType = "non-profit"; actionsUser = new ActionsUser(this, mySQL, httpClient); }

    }
}
