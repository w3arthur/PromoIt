using PromotItLibrary.Classes;
using PromotItLibrary.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PromotItLibrary.Interfaces.LinkedList
{
    public interface ILinkedListProduct_ProductInCampaign
    {
        Task<List<ProductInCampaign>> GetProductList_ListAsync(Modes mode = null);
    }
}
