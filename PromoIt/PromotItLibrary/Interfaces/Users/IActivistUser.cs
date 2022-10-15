
namespace PromotItLibrary.Interfaces.Users
{
    public interface IActivistUser
    {
        static string CashDefultSet { get; }

        string Email { get; set; }
        string Address { get; set; }
        string PhoneNumber { get; set; }
        string Cash { get; set; }
    }
}
