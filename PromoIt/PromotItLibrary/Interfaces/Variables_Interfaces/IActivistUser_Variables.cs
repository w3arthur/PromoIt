using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns.Actions;
using PromotItLibrary.Patterns.Actions.Actions_Interfaces;

namespace PromotItLibrary.Interfaces.Variables_Interfaces
{
    public interface IActivistUser_Variables
    {
        static string CashDefultSet { get; }

        string Email { get; set; }
        string Address { get; set; }
        string PhoneNumber { get; set; }
        string Cash { get; set; }
    }
}
