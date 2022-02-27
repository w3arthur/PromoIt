using PromotItLibrary.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns
{
    public class ActionsUser
    {
        private Users _user;
        private ActivistUser _activistUser;
        private AdminUser _adminUser;
        private NonProfitUser _nonProfitUser;
        private BusinessUser _businessUser;

        public ActionsUser(Users user) => _user = user;
        public ActionsUser(ActivistUser activistUser) => _activistUser = activistUser;
        public ActionsUser(AdminUser adminUser) => _adminUser = adminUser;
        public ActionsUser(NonProfitUser nonProfitUser) => _nonProfitUser = nonProfitUser;
        public ActionsUser(BusinessUser businessUser) => _businessUser = businessUser;


        public async Task<Users> LoginAsync(Modes mode = null) 
        {
            if(_user == null) return null;  //throw
            return await _user.LoginAsync(mode);
        }

        public async Task<bool> RegisterAsync(Modes mode = null) 
        {
            if (_activistUser != null)
            {
                return await _activistUser.RegisterAsync(mode);
            }
            else if (_adminUser != null)
            {
                return await _adminUser.RegisterAsync(mode);
            }
            else if (_nonProfitUser != null)
            {
                return await _nonProfitUser.RegisterAsync(mode);
            }
            else if (_businessUser != null)
            {
                return await _businessUser.RegisterAsync(mode);
            }
            return false;
        }

        public async Task<DataTable> GetAllCampaignsAdmin_DataTableAsync() 
        {
            if(_adminUser == null ) return null;
            return await _adminUser.GetAllCampaignsAdmin_DataTableAsync();
        }

        public async Task<List<Users>> MySQL_GetAllUsers_ListAsync(Modes mode = null)
        {
            if (_adminUser == null) return null;
            return await _adminUser.MySQL_GetAllUsers_ListAsync(mode);
        }

        public async Task<DataTable> GetAllUsers_DataTableAsync()
        {
            if (_adminUser == null) return null;
            return await _adminUser.GetAllUsers_DataTableAsync();
        }







    }
}
