using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace surveyVSS
{
    namespace Infrastructure.Rest
    {
        public abstract class CustomHttpClient : HttpClient
        {
            public virtual async Task PreprocessResponse(HttpResponseMessage responseMessage)
            {
                if (!responseMessage.IsSuccessStatusCode)
                {
                    string bodyText = await responseMessage.Content.ReadAsStringAsync();
                    throw new Exception(bodyText);
                }
            }

            public virtual HttpRequestMessage InitRequest(HttpMethod method, string path, Dictionary<string, string> queries)
            {
                string requestUri = path;
                if (queries != null)
                {
                    var listQuery = queries.Select(s => string.Format("{0}={1}", s.Key, s.Value));
                    var queryString = string.Join("&", listQuery);
                    requestUri = string.Format("{0}?{1}", requestUri, queryString);
                }

                HttpRequestMessage request = new HttpRequestMessage(method, requestUri)
                {
                    Version = new Version("6.0")
                };

                return request;
            }

            public virtual void SetRequestBody(HttpRequestMessage requestMessage, object obj)
            {
                if (obj != null)
                    requestMessage.Content = new StringContent(NewtonJson.Serialize(obj), Encoding.UTF8, "application/json");
            }

            public async Task<T> GetAsync<T>(string path, Dictionary<string, string> queries)
            { 
                try
                {
                    var requestMessage = InitRequest(HttpMethod.Get, path, queries);
                    var responseMessage = await SendAsync(requestMessage).ConfigureAwait(false);
                    await PreprocessResponse(responseMessage);
                    string bodyText = await responseMessage.Content.ReadAsStringAsync();
                    return NewtonJson.Deserialize<T>(bodyText);
                    //return NewtonJson.Deserialize<T>(bodyText,JsonSettings.Snake);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return default;
                }
            }

            public async Task<T> PostAsync<T>(string path, Dictionary<string, string> queries, object obj)
            {
                var requestMessage = InitRequest(HttpMethod.Post, path, queries);
                SetRequestBody(requestMessage, obj);
                var responseMessage = await SendAsync(requestMessage);
                await PreprocessResponse(responseMessage);
                string bodyText = await responseMessage.Content.ReadAsStringAsync();
                return NewtonJson.Deserialize<T>(bodyText);
            }

            public async Task<T> PutAsync<T>(string path, Dictionary<string, string> queries, object obj)
            {
                var requestMessage = InitRequest(HttpMethod.Put, path, queries);
                SetRequestBody(requestMessage, obj);
                var responseMessage = await SendAsync(requestMessage);
                await PreprocessResponse(responseMessage);
                string bodyText = await responseMessage.Content.ReadAsStringAsync();
                return NewtonJson.Deserialize<T>(bodyText);
            }

            public async Task<T> DeleteAsync<T>(string path, Dictionary<string, string> queries, object obj)
            {
                var requestMessage = InitRequest(HttpMethod.Delete, path, queries);
                SetRequestBody(requestMessage, obj);
                var responseMessage = await SendAsync(requestMessage);
                await PreprocessResponse(responseMessage);
                string bodyText = await responseMessage.Content.ReadAsStringAsync();
                return NewtonJson.Deserialize<T>(bodyText);
            }
        }
    }
}
