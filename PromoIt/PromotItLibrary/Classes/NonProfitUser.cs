using System;
using PromotItLibrary.Interfaces;

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
        //public NonProfitUser(Users user) : this() { CopyUser(this); }

    }
}
