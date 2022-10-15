
namespace PromotItLibrary.Interfaces.Users
{
    public interface IUsers
    {
        string UserName { get; set; }
        string UserPassword { get; set; }
        string UserType { get; set; }
        string Name { get; set; }
        string Token { get; set; }
    }
}
