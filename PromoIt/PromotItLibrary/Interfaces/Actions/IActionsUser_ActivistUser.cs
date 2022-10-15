
using PromotItLibrary.Enums;
using PromotItLibrary.Interfaces.Users;
using System.Threading.Tasks;

namespace PromotItLibrary.Interfaces.Actions
{
    public interface IActionsUser_ActivistUser
    {
        Task<IActivistUser> GetCashAmountAsync(Modes mode = null);
    }
}
