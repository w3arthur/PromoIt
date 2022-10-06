using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web;

using System.Threading;

namespace PromotItLibrary.Models
{

    /*TODO*/
    /*Disable internal Modes.Local/Modes.NotLocal and Loggings*/


    public class HTTPClient: IDisposable
    {
        private HttpClient _httpClient;

        public HTTPClient()
        {
            using HttpClient httpclient = _httpClient;
            _httpClient = new HttpClient();
        }

        ~HTTPClient() => _httpClient.Dispose();

        public void Dispose() => _httpClient.Dispose();


        public static string ObjectToJsonString<T>(T data) => JsonConvert.SerializeObject(data);
        public static T JsonStringToSingleObject<T>(string mycontent) => JsonConvert.DeserializeObject<T>(mycontent);
        public static List<T> JsonStringToObjectList<T>(string mycontent) => JsonConvert.DeserializeObject<List<T>>(mycontent);
        public static string HttpUrlDecode(string data) => HttpUtility.UrlDecode(data);
        public static Dictionary<string, string> PostMessageSplit(string requestBody)
            => requestBody.Split('&').Select(value => value.Split('=')).ToDictionary(pair => pair[0], pair => pair[1]);

        //Post
        public async Task<bool?> PostSingleDataInsert<T>(string postUrl, T obj, string type = "")
        {
            string objString = ObjectToJsonString(obj);
            string mycontent = await PostStringRequest(postUrl, objString, type);
            try
            {
                if (mycontent == "ok") return true;
                else if (mycontent == "fail") return false;
                throw new Exception(mycontent);
            }
            catch { Loggings.ErrorLog($"PostSingleDataInsert Fail"); throw new Exception("Fail to post a content: \n" + mycontent); }
        }
        public async Task<T> PostSingleDataRequest<T>(string postUrl, T obj, string type = "")
        {
            string objString = ObjectToJsonString(obj);
            string mycontent = await PostStringRequest(postUrl, objString, type);
            try { return JsonStringToSingleObject<T>(mycontent);}
            catch { Loggings.ErrorLog($"PostSingleDataRequest Fail"); throw new Exception("Fail to add a content: \n" + mycontent); }
        }

        //public async static Task<string> PostStringRequest<T>(string postUrl, T obj, string type = "")
        //{
        //    string objString = ObjectToJsonString(obj);
        //    return await PostStringRequest(postUrl, objString, type);
        //}

        public async Task<string> PostStringRequest(string postUrl, string objString, string type = "")
        {
            IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("type", type),
                new KeyValuePair<string, string>("data", objString)
            };
            return await PostRequest(postUrl, queries);
        }
        public async Task<string> PostRequest(string postUrl, IEnumerable<KeyValuePair<string, string>> queries) // another check method 
        {
            using HttpContent q = new FormUrlEncodedContent(queries);
            using HttpResponseMessage response = await _httpClient.PostAsync(postUrl, q);
            using HttpContent content = response.Content;
            string mycontent = await content.ReadAsStringAsync();   //Response
            return mycontent;
        }
        //Get
        public async Task<List<T>> GetMultipleDataRequest<T>(string getUrl, T obj, string type = "")
        {
            string objString = ObjectToJsonString(obj);
            string mycontent = await GetStringRequest(getUrl, objString, type); //Response
            try { return JsonStringToSingleObject<List<T>>(mycontent); }
            catch { Loggings.ErrorLog($"GetMultipleDataRequest Fail"); throw new Exception("Fail to get a content: \n" + mycontent);  }
        }
        public async Task<T> GetSingleDataRequest<T>(string getUrl, T obj, string type = "")
        {
            string objString = ObjectToJsonString(obj);
            string mycontent = await GetStringRequest(getUrl, objString, type);
            try { return JsonStringToSingleObject<T>(mycontent); }
            catch { Loggings.ErrorLog($"GetMultipleDataRequest Fail");  throw new Exception("Fail to get a content: \n" + mycontent); }
        }

        //public async static Task<string> GetStringRequest<T>(string getUrl, T obj, string type = "")
        //{
        //    string objString = ObjectToJsonString(obj);
        //    return await GetStringRequest(getUrl, objString, type); //Response
        //}

        public async Task<string> GetStringRequest(string getUrl, string objString, string type = "")
        {
            string getRequest = "type=" + type + "&data=" + objString;
            getRequest = (getRequest.Contains("?") ? "&" : "?") + getRequest;
            return await GetRequest(getUrl, getRequest); //Response
        }
        public async Task<string> GetRequest(string getUrl, string getRequest)
        {
            using HttpResponseMessage response = await _httpClient.GetAsync(getUrl + getRequest);
            using HttpContent content = response.Content;
            string mycontent = await content.ReadAsStringAsync();   //Response
            return mycontent;
        }

    }
}
