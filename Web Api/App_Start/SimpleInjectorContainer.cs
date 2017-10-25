using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Interfaces.IRepositories;
using ProjetoBanco.Domain.Interfaces.IServices;
using ProjetoBanco.Domain.Operacoes;
using ProjetoBanco.Domain.Services;
using ProjetoBanco.Domain.Usuarios;
using ProjetoBanco.Infra.Data.Repositories;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace Web_Api
{
    public static class SimpleInjectorContainer
    {
        public static Container RegisterServices()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
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
            container.Register<IOperacaoService, OperacoesService>();

            container.Register<IOperacoeRealizadaService, OperacoesRealizadasService>();
            container.Register<IOperacoesRealizadasRepository, OperacaoRealizadaRepository>();

            container.Register<IUsuarioRepository, UsuarioRepository>();
            container.Register<IUsuariosService, UsuarioSeviceDomain>();

            container.Register<Notifications>(Lifestyle.Scoped);

            container.Verify();

            return container;

        }
    }
}