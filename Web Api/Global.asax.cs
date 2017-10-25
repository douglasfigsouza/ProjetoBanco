using SimpleInjector.Integration.WebApi;
using System.Web.Http.Dependencies;

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
