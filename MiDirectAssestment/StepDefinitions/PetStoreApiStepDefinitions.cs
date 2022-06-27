using MiDirectAssestment.Drivers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiDirectAssestment.StepDefinitions
{
    [Binding]
    public class PetStoreApiStepDefinitions
    {
        private Api _api = new();

        [Given(@"The user set base url as : (.*)")]
        public void GivenTheUserSetBaseUrlAsHttpsPetstoreSwagger(string url)
        {
            _api.baseUrl = url;
        }

        [Given(@"The user should see the response (.*)")]
        public void GivenTheUserShouldSeeTheResponse(int expectedCode)
        {
            if (_api.restResponse != null)
            {
                int responseCode = (int)_api.restResponse.StatusCode;
                responseCode.Should().Be(expectedCode);
            }
        }


        [Given(@"The user sends get request to (.*) with ""(.*)""")]
        public void GivenTheUserSendsGetRequestToPetFindByStatusStatusSold(string endPoint , string id )
        {
            _api.endPoint = endPoint + id;
            _api.GetRequest(_api.endPoint);
        }

        [Given(@"The user controls (.*) details in response")]
        public void GivenTheUserControlGetPendingPetsDetailsİnResponse(string command)
        {
            var result="";
            switch (command)
            {
                case "getAvailablePets":
                    result = _api.SearchArrayWithJsonPath("$..status");
                    result.Should().Be("available");
                    break;

                case "getPendingPets":
                    result = _api.SearchArrayWithJsonPath("$..status");
                    result.Should().Be("pending");
                    break;

                case "getSoldPets":
                    result = _api.SearchArrayWithJsonPath("$..status");
                    result.Should().Be("sold");
                    break;

                case "postrequesttopet":
                    result = _api.SearchWithJsonPath("$.id");
                    result.Should().Be("25062022");
                    break;
                   
            }
        
        }

        [Given(@"The user sends post request for ""(.*)"" to update name ""(.*)""")]
        public void GivenTheUserSendsPostRequestForToUpdateName(string id, string name)
        {
            string endpoint = "/pet/" + id;
            string jsonBody = @"{name = " + name + "}";
           

            _api.restClient = new RestClient(_api.baseUrl ?? throw new InvalidOperationException());
            _api.restRequest = new RestRequest(endpoint, Method.Post);

            _api.restRequest.AddHeader("Accept", "application/json");
            _api.restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            _api.restRequest.AddJsonBody(jsonBody);

            _api.restResponse = _api.restClient.ExecutePostAsync(_api.restRequest).GetAwaiter().GetResult();
            _api.responseString = _api.restResponse.Content;
        }

        [Given(@"The user should see that name of ""(.*)"" is updated as ""(.*)""")]
        public void GivenTheUserShouldSeeThatNameOfİsUpdatedAs(string id, string name)
        {
            _api.endPoint = "/pet/" + id;
            _api.GetRequest(_api.endPoint);

            var result = _api.SearchWithJsonPath("$.name");
            result.Should().Be(name);
        }

        [Given(@"The user send delete request to (.*) with ""(.*)""")]
        public void GivenTheUserSendDeleteRequestToDeletesPetWith(string endPoint, string id)
        {
            _api.endPoint = endPoint + id;

            _api.DelRequest(_api.endPoint);

        }


        [Given(@"The user sends post request to /pet")]
        public void GivenTheUserSendsPostRequestToPet()
        {
            string endpoint = "/pet";
            string jsonBody  = @"{""id"":25062022,
                                 ""category"":{
                                    ""id"":25062022,
                                    ""name"":""muratguven""
                                    },
                                ""name"":""muratguven"",
                                ""photoUrls"":[
                                    ""string""
                                    ],
                                ""tags"":[
                                  {
                                      ""id"":25062022,
                                      ""name"":""muratguven""
                                   }
                                ],
                                  ""status"":""available""
                                }";

            _api.PostRequest(endpoint, jsonBody);
        }

        [Given(@"The user sends post request to /pet for pending test")]
        public void GivenTheUserSendsPostRequestToPetForPendingTest()
        {
            string endpoint = "/pet";
            string jsonBody = @"{""id"":26062022,
                                 ""category"":{
                                    ""id"":25062022,
                                    ""name"":""muratguven""
                                    },
                                ""name"":""muratguven"",
                                ""photoUrls"":[
                                    ""string""
                                    ],
                                ""tags"":[
                                  {
                                      ""id"":25062022,
                                      ""name"":""muratguven""
                                   }
                                ],
                                  ""status"":""pending""
                                }";

            _api.PostRequest(endpoint, jsonBody);
        }

        [Given(@"The user sends post request to /pet with invalid Id")]
        public void GivenTheUserSendsPostRequestToPetWithİnvalidId()
        {

            string endpoint = "/pet";
            string jsonBody = @"{""id"":aa,
                                 ""category"":{
                                    ""id"":25062022,
                                    ""name"":""muratguven""
                                    },
                                ""name"":""muratguven"",
                                ""photoUrls"":[
                                    ""string""
                                    ],
                                ""tags"":[
                                  {
                                      ""id"":25062022,
                                      ""name"":""muratguven""
                                   }
                                ],
                                  ""status"":""available""
                                }";
            _api.PostRequest(endpoint, jsonBody);
        }

        [Given(@"The user should see (.*) is ""(.*)"" in the response")]
        public void GivenTheUserShouldSeeİnTheResponse(string message , string text)
        {
            var result = _api.SearchWithJsonPath("$."+ message +"");

            result.Should().Contain(text);      
        }

        [Given(@"The user sends post request to /store/order")]
        public void GivenTheUserSendsPostRequestToStoreOrder()
        {
            string endpoint = "/store/order/";

            string _jsonString = "{\"id\": 8," +
                            "\"petId\": 0," +
                            "\"quantity\": 0," +
                            "\"shipDate\":\"2022-06-26T09:17:50.771Z\"," +
                            "\"status\": \"placed\"," +
                            "\"complete\": true}";

            _api.PostRequest(endpoint, _jsonString);

         }
    }

}
