
using System.Data;
using System.Threading.Tasks;

namespace PromotItLibrary.Interfaces.DataTables
{
    public interface IDataTableTweet
    {
        Task<DataTable> GetAllTweets_DataTableAsync();
    }
}
