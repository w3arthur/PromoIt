
using System.Data;
using System.Threading.Tasks;

namespace PromotItLibrary.Interfaces.DataTables
{
    public interface IDataTabletProduct_ProductDonated
    {
        Task<DataTable> GetDonatedProductForShipping_DataTableAsync();
    }
}
