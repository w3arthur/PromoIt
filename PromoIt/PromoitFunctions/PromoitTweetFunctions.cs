using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using PromotItLibrary.Models;
using PromotItLibrary.Classes;
using System.Threading;
using PromotItLibrary.Patterns;

namespace PromoitFunction
{
    public static class PromoitTweetFunctions
    {
        [FunctionName("PromoitTweetFunctions")]
        public static async Task<IActionResult> Run(
                    [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
                    ILogger log)
        {

            Modes FunctionOrDatabaseMode = Configuration.DatabaseMode;
            string azureFunctionString = "Azue Function";


            string className = "Data";
            log.LogInformation($"{azureFunctionString} Find {className} Activated");

            try
            {   //get
                string data = req.Query["data"];
                string type = req.Query["type"];
                if (data != null && type != null)
                {

                    try
                    {
                        if (type == "GetAllTweets")
                        {
                            className = "Get All Tweet List";
                            Tweet tweet = HTTPClient.JsonStringToSingleObject<Tweet>(data);
                            if (tweet == null) throw new Exception($"GET: No {className} Found In Databae!");
                            List<Tweet> campaignList = await tweet.MySQL_GetAllTweets_ListAsync(FunctionOrDatabaseMode);
                            log.LogInformation($"Function Found {className}");
                            return new OkObjectResult(HTTPClient.ObjectToJsonString(campaignList));
                        }

                    }
                    catch (Exception ex) { log.LogInformation($"Function GET ({className}) Datanase SELECT/GET-data Fail:\n{ex.Message}"); return new BadRequestObjectResult($"Not Found ({className})"); }

                }
            }
            catch (Exception ex) { log.LogInformation($"Function GET ({className}) Error Fail\n{ex.Message}"); }

            try
            {   //post
                using StreamReader streamReader = new StreamReader(req.Body);
                string requestBody = await streamReader.ReadToEndAsync();
                if (!string.IsNullOrEmpty(requestBody))
                {
                    requestBody = HTTPClient.HttpUrlDecode(requestBody);
                    Dictionary<string, string> keyValuePairs = HTTPClient.PostMessageSplit(requestBody);
                    string data = keyValuePairs["data"].ToString();
                    string type = keyValuePairs["type"].ToString();
                    try
                    {
                        bool action = false;
                        switch (type)
                        {
                            case "SetTweetCash":
                                className = "Set Tweet Cash";
                                Tweet tweet = HTTPClient.JsonStringToSingleObject<Tweet>(data);
                                if (tweet == null) throw new Exception($"POST: No {className} IS Enterd");
                                action = await tweet.SetTweetCashAsync(FunctionOrDatabaseMode);
                                break;

                            default:
                                break;
                        }

                        if (action)
                        {
                            log.LogInformation($"{azureFunctionString} Seccess to Insert {className} to database");
                            return new OkObjectResult("ok");        //good result
                        }

                    }
                    catch (Exception ex) { log.LogInformation($"{azureFunctionString} Not-Seccess to Insert {className} to database\nDetails:{ex}"); return new BadRequestObjectResult("fail"); } //bad result
                    log.LogInformation($"{azureFunctionString} Failed to Insert after Tried to Insert {className} to database");
                    return new BadRequestObjectResult("(2) No access to database for" + type);
                }
            }
            catch (Exception ex) { log.LogInformation($"{azureFunctionString} POST ({className}) Error Fail:{ex.Message}"); return new BadRequestObjectResult($"Function Error Fail:{ex.Message}"); }


            return new BadRequestObjectResult("");//No Results

        }
    }
}
