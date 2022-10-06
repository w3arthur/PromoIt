using MySql.Data.MySqlClient;
using PromotItLibrary.Classes;
using PromotItLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Interfaces.Variables_Interfaces
{
    public interface IUsers_Variables
    {
        string UserName { get; set; }
        string UserPassword { get; set; }
        string UserType { get; set; }
        string Name { get; set; }
        string Token { get; set; }
    }
}
