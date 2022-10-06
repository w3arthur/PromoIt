using Microsoft.Extensions.Logging;
using PromotItLibrary.Classes;
using PromotItLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns.LinkedLists.DataTables_Interfaces
{
    interface IDataTableUser
    {
        Task<DataTable> GetAllUsers_DataTableAsync();
        Task<DataTable> GetAllCampaignsAdmin_DataTableAsync();
    }
}
