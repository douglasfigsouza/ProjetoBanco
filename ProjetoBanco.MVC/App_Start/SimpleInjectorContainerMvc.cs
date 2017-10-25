using ProjetoBanco.Application;
using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Interfaces.IRepositories;
using ProjetoBanco.Domain.Interfaces.IServices;
using ProjetoBanco.Domain.Operacoes;
using ProjetoBanco.Domain.Services;
using ProjetoBanco.Domain.Usuarios;
using ProjetoBanco.Infra.Data.Repositories;
using SimpleInjector;

namespace ProjetoBanco.MVC.App_Start
{
    public static class SimpleInjectorContainerMvc
    {
        public static Container RegisterServices()
        {

            var container = new Container();

            container.Register<IAgenciaAppService, AgenciaAppService>();
            container.Register<IAgenciaServiceDomain, AgenciaServiceDomain>();
            container.Register<IAgenciaRepositoryDomain, AgenciaRepository>();

            container.Register<IBancoAppService, BancoAppService>();
            container.Register<IBancoServiceDomain, BancoServiceDomain>();
            container.Register<IBancoRepositoryDomain, BancoRepository>();

            container.Register<ICidadesAppService, CidadeAppService>();
            container.Register<ICidadeServiceDomain, CidadeServiceDomain>();
            container.Register<ICidadeRepositoryDomain, CidadeRepository>();

            container.Register<IClienteAppService, ClienteAppService>();
            container.Register<IClienteServiceDomain, ClienteService>();
            container.Register<IClienteRepositoryDomain, ClientesRepository>();

            container.Register<IContaClienteAppService, ContaClienteAppService>();
            container.Register<IContaClienteServiceDomain, ContaClienteServiceDomain>();
            container.Register<IContaClienteRepositoryDomain, ContaClienteRepository>();

            container.Register<IEstadoAppService, EstadoAppService>();
            container.Register<IEstadoServiceDomain, EstadoServiceDomain>();
            container.Register<IEstadoRepositoryDomain, EstadoRepository>();


            container.Register<IOperacoesRepository, OperacoesRepository>();
            container.Register<IOperacoesAppService, OperacoesAppService>();
            container.Register<IOperacaoService, OperacoesService>();

            container.Register<IOperacaoesRealizadasAppService, OperacoesRealizadasAppService>();
            container.Register<IOperacoeRealizadaService, OperacoesRealizadasService>();
            container.Register<IOperacoesRealizadasRepository, OperacaoRealizadaRepository>();

            container.Register<IUsuarioRepository, UsuarioRepository>();
            container.Register<IUsuarioAppService, UsuarioAppService>();
            container.Register<IUsuariosService, UsuarioSeviceDomain>();

            container.Verify();

            return container;
        }
    }
}