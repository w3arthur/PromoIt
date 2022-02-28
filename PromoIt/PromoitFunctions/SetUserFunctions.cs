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
    public static class SetUserFunctions
    {
        [FunctionName("SetUser")]
        public static async Task<IActionResult> Run(
                    [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
                    ILogger log)
        //=>  await SetUserAzure.RunAzure(req, log, Configuration.DatabaseMode, "Azue Function");

        {

            Modes FunctionOrDatabaseMode = Configuration.DatabaseMode;
            string azureFunctionString = "Azue Function";

            string className = "User";
            log.LogInformation($"{azureFunctionString} Find {className} Activated");

            try
            {   //get
                string data = req.Query["data"];
                string type = req.Query["type"];
                if (data != null)
                {
                    if (type == "GetAllUsers")
                    {
                        className = "Get All Users List";
                        List<Users> userList = await new ActionsUser(new AdminUser()).MySQL_GetAllUsers_ListAsync(FunctionOrDatabaseMode);
                        log.LogInformation($"{azureFunctionString} Found {className}");
                        return new OkObjectResult(HTTPClient.ObjectToJsonString(userList));
                    }

                }
            }
            catch (Exception ex) { log.LogInformation($"{azureFunctionString} GET ({className}) Error Fail\n{ex.Message}"); }

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
                        if (type == "Login")
                        {
                            Users user = HTTPClient.JsonStringToSingleObject<Users>(data);
                            if (user == null) throw new Exception($"POST: No {className} IS Enterd");
                            try
                            {
                                Users loggedUser = await new ActionsUser(user).LoginAsync(FunctionOrDatabaseMode);
                                if (loggedUser == null) throw new Exception($"POST: No {className} Found In Databae!");
                                log.LogInformation($"{azureFunctionString} Find {className} ({loggedUser.Name}) Type ({loggedUser.UserType})");

                                return new OkObjectResult(HTTPClient.ObjectToJsonString(loggedUser));
                            }
                            catch (Exception ex) { log.LogInformation($"{azureFunctionString} POST ({className}) Datanase SELECT/GET-data Fail:\n{ex.Message}"); return new BadRequestObjectResult($"Not Found ({className})"); }
                        }

                        Users userDataDynamic = HTTPClient.JsonStringToSingleObject<Users>(data);
                        if (userDataDynamic == null) throw new Exception($"POST: No {className} IS Enterd");

                        bool action = false;

                        switch (userDataDynamic.UserType)
                        {
                            case "non-profit":
                                NonProfitUser nonProfitUser = HTTPClient.JsonStringToSingleObject<NonProfitUser>(data);
                                if (nonProfitUser == null) throw new Exception($"POST: No {className} IS Enterd");
                                action = await new ActionsUser(nonProfitUser).RegisterAsync(FunctionOrDatabaseMode);
                                break;
                            case "admin":
                                AdminUser adminUser = HTTPClient.JsonStringToSingleObject<AdminUser>(data);
                                if (adminUser == null) throw new Exception($"POST: No {className} IS Enterd");
                                action = await new ActionsUser(adminUser).RegisterAsync(FunctionOrDatabaseMode);
                                break;
                            case "business":
                                BusinessUser businessUser = HTTPClient.JsonStringToSingleObject<BusinessUser>(data);
                                if (businessUser == null) throw new Exception($"POST: No {className} IS Enterd");
                                action = await new ActionsUser(businessUser).RegisterAsync(FunctionOrDatabaseMode);
                                break;
                            case "activist":
                                ActivistUser activistUser = HTTPClient.JsonStringToSingleObject<ActivistUser>(data);
                                if (activistUser == null) throw new Exception($"POST: No {className} IS Enterd");
                                action = await new ActionsUser(activistUser).RegisterAsync(FunctionOrDatabaseMode);
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
                    return new BadRequestObjectResult("(1) No access to database for" + type);
                }
            }
            catch (Exception ex) { log.LogInformation($"{azureFunctionString} POST ({className}) Error Fail:{ex.Message}"); return new BadRequestObjectResult($"Function Error Fail:{ex.Message}"); }


            return new BadRequestObjectResult("");//No Results

        }
    }
}
