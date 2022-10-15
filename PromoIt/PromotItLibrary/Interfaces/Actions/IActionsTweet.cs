
using PromotItLibrary.Enums;
using System.Threading.Tasks;

namespace PromotItLibrary.Interfaces.Actions
{
    public interface IActionsTweet
    {
        Task<bool> SetTweetCashAsync(Modes mode = null);
    }
}
