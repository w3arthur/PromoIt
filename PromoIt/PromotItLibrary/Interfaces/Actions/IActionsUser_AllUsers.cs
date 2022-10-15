
using PromotItLibrary.Enums;
using PromotItLibrary.Interfaces.Users;
using System.Threading.Tasks;

namespace PromotItLibrary.Interfaces.Actions
{
    public interface IActionsUser_AllUsers
    {
        Task<IUsers> LoginAsync(Modes mode = null);
        Task<bool> RegisterAsync(Modes mode = null);
    }
}
