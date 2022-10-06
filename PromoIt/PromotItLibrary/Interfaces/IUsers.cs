using MySql.Data.MySqlClient;
using PromotItLibrary.Classes;
using PromotItLibrary.Interfaces.Variables_Interfaces;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns.Actions.Actions_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Interfaces
{
    public interface IUsers : IUsers_Variables, IActionsUser_AllUsers
    {

    }
}
