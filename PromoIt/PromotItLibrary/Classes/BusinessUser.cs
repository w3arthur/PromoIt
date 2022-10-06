using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns.Actions;

namespace PromotItLibrary.Classes
{
    public class BusinessUser : Users
    {

        public BusinessUser() : base() { UserType = "business"; actionsUser = new ActionsUser(this, mySQL, httpClient); }
        public BusinessUser(Users user) : base(user) { UserType = "business"; actionsUser = new ActionsUser(this, mySQL, httpClient); }


    }
}
