using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns.Actions;

namespace PromotItLibrary.Interfaces.Variables_Interfaces
{
    public interface INonProfitUser_Variables
    {
        string Email { get; set; }
        string WebSite { get; set; }
    }
}
