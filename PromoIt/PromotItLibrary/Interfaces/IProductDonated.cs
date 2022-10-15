using PromotItLibrary.Interfaces.Users;

namespace PromotItLibrary.Interfaces
{
    public interface IProductDonated
    {
        IProductInCampaign ProductInCampaign { get; set; }
        IUsers ActivistUser { get; set; }
        string Quantity { get; set; }
        string Shipped { get; set; }
        string Id { get; set; }
    }
}
