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
    interface IDataTableCampaign
    {
        Task<DataTable> GetAllCampaignsNonProfit_DataTableAsync();
        Task<DataTable> GetAllCampaigns_DataTableAsync();
    }
}
