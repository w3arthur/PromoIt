
using System.Data;
using System.Threading.Tasks;

namespace PromotItLibrary.Interfaces.DataTables
{
    interface IDataTableCampaign
    {
        public Task<DataTable> GetAllCampaignsNonProfit_DataTableAsync();
        public Task<DataTable> GetAllCampaigns_DataTableAsync();
    }
}
