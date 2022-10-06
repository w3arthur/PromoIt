using PromotItLibrary.Enums;
using PromotItLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns.Actions.Actions_Interfaces
{
    public interface IActionsCampaign
    {
        Task<bool> SetNewCampaignAsync(Modes mode = null);
        Task<bool> DeleteCampaignAsync(Modes mode = null);
    }
}
