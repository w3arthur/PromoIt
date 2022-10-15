using PromotItLibrary.Interfaces.Users;

namespace PromotItLibrary.Interfaces
{
    public interface IProductInCampaign
    {
        string Id { get; set; }
        string Name { get; set; }
        string Quantity { get; set; }
        string Price { get; set; }
        IUsers BusinessUser { get; set; }
        ICampaign Campaign { get; set; }
    }

}
