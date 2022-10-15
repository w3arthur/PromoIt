
using PromotItLibrary.Enums;
using System.Threading.Tasks;

namespace PromotItLibrary.Interfaces.Actions
{
    public interface IActionsProduct_ProductInCampaign
    {
        Task<bool> SetNewProductAsync(Modes mode = null);
    }
}
