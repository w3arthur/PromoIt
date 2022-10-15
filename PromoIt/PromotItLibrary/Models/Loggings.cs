using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PromotItLibrary.Classes;
using PromotItLibrary.Classes.Users;
using Serilog;
using Serilog.Sinks.File;

namespace PromotItLibrary.Models
{
    public struct Loggings
    {

        /* TODO */
        /*Chenge to Logging Class*/
        /*Then use it in config or logging structure*/

        public static ILogger<Campaign> CampaignsLog { get; } = setLogger<Campaign>(@"./../../../../../Logs/Campaigns/CampaignLog.txt");
        public static ILogger<Users> UsersLog { get; } = setLogger<Users>(@"./../../../../../Logs/Users/UsersLog.txt");
        public static ILogger<Tweet> TweeterLogs { get;  } = setLogger<Tweet>(@"./../../../../../Logs/Tweets/TweetLogs.txt");
        private static ILogger<AdminUser> _errorLogs { get;} = setLogger<AdminUser>(@"./../../../../../Logs/Errors/ErrorLogs.txt");
        private static ILogger<AdminUser> _reportLogs { get; } = setLogger<AdminUser>(@"./../../../../../Logs/Reports/ReportLogs.txt");

        public static void ReportLog(string logString) 
        {
            _reportLogs.LogInformation(logString);
        }

        public static void ErrorLog(string logString)
        {
            _reportLogs.LogError(logString);
            _errorLogs.LogError(logString);
        }

        private static ServiceProvider _serviceProvider(string address)
            => new ServiceCollection().AddLogging ( builder => { LoggerConfiguration loggerConfiguration = new LoggerConfiguration().WriteTo.File(address, rollingInterval: RollingInterval.Day);  builder.AddSerilog(loggerConfiguration.CreateLogger()); } ).BuildServiceProvider();
        // builder.SetMinimumLevel(LogLevel.Trace); builder.AddDebug(); //builder.AddConsole();

        public static ILogger<T> setLogger<T>(string address) => (ILogger<T>)_serviceProvider(address).GetService<ILoggerFactory>().CreateLogger<T>();

    }
}
