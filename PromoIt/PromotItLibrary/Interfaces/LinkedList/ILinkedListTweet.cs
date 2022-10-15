using PromotItLibrary.Classes;
using PromotItLibrary.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PromotItLibrary.Interfaces.LinkedList
{
    public interface ILinkedListTweet
    {
        Task<List<Tweet>> GetAllTweets_ListAsync(Modes mode = null);
    }
}
