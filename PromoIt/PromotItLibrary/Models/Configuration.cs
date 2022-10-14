using ConnectionKeys;
using PromotItLibrary.Classes;
using PromotItLibrary.Enums;
using PromotItLibrary.Interfaces;
using System.Threading.Tasks;
using Tweetinvi;


namespace PromotItLibrary.Models
{
    public class Configuration
    {
        /*TODO*/
        // Split register to types! instead of if statement
        // Fix Key Organization
        // Fix Enums
        // refactore
        // improve interface implamentation
        // set state pattern for configureations for 
        // why there is static on mySQL ?
        // check if can change linkedlist to array
        /*set web assembly*/
        /*add readonly to functions*/
        /*add IDisposible to each class, like MySQL, and using for each applying in programming*/
        /*Fix MySQL (Multi) Request, For Async Method*/
        /*fix close mysql after each call*/
        /*Add Read From File Development*/
        /*Add user Token For any working*/
        /*Add Transaction to each procedure*/
        /*Set Transactions*/
        /*Set CosmosDB*/
        /*Close connection for mysql after each action*/
        /*Check Alon Version*/
        /*Cosmos /MongoDB*/
        /*Fix Exeption on register by check if it still count, make Exeption OOP*/
        // https://stackoverflow.com/questions/9974325/mysql-transaction-within-a-stored-procedure
        /* set MySQL class to callback functions */
        /*set external functions */
        /* set cancelation token */
        /* set interfaces*/
        /* c# null guides https://www.youtube.com/watch?v=aIp0jUr6A24*/

        /// <summary>
        /// System global mode settings
        /// </summary>
        public static Modes LocalMode { get; set; } = Modes.Local;   //Mode s.Local or Modes.NotLocal //Local is for testing purposes
        public static Modes Mode { get; set; } = Modes.Null; // Modes.Queue or Modes.Functions or Modes.Null /null
        public static Modes DatabaseMode { get; set; } = Modes.MySQL; // Modes.MySQL only


        /// <summary>
        /// Tries Counter
        /// </summary>
        private static int _tries = TriesReset();
        private static int Tries { get { return _tries; } set { _tries = value; } }
        public static int TriesReset() { Tries = 0; return _tries; }
        public static bool IsTries(int maxTries = 3, int sleepBetWeenTries = 500) { Task.Delay(sleepBetWeenTries * _tries); return Tries++ < maxTries; }    //Number of tries is 3//between tries 500ms


        /// <summary>
        /// Public Sources
        /// </summary>
        public static IUsers CorrentUser { get; set; }
        public static IUsers LoginUser { get; set; }
        public static ICampaign CorrentCampaign { get; set; }
        public static IProductInCampaign CorrentProduct { get; set; }
        public static MySQL MySQL { get { MySQLStart(); return _mySQL; } set { _mySQL = value; } }
        public static HTTPClient HTTPClient { get { HTTPClientStart(); return _httpClient; } set { _httpClient = value; } }
        public static string Message { get; set; }
        public static TwitterClient TwitterUserClient { get { TwitterUserClientStart(); return _twitterUserClient; } set { _twitterUserClient = value; } }
        public static string ActivistCashDefultSet { get; } = "1000.0"; //set to 0

        /// <summary>
        /// Sorces start private functions
        /// </summary>
        /// 
        private static void TwitterUserClientStart() => TwitterUserClient = _twitterUserClient ?? new TwitterClient(APIKey, APISecret, APIToken, APITokenSecret);
        private static void MySQLStart()
            => MySQL =
                (
                    (LocalMode == Modes.NotLocal_ProtectedKey) ? _mySQL ?? new MySQL(ConnectionKeySet.MySQLKey_Server, ConnectionKeySet.MySQLKey_User, ConnectionKeySet.MySQLKey_Password, ConnectionKeySet.MySQLKey_Database)
                    : (LocalMode == Modes.Local) ? _mySQL ?? new MySQL(ConnectionKeySet.MySQLKey_Server_Local, ConnectionKeySet.MySQLKey_User_Local, ConnectionKeySet.MySQLKey_Password_Local, ConnectionKeySet.MySQLKey_Database_Local)
                    : _mySQL ?? null
                );

        private static void HTTPClientStart() => HTTPClient = _httpClient ?? new HTTPClient();


        /// <summary>
        /// Queue Addresses
        /// </summary>
        public static string PromoitCampaignQueue { get; } =
            LocalMode == Modes.NotLocal_ProtectedKey ? ConnectionKeySet.PromoitCampaignQueue
                : LocalMode == Modes.Local ? "http://localhost:7076/api/PromoitCampaignQueue"
                : "";
        public static string PromoitProductQueue { get; } =
            LocalMode == Modes.NotLocal_ProtectedKey ? ConnectionKeySet.PromoitProductQueue
                : LocalMode == Modes.Local ? "http://localhost:7076/api/PromoitProductQueue"
                : "";
        public static string PromoitTweetQueue { get; } =
            LocalMode == Modes.NotLocal_ProtectedKey ? ConnectionKeySet.PromoitTweetQueue
                : LocalMode == Modes.Local ? "http://localhost:7076/api/PromoitTweetQueue"
                : "";
        public static string SetUserQueue { get; } =
            LocalMode == Modes.NotLocal_ProtectedKey ? ConnectionKeySet.SetUserQueue
                : LocalMode == Modes.Local ? "http://localhost:7076/api/SetUserQueue"
                : "";



        /// <summary>
        /// Functions Addresses
        /// </summary>
        public static string PromoitCampaignFunctions { get; } =
            LocalMode == Modes.NotLocal_ProtectedKey ? ConnectionKeySet.PromoitCampaignFunctions
                : LocalMode == Modes.Local ? "http://localhost:7074/api/PromoitCampaignFunctions"
                : "";
        public static string PromoitProductFunctions { get; } =
            LocalMode == Modes.NotLocal_ProtectedKey ? ConnectionKeySet.PromoitProductFunctions
                : LocalMode == Modes.Local ? "http://localhost:7074/api/PromoitProductFunctions"
                : "";
        public static string PromoitTweetFunctions { get; } =
            LocalMode == Modes.NotLocal_ProtectedKey ? ConnectionKeySet.PromoitTweetFunctions
                : LocalMode == Modes.Local ? "http://localhost:7074/api/PromoitTweetFunctions"
                : "";
        public static string SetUserFunctions { get; } =
            LocalMode == Modes.NotLocal_ProtectedKey ? ConnectionKeySet.SetUserFunctions
                : LocalMode == Modes.Local ? "http://localhost:7074/api/SetUser"
                : "";

        /// <summary>
        /// Twitter API keys
        /// </summary>
        private static string APIKey { get; } = ConnectionKeySet.APIKey;
        private static string APISecret { get; } = ConnectionKeySet.APISecret;
        private static string APIToken { get; } = ConnectionKeySet.APIToken;
        private static string APITokenSecret { get; } = ConnectionKeySet.APITokenSecret;

        /// <summary>
        /// Private Sources
        /// </summary>
        private static MySQL _mySQL;
        private static HTTPClient _httpClient;
        private static TwitterClient _twitterUserClient;

        /// <summary>
        /// Sources Dispose
        /// </summary>
        ~Configuration() {}
    }

}
