using Moq;
using PromoitTesting.TestClasses;
using PromotItLibrary.Classes.Users;
using PromotItLibrary.Enums;
using PromotItLibrary.Interfaces.Users;
using PromotItLibrary.Models;
using PromotItLibrary.Patterns;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PromoitTesting
{


    public class AddAUserTest_LocalMySQL
    {
        private MySQL mySQL = Configuration.MySQL;

        [Fact]
        public async Task AddAUserTest_Local_MySQL()
        {
            Modes currentMode = Configuration.Mode;
            Modes currentLocalMode = Configuration.LocalMode;
            Modes currentLocalDatabase = Configuration.DatabaseMode;
            Configuration.Mode = Modes.Null;
            Configuration.LocalMode = Modes.Local;
            Configuration.DatabaseMode = Modes.MySQL;


            ActivistUser activistUser = new ActivistUser()
            {
                Name = "someNameForTest",
                UserPassword = "somePasswordForTest",
                UserName = "someUserNameForTest",
                UserType = "activist",
                Email = "Email@some.com",
                Address = "someAddress",
                PhoneNumber = "4656456654",
            };

            //Try Delete First
            await mySQL.QuaryExecuteAsync($"DELETE FROM `promoit`.`users_activists` WHERE (`user_name` = '{activistUser.UserName}');");
            await mySQL.QuaryExecuteAsync($"DELETE FROM `promoit`.`users` WHERE (`user_name` = '{activistUser.UserName}');");

            bool result1 = await activistUser.RegisterAsync();
            Assert.True(result1, "User Should Register / Function Mast Be Activated!");

            IUsers loggedInUser = await activistUser.LoginAsync();

            bool result2 = loggedInUser != null;
            Assert.True(result2, "Login User Should Accepted / Function Mast Be Activated");

            bool result3 =
                (loggedInUser.Name, loggedInUser.UserName, loggedInUser.UserPassword, loggedInUser.UserType)
                == (activistUser.Name, activistUser.UserName, activistUser.UserPassword, activistUser.UserType);

            //Delete For Next Test
            await mySQL.QuaryExecuteAsync($"DELETE FROM `promoit`.`users_activists` WHERE (`user_name` = '{activistUser.UserName}');");
            await mySQL.QuaryExecuteAsync($"DELETE FROM `promoit`.`users` WHERE (`user_name` = '{activistUser.UserName}');");

            Assert.True(result3, "Random User Shoul Register and Login to the System with same Values to Result / Function Mast Be Activated");

            //return to set values
            Configuration.Mode = currentMode;
            Configuration.LocalMode = currentLocalMode;
            Configuration.DatabaseMode = currentLocalDatabase;
        }

    }
}
