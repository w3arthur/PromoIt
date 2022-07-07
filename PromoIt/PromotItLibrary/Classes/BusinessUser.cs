using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromotItLibrary.Models;

namespace PromotItLibrary.Classes
{
    public class BusinessUser : Users
    {

        public BusinessUser() : base() { UserType = "business"; }
        public BusinessUser(Users user) : base(user) { UserType = "business"; }


    }
}
