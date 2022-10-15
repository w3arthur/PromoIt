using PromotItLibrary.Classes;
using PromotItLibrary.Enums;
using PromotItLibrary.Interfaces.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoitTesting.TestClasses
{
    public class DataTest : IUsers
    {
        public DataTest() { }

        public string UserName  { get; set; }= "John";
        public string UserPassword { get; set; }
        public string UserType { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }

        public Task<IUsers> LoginAsync(Modes mode = null)
        {
            return null;    //throw new NotImplementedException();
        }

        public Task<bool> RegisterAsync(Modes mode = null)
        {
            throw new NotImplementedException();
        }
    }
}
