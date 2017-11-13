using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Routing;

namespace Web_Api.Utilitarios
{
    public static class HttpClientConf
    {
        public static HttpClient HttpClientConfig(string controller)
        {

            var HttpClientConf = new System.Net.Http.HttpClient();
            HttpClientConf.BaseAddress = new Uri("http://localhost:36528/api/" + controller + "/");
            HttpClientConf.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return HttpClientConf;
        }

        public static Uri HttpClientConfigGet(string url, object parameters)
        {
            var client = new HttpClient();
            var builder = new UriBuilder("http://localhost:36528/api/"+url);
            var p = string.Empty;
            foreach (var parameter in new RouteValueDictionary(parameters))
                p += $"{parameter.Key}={parameter.Value}&";

            builder.Query = p;
            return builder.Uri;
        }
    }
}