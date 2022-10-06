using MySql.Data.MySqlClient;
using PromotItLibrary.Classes;
using PromotItLibrary.Enums;
using PromotItLibrary.Interfaces;
using PromotItLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns.LinkedLists.LinkedList_Function_State.LinkedLists_Interfaces
{
    public interface ILinkedListCampaign
    {
        Task<List<ICampaign>> MySql_GetAllCampaignsNonProfit_ListAsync(Modes mode = null);
        Task<List<ICampaign>> MySQL_GetAllCampaigns_ListAsync(Modes mode = null);
    }
}
