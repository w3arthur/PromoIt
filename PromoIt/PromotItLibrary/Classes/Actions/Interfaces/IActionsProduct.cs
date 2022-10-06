using PromotItLibrary.Classes;
using PromotItLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns.Actions.Interfaces
{
    interface IActionsProduct
    {
        Task<bool> SetBuyAnItemAsync();
        Task<bool> SetProductShippingAsync();
        Task<bool> SetNewProductAsync();
    }
}
