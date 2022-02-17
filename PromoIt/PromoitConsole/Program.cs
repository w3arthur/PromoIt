using System;
using System.Net;
using System.Text;  // For class Encoding
using System.IO;
using System.Net.Http;
using System.Collections.Generic;
using PromotItLibrary.Classes;
using PromotItLibrary.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using Tweetinvi;
using Tweetinvi.Parameters;
using PromoitTwitterAPI;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Serilog;

namespace PromoitConsole
{
    public class Program
    {

        private static MySQL mySQL = Configuration.MySQL;
        private static TwitterClient twitterUserClient = Configuration.TwitterUserClient;

        static async Task Main(string[] args)
        {


            //Testing Area

            //mySQL.Quary($"call promoit.buy_a_product(26, 1, 'a', 'not_shipped');");
            //mySQL.QuaryExecute();

            Console.WriteLine();
            Console.ReadLine();

            
        }
    }
}
