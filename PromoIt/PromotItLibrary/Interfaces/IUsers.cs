using MySql.Data.MySqlClient;
using PromotItLibrary.Classes;
using PromotItLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Interfaces
{
    public interface IUsers
    {
        string UserName { get; set; }
        string UserPassword { get; set; }
        string UserType { get; set; }
        string Name { get; set; }
    }
}
