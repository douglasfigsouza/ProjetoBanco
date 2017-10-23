using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dependencies;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Web_Api
{
    public abstract class WebApiConfig:HttpApplication
    {
        private readonly IDependencyResolver _depResolver;

        protected WebApiConfig(IDependencyResolver depResolver)
        {
            _depResolver = depResolver;
        }

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(config =>
            {
                // Web API configuration and services

                // Web API routes
                config.MapHttpAttributeRoutes();

                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{action}"
                );

                config.Formatters.Clear();
                config.Formatters.Add(new JsonMediaTypeFormatter
                {
                    SerializerSettings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                        ContractResolver = new DefaultContractResolver
                        {
                            IgnoreSerializableAttribute = true
                        }
                    }

                });

                config.DependencyResolver = _depResolver;
            });
        }
    }
}
