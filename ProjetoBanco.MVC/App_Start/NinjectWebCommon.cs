using ProjetoBanco.Domain.Interfaces.IRepositories;
using ProjetoBanco.Domain.Interfaces.IServices;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ProjetoBanco.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(ProjetoBanco.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace ProjetoBanco.MVC.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Application.Interfaces;
    using Domain.Services;
    using Application;
    using Infra.Data.Repositories;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IAgenciaAppService>().To<AgenciaAppService>();
            kernel.Bind<IAgenciaServiceDomain>().To<AgenciaServiceDomain>();
            kernel.Bind<IAgenciaRepositoryDomain>().To<AgenciaRepository>();

            kernel.Bind<IBancoAppService>().To<BancoAppService>();
            kernel.Bind<IBancoServiceDomain>().To<BancoServiceDomain>();
            kernel.Bind<IBancoRepositoryDomain>().To<BancoRepository>();

            kernel.Bind<ICidadesAppService>().To<CidadeAppService>();
            kernel.Bind<ICidadeServiceDomain>().To<CidadeServiceDomain>();
            kernel.Bind<ICidadeRepositoryDomain>().To<CidadeRepository>();

            kernel.Bind<IClienteAppService>().To<ClienteAppService>();
            kernel.Bind<IClienteServiceDomain>().To<ClienteService>();
            kernel.Bind<IClienteRepositoryDomain>().To<ClientesRepository>();

            kernel.Bind<IEstadoAppService>().To<EstadoAppService>();
            kernel.Bind<IEstadoServiceDomain>().To<EstadoServiceDomain>();
            kernel.Bind<IEstadoRepositoryDomain>().To<EstadoRepository>();


            kernel.Bind<IOperacoesAppService>().To<OperacoesAppService>();
            kernel.Bind<IOperacaoServiceDomain>().To<OpercoesServiceDomain>();
            kernel.Bind<IOperacoesRepositoryDomain>().To<OperacoesRepository>();

            kernel.Bind<IUsuarioAppService>().To<UsuarioAppService>();
            kernel.Bind<IUsuariosServiceDomain>().To<UsuarioSeviceDomain>();
            kernel.Bind<IUsuarioRepositoryDomain>().To<UsuarioRepository>();
        }       
    }
}
