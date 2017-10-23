using System.Web.Http.Dependencies;
using SimpleInjector.Integration.WebApi;
using Web_Api.App_Start;

namespace Web_Api
{
    public class WebApiApplication : WebApiConfig
    {
        private static readonly IDependencyResolver _depResolver = new SimpleInjectorWebApiDependencyResolver(SimpleInjectorContainer.RegisterServices());
        public WebApiApplication() : base(_depResolver)
        {
            
        }
    }
}
