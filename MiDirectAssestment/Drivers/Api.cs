using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiDirectAssestment.Drivers;

    public class Api
    {
        public RestClient? restClient { get; set; }
        public RestRequest? restRequest { get; set; }
        public RestResponse? restResponse { get; set; }
        public string? baseUrl { get; set; }
        public string? endPoint { get; set; }
        public string? responseString { get; set; }

        public RestResponse GetRequest(string endP)
        {
            restClient = new RestClient(baseUrl ?? throw new InvalidOperationException());
            restRequest = new RestRequest(endP, Method.Get);
            restRequest.AddHeader("Accept", "application/json");


            restResponse = restClient.ExecuteGetAsync(restRequest).GetAwaiter().GetResult();
            responseString = restResponse.Content;

            return restResponse;
        }

        public RestResponse PostRequest(string endP, string jsonStringBody)
        {
            restClient = new RestClient(baseUrl ?? throw new InvalidOperationException());
            restRequest = new RestRequest(endP, Method.Post);

            restRequest.AddHeader("Accept", "application/json");

            restRequest.AddJsonBody(jsonStringBody);

            restResponse = restClient.ExecutePostAsync(restRequest).GetAwaiter().GetResult();
            responseString = restResponse.Content;
            return restResponse;
        }

        public RestResponse DelRequest(string endP)
        {
            restClient = new RestClient(baseUrl ?? throw new InvalidOperationException());
            restRequest = new RestRequest(endP, Method.Delete);

            restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded;charset=UTF-8");
            restRequest.AddHeader("Accept", "application/json, text/plain, */*");

            restResponse = restClient.ExecuteAsync(restRequest).GetAwaiter().GetResult();
            responseString = restResponse.Content;
            return restResponse;
        }
        

        public RestResponse PutRequest(string endP, string jsonStringBody)
        {
            restClient = new RestClient(baseUrl ?? throw new InvalidOperationException());
            restRequest = new RestRequest(endP, Method.Put);

            restRequest.AddHeader("Accept", "application/json, text/plain, */*");

            restRequest.AddJsonBody(jsonStringBody);

            restResponse = restClient.ExecutePutAsync(restRequest).GetAwaiter().GetResult();
            responseString = restResponse.Content;
            return restResponse;
    }

        public string? SearchWithJsonPath(string path)
        {
            var jsonObj = JObject.Parse(responseString ?? throw new ArgumentNullException(nameof(responseString)));

            var pathResult = jsonObj.SelectToken(path);

            return pathResult?.ToString();
        }

        public string? SearchArrayWithJsonPath(string path)
        {
            JArray jsonArray = JArray.Parse(responseString ?? throw new ArgumentNullException(nameof(responseString)));
    
            var jsonObjects = (JObject)jsonArray[0];

            var pathResult = jsonObjects.SelectToken(path);
            
            return pathResult?.ToString();
        }
    }
