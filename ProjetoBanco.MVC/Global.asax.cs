﻿using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ProjetoBanco.MVC.App_Start;
using SimpleInjector.Integration.Web.Mvc;
using Web_Api.App_Start;


namespace ProjetoBanco.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(SimpleInjectorContainerMvc.RegisterServices()));
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
