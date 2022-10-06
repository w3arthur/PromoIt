using MySql.Data.MySqlClient;
using PromotItLibrary.Classes;
using PromotItLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns.Actions.Actions_Interfaces
{
    interface IActionsUser_AllUsers
    {
        Task<Users> LoginAsync(Modes mode = null);
        Task<bool> RegisterAsync(Modes mode = null);
    }
}
