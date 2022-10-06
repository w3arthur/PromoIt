 namespace ConnectionKeys
{
     
    public struct ConnectionKeySet //delete the Empty part
    {
        //set as git ignore

        //MySQL Local
        public static string MySQLKey_Server_Local { get; } = "localhost";
        public static string MySQLKey_User_Local { get; } = "root";
        public static string MySQLKey_Password_Local { get; } = "admin";
        public static string MySQLKey_Database_Local { get; } = "promoit";

        //Queue Local

        //Functions Local



        //MySQL Sever
        public static string MySQLKey_Server { get; } = "";
        public static string MySQLKey_User { get; } = "";
        public static string MySQLKey_Password { get; } = "";
        public static string MySQLKey_Database { get; } = "";

        //Queue Sever
        public static string PromoitCampaignQueue { get; } = "";
        public static string PromoitProductQueue { get; } = "";
        public static string PromoitTweetQueue { get; } = "";
        public static string SetUserQueue { get; } = "";
        
        //Functions Sever
        public static string PromoitCampaignFunctions { get; } = "";
        public static string PromoitProductFunctions { get; } = "";
        public static string PromoitTweetFunctions { get; } = "";
        public static string SetUserFunctions { get; } = "";


        //Tweeter
        public static string APIKey { get; } = "";
        public static string APISecret { get; } = "";
        public static string APIToken { get; } = "";
        public static string APITokenSecret { get; } = "";





    }
}
