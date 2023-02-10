using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace MyTodo.Service
{
    public class HttpRestSharpService : IHttpService
    {
        private readonly RestClient _restClient;

        public HttpRestSharpService(RestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<string> ExecuteAsync(BaseRequest baseRequest)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(baseRequest.Url))
                {
                    return "request url is empty";
                }
                var url = new Uri(baseRequest.Url);
                var request = new RestRequest(url, baseRequest.Method);
                request.AddHeader("Content-Type", baseRequest.ContentType);
                if (baseRequest.Parameter != null)
                {
                    var parameter = JsonConvert.SerializeObject(baseRequest.Parameter);
                    request.AddParameter("application/json", parameter, ParameterType.RequestBody);
                }
                var response = await _restClient.ExecuteAsync(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return response.Content;
                }

                if (response.ErrorException != null)
                {
                    return response.ErrorException.Message;
                }

                return response.ErrorMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<TResponse> GetAsync<TResponse>(string url) where TResponse : class
        {
            var baseRequest = new BaseRequest
            {
                Url = url,
                Method = Method.Get
            };

            var result = await ExecuteAsync(baseRequest);

            return (typeof(TResponse) == typeof(string)) ? ((result as TResponse)) : (ToJsonModel<TResponse>(result));
        }

        public async Task<TResponse> PostAsync<TResponse>(string url, object? parameter) where TResponse : class
        {
            var baseRequest = new BaseRequest()
            {
                Url = url,
                Method = Method.Post,
                Parameter = parameter
            };

            var result = await ExecuteAsync(baseRequest);

            return (typeof(TResponse) == typeof(string)) ? ((result as TResponse)) : (ToJsonModel<TResponse>(result));
        }

        public T? ToJsonModel<T>(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                return default(T);
            }
            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            try
            {
                //   jsonSerializerOptions.Converters.Add(new DateTimeConverterUsingDateTimeParse());
                var result = JsonSerializer.Deserialize<T>(json, jsonSerializerOptions);

                return result;
            }
            catch (Exception)
            {
                return default(T);
            }
        }
    }
}