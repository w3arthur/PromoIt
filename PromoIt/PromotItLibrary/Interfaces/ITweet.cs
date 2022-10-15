using PromotItLibrary.Interfaces.Users;

namespace PromotItLibrary.Interfaces
{
    public interface ITweet
    {
        string Id { get; set; }
        ICampaign Campaign { get; set; }
        IUsers ActivistUser { get; set; }
        decimal Cash { get; set; }
        int Retweets { get; set; }
        bool IsApproved { get; set; }
    }
}
