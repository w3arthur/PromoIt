using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PromotItLibrary.Models;

namespace PromotItLibrary.Classes
{
    public class NonProfitUser : Users
    {
        public string Email { get; set; }
        public string WebSite { get; set; }

        public NonProfitUser() : base() { UserType = "non-profit"; }
        public NonProfitUser(Users user) : base(user) { UserType = "non-profit"; }

    }
}
