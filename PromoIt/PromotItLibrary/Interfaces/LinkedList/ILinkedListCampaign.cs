
using PromotItLibrary.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PromotItLibrary.Interfaces.LinkedList
{
    public interface ILinkedListCampaign
    {
        Task<List<ICampaign>> GetAllCampaignsNonProfit_ListAsync(Modes mode = null);
        Task<List<ICampaign>> GetAllCampaigns_ListAsync(Modes mode = null);
    }
}
