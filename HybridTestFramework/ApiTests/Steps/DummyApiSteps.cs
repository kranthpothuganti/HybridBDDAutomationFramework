using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;
using TestCore.Api;

namespace ApiTests.Steps
{
    [Binding]
    public class DummyApiSteps
    {
        private ApiClient _apiClient;
        private RestResponse _response;

        [Given(@"the API base URL is ""(.*)""")]
        public void GivenTheApiBaseUrlIs(string baseUrl)
        {
            _apiClient = new ApiClient(baseUrl);
        }

        [When(@"I send a GET request to ""(.*)""")]
        public void WhenISendAGetRequest(string endpoint)
        {
            _response = _apiClient.Get(endpoint);
        }

        [Then(@"the response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int expectedStatusCode)
        {
            Assert.That(expectedStatusCode, Is.EqualTo((int)_response.StatusCode));
        }

        [Then(@"the response should contain ""(.*)""")]
        public void ThenTheResponseShouldContain(string expectedKey)
        {
            Assert.That(_response.Content.Contains(expectedKey));
        }
    }
}
