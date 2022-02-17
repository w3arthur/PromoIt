using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PromotItLibrary.Models;
using PromotItLibrary.Classes;
using System.Collections.Generic;

namespace PromoitQueue
{
    public static class PromoitTweetQueue
    {
        private static HTTPClient httpClient = Configuration.HTTPClient;

        [FunctionName("PromoitTweetQueue")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {       //POST/GET a message after queue to the function

            string sentToAddressKey = Configuration.PromoitTweetFunctions;
            string azureQueueString = "Azue Queue";

            try
            {//GET
                string data = req.Query["data"];
                string type = req.Query["type"];
                if (!string.IsNullOrEmpty(data) && !string.IsNullOrEmpty(type))
                    return new OkObjectResult(await httpClient.GetStringRequest(sentToAddressKey, data, type));

            }
            catch { }


            try
            {//POST
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                requestBody = HTTPClient.HttpUrlDecode(requestBody);
                Dictionary<string, string> keyValuePairs = HTTPClient.PostMessageSplit(requestBody);
                string data = keyValuePairs["data"].ToString();
                string type = keyValuePairs["type"].ToString();
                if (!string.IsNullOrEmpty(data) && !string.IsNullOrEmpty(type))
                    return new OkObjectResult(await httpClient.PostStringRequest(sentToAddressKey, data, type));

            }
            catch { }

            return new BadRequestObjectResult("Queue Failed");
        }
    }
}
