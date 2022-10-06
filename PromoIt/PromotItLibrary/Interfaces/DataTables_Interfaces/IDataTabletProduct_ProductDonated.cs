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
    interface IDataTabletProduct_ProductDonated
    {
        Task<DataTable> GetDonatedProductForShipping_DataTableAsync();
    }
}
