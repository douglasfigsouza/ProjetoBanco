using System;
using System.Net.Http.Headers;

namespace Web_Api.Utilitarios
{
    public static class HttpClientConf
    {
        public static System.Net.Http.HttpClient HttpClientConfig(string controller)
        {

            var HttpClientConf = new System.Net.Http.HttpClient();
            HttpClientConf.BaseAddress = new Uri("http://localhost:36528/api/" + controller + "/");
            HttpClientConf.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return HttpClientConf;
        }

    }
}