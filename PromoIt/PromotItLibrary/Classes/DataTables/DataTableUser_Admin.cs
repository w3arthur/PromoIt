using Microsoft.Extensions.Logging;
using PromotItLibrary.Classes;
using PromotItLibrary.Classes.Users;
using PromotItLibrary.Interfaces;
using PromotItLibrary.Interfaces.DataTables;
using PromotItLibrary.Interfaces.Users;
using PromotItLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Patterns.LinkedLists
{
    public class DataTableUser_Admin : IDataTableUser_Admin
    {

        private readonly AdminUser _adminUser;

        public DataTableUser_Admin(AdminUser adminUser) 
        {
            _adminUser = adminUser;
        }

        public async Task<DataTable> GetAllUsers_DataTableAsync()
        {
            if (_adminUser == null) return null;

            DataTable dataTable = new DataTable();
            List<IUsers> userList = await _adminUser.GetAllUsers_ListAsync();
            foreach (string culmn in new[] { "Name", "UserName", "Type" })
                dataTable.Columns.Add(culmn);

            if (userList == null)
            {
                while (Configuration.IsTries()) return await GetAllUsers_DataTableAsync();
                Loggings.ErrorLog($"Admin Requested to get all users list, The list is empty, Reguested by ({_adminUser.UserName})");
                Configuration.TriesReset();
                return dataTable;//no results
            }
            Configuration.TriesReset();

            Loggings.UsersLog.LogInformation($"Users List, Reguested by ({_adminUser.UserName})");
            foreach (Users user in userList)
            {
                DataRow dataRow = dataTable.NewRow();
                foreach (var (key, value) in new[] { ("Name", user.Name), ("UserName", user.UserName), ("Type", user.UserType) }) dataRow[key] = value;
                dataTable.Rows.Add(dataRow);
                Loggings.UsersLog.LogInformation($"User UserName (#{user.UserName}) Name ({user.Name}) Type ({user.UserType})");
            }
            Loggings.UsersLog.LogInformation($"Report end");
            Loggings.ReportLog($"Admin Requested to get all users list, Reguested by ({_adminUser.UserName})");
            return dataTable;
        }


        public async Task<DataTable> GetAllCampaignsAdmin_DataTableAsync()
        {
            if (_adminUser == null) return null;

            DataTable dataTable = new DataTable();
            List<ICampaign> campaignsList = await (new Campaign()).GetAllCampaigns_ListAsync();       //From Campaign Class
            foreach (string culmn in new[] { "Hashtag", "Webpage", "Creator" }) dataTable.Columns.Add(culmn);

            if (campaignsList == null)
            {
                while (Configuration.IsTries())
                    return await GetAllCampaignsAdmin_DataTableAsync();
                Loggings.ErrorLog($"Admin Requested to get all campaigns list, The list is empty, Reguested by ({_adminUser.UserName})");
                Configuration.TriesReset();
                return dataTable;//no results
            }
            Configuration.TriesReset();

            Loggings.CampaignsLog.LogInformation($"Campaign List, Reguested by ({_adminUser.UserName})");
            foreach (Campaign campaign in campaignsList)
            {
                DataRow dataRow = dataTable.NewRow();
                foreach (var (key, value) in new[] { ("Hashtag", campaign.Hashtag), ("Webpage", campaign.Url), ("Creator", campaign.NonProfitUser.UserName) }) dataRow[key] = value;
                dataTable.Rows.Add(dataRow);
                Loggings.CampaignsLog.LogInformation($"Campaign Hashtag (#{campaign.Hashtag}) Creator ({campaign.NonProfitUser.UserName}) Webpage ({campaign.Url})");
            }
            Loggings.CampaignsLog.LogInformation($"Report end");
            Loggings.ReportLog($"Admin Requested to get all campaigns list, Reguested by ({_adminUser.UserName})");
            return dataTable;
        }


    }
}
