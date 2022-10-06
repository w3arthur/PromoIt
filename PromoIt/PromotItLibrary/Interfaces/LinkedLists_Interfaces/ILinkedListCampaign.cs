using MySql.Data.MySqlClient;
using PromotItLibrary.Classes;
using PromotItLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns.LinkedLists.LinkedList_Function_State.LinkedLists_Interfaces
{
    interface ILinkedListCampaign
    {
        Task<List<Campaign>> MySql_GetAllCampaignsNonProfit_ListAsync(Modes mode = null);
        Task<List<Campaign>> MySQL_GetAllCampaigns_ListAsync(Modes mode = null);
    }
}
