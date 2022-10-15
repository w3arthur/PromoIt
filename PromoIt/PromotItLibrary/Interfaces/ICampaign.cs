using PromotItLibrary.Interfaces.Users;

namespace PromotItLibrary.Interfaces
{
    public interface ICampaign
    {
        string Name { get; set; }
        string Hashtag { get; set; }
        string Url { get; set; }
        IUsers NonProfitUser { get; set; }
    }
}