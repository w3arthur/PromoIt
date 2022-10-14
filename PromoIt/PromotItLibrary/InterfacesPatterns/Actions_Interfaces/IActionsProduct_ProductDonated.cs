using PromotItLibrary.Enums;
using PromotItLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns.Actions.Actions_Interfaces
{
    public interface IActionsProduct_ProductDonated
    {
        Task<bool> SetBuyAnItemAsync(Modes mode = null);
        Task<bool> SetProductShippingAsync(Modes mode = null);
        //Task SetTwitterMessagTweet_SetBuyAnItemAsync();
    }
}
