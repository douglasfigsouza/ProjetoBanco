using ProjetoBanco.Domain.Interfaces.IRepositories;
using ProjetoBanco.Domain.Interfaces.IServices;
using ProjetoBanco.Domain.Services;
using ProjetoBanco.Infra.Data.Repositories;
using SimpleInjector;

namespace Web_Api.App_Start
{
    public static class SimpleInjectorContainer
    {
        public static Container RegisterServices()
        {
            var container = new Container();

            //container.Register<IOperacoesRepositoryDomain, OperacoesRepository>();
            //container.Register<IOperacaoServiceDomain, OpercoesServiceDomain>();

            container.Register<IOlaRepository, OlaRepository>();
            container.Register<IOperacoesRepository, OperacoesRepository>();

            container.Verify();

            return container;

        }
    }
}