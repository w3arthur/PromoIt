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
    public interface IActionsUser : IActionsUser_ActivistUser, IActionsUser_AllUsers
    {

    }
}
