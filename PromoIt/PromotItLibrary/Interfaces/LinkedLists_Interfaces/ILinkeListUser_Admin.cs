using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using PromotItLibrary.Classes;
using PromotItLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns.LinkedLists.LinkedList_Function_State.LinkedLists_Interfaces
{
    interface ILinkeListUser_Admin
    {
         Task<List<Users>> MySQL_GetAllUsers_ListAsync(Modes mode = null);
    }
}
