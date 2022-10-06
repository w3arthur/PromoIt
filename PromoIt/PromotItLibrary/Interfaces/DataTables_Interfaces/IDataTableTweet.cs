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

namespace PromotItLibrary.Patterns.DataTables.DataTables_Interfaces
{
    interface IDataTableTweet
    {
        Task<DataTable> GetAllTweets_DataTableAsync();
    }
}
