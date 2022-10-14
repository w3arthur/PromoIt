using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromotItLibrary.Enums;
using PromotItLibrary.Interfaces;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns.Actions;
using PromotItLibrary.Patterns.Actions.Actions_Fuction_State;
using PromotItLibrary.Patterns.Actions.Actions_MySql_State;
using PromotItLibrary.Patterns.Actions.Actions_Queue_State;

namespace PromotItLibrary.Classes
{
    public class BusinessUser : Users, IBusinessUser
    {
        public BusinessUser() : base() 
        {
            UserType = "business";
            RunActions(this);
        }
       // public BusinessUser(Users user) : base(user) { UserType = "business"; actionsUser = new ActionsUser(this, mySQL, httpClient); }
    }
}
