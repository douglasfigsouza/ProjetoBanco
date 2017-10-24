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

            container.Register<IAgenciaServiceDomain, AgenciaServiceDomain>();
            container.Register<IAgenciaRepositoryDomain, AgenciaRepository>();

            container.Register<IBancoServiceDomain, BancoServiceDomain>();
            container.Register<IBancoRepositoryDomain, BancoRepository>();


            container.Register<ICidadeServiceDomain, CidadeServiceDomain>();
            container.Register<ICidadeRepositoryDomain, CidadeRepository>();


            container.Register<IClienteServiceDomain, ClienteService>();
            container.Register<IClienteRepositoryDomain, ClientesRepository>();

            container.Register<IContaClienteServiceDomain, ContaClienteServiceDomain>();
            container.Register<IContaClienteRepositoryDomain, ContaClienteRepository>();

            container.Register<IEstadoServiceDomain, EstadoServiceDomain>();
            container.Register<IEstadoRepositoryDomain, EstadoRepository>();


            container.Register<IOperacoesRepository, OperacoesRepository>();
            container.Register<IOperacaoServiceDomain, OpercoesServiceDomain>();

            container.Register<IOperacoeRealizadaServiceDomain, OperacoesRealizadasServiceDomain>();
            container.Register<IOperacoesRealizadasRepositoryDomain, OperacaoRealizadaRepository>();

            container.Register<IUsuarioRepositoryDomain, UsuarioRepository>();
            container.Register<IUsuariosServiceDomain, UsuarioSeviceDomain>();

            container.Verify();

            return container;

        }
    }
}