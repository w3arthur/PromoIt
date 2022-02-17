using PromotItLibrary.Classes;
using PromotItLibrary.Interfaces;
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
        public string UserPassword { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string UserType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        public Task<Users> LoginAsync(Modes mode = null)
        {
            throw new NotImplementedException();
        }
    }
}
