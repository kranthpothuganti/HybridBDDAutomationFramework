using RestSharp;
using System.Net;

namespace TestCore.Api
{
    public class ApiClient
    {
        private readonly RestClient _client;

        public ApiClient(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }

        public RestResponse Get(string endpoint)
        {
            var request = new RestRequest(endpoint, Method.Get);
            return _client.Execute(request);
        }

        public RestResponse Post(string endpoint, object body)
        {
            var request = new RestRequest(endpoint, Method.Post);
            request.AddJsonBody(body);
            return _client.Execute(request);
        }

        public RestResponse Put(string endpoint, object body)
        {
            var request = new RestRequest(endpoint, Method.Put);
            request.AddJsonBody(body);
            return _client.Execute(request);
        }

        public RestResponse Delete(string endpoint)
        {
            var request = new RestRequest(endpoint, Method.Delete);
            return _client.Execute(request);
        }
    }
}
