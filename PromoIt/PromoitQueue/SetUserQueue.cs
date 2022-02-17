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
using PromotItLibrary.Models;
using PromotItLibrary.Classes;
namespace PromoitQueue
{
    public static class SetUserQueue
    {
        private static HTTPClient httpClient = Configuration.HTTPClient;

        [FunctionName("SetUserQueue")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {       //POST/GET a message after queue to the function

            string sentToAddressKey = Configuration.SetUserFunctions;
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
                requestBody = httpClient.HttpUrlDecode(requestBody);
                Dictionary<string, string> keyValuePairs = httpClient.PostMessageSplit(requestBody);
                string data = keyValuePairs["data"].ToString();
                string type = keyValuePairs["type"].ToString()??"";
                if (!string.IsNullOrEmpty(data))
                    return new OkObjectResult(await httpClient.PostStringRequest(sentToAddressKey, data, type));
            }
            catch { }

            return new BadRequestObjectResult("Queue Failed");
        }
    }
}
