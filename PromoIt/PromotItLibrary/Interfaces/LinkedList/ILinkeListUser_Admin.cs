using PromotItLibrary.Enums;
using PromotItLibrary.Interfaces.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PromotItLibrary.Interfaces.LinkedList
{
    public interface ILinkeListUser_Admin
    {
        Task<List<IUsers>> GetAllUsers_ListAsync(Modes mode = null);
    }
}
