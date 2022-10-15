
using System.Data;
using System.Threading.Tasks;

namespace PromotItLibrary.Interfaces.DataTables
{
    public interface IDataTableUser_Admin
    {
        Task<DataTable> GetAllUsers_DataTableAsync();
        Task<DataTable> GetAllCampaignsAdmin_DataTableAsync();
    }
}
