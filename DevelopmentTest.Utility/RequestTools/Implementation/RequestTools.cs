using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DevelopmentTest.Utility.RequestTools.Interface;
using Newtonsoft.Json;

namespace DevelopmentTest.Utility.RequestTools.Implementation
{
    public class RequestTools : IRequestTools
    {
        public const string JsonContentType = "application/json";

        public async Task<T> Invoke<T>(HttpMethod httpMethod, string invokingUri,
            List<Tuple<string, string>> queryParameters = null, object content = null)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response;
                    if (httpMethod == HttpMethod.Get)
                    {
                        string uri;

                        if (queryParameters != null && queryParameters.Any())
                        {
                            var uriBuilder = new UriBuilder(invokingUri);
                            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                            foreach (var param in queryParameters)
                                query[param.Item1] = param.Item2;
                            uriBuilder.Query = query.ToString();
                            uri = uriBuilder.ToString();

                        }
                        else
                        {
                            uri = invokingUri;                           
                        }
                        response = await client.GetAsync(uri);
                    }
                    else
                    {
                        response = await client.SendAsync(new HttpRequestMessage(httpMethod, invokingUri)
                            {
                                Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8,
                                    JsonContentType)
                            }
                        );
                    }

                    var respBody = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(respBody))
                    {
                        return JsonConvert.DeserializeObject<T>(respBody);
                    }
                }
            }
            catch (Exception e)
            {
                return default(T);
            }

            return default(T);
        }
    }
}
