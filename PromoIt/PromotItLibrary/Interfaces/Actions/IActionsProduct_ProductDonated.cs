
using PromotItLibrary.Enums;
using System.Threading.Tasks;

namespace PromotItLibrary.Interfaces.Actions
{
    public interface IActionsProduct_ProductDonated
    {
        Task<bool> SetBuyAnItemAsync(Modes mode = null);
        Task<bool> SetProductShippingAsync(Modes mode = null);
        //Task SetTwitterMessagTweet_SetBuyAnItemAsync();
    }
}
