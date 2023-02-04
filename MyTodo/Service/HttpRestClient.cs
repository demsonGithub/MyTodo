using MyTodo.Api.Shared.ApiResultModel;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTodo.Service
{
    public class HttpRestClient
    {
        private RestClient _client;

        public HttpRestClient(string apiUrl)
        {
            _apiUrl = apiUrl;
            _client = new RestClient(_apiUrl);
        }

        public Task<string> GetAsync(string url, string parameter, string contentType = "application/json")
        {
            try
            {
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ApiResult> ExecuteAsync(HttpRestRequest baseRequest)
        {
            var request = new RestRequest(baseRequest.Route, baseRequest.Method);
            request.AddHeader("Content-Type", baseRequest.ContentType);

            if (baseRequest.Parameter != null)
            {
                request.AddParameter("param", JsonConvert.SerializeObject(baseRequest.Parameter), ParameterType.RequestBody);
            }
            var response = await _client.ExecuteAsync(request);

            var result = JsonConvert.DeserializeObject<ApiResult>(response.Content);

            return result;
        }

        public async Task<ApiResult<T>> ExecuteAsync<T>(HttpRestRequest baseRequest)
        {
            var request = new RestRequest(baseRequest.Route, baseRequest.Method);
            request.AddHeader("Content-Type", baseRequest.ContentType);

            if (baseRequest.Parameter != null)
            {
                request.AddParameter("param", JsonConvert.SerializeObject(baseRequest.Parameter), ParameterType.RequestBody);
            }
            var response = await _client.ExecuteAsync(request);

            var result = JsonConvert.DeserializeObject<ApiResult<T>>(response.Content);

            return result;
        }
    }
}