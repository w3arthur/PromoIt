
using System.Data;
using System.Threading.Tasks;

namespace PromotItLibrary.Interfaces.DataTables
{
    public interface IDataTabletProduct_ProductInCampaign
    {
        Task<DataTable> GetList_DataTableAsync();
    }
}
