
using PromotItLibrary.Enums;
using System.Threading.Tasks;

namespace PromotItLibrary.Interfaces.Actions
{
    public interface IActionsCampaign
    {
        Task<bool> SetNewCampaignAsync(Modes mode = null);
        Task<bool> DeleteCampaignAsync(Modes mode = null);
    }
}
