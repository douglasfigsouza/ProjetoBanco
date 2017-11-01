using ProjetoBanco.Domain.Agencias;
using ProjetoBanco.Domain.Bancos;
using ProjetoBanco.Domain.Cidades;
using ProjetoBanco.Domain.Clientes;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Estados;
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
            //container.Register<IAgenciaService, AgenciaService>();
            container.Register<IAgenciaRepository, AgenciaRepository>();

            container.Register<IBancoService, BancoService>();
            container.Register<IBancoRepository, BancoRepository>();


            //container.Register<ICidadeServiceDomain, CidadeServiceDomain>();
            container.Register<ICidadeRepository, CidadeRepository>();


            container.Register<IClienteServiceDomain, ClienteService>();
            container.Register<IClienteRepository, ClientesRepository>();

            container.Register<IContaClienteServiceDomain, ContaClienteServiceDomain>();
            container.Register<IContaClienteRepositoryDomain, ContaClienteRepository>();

            container.Register<IEstadoService, EstadoService>();
            container.Register<IEstadoRepository, EstadoRepository>();


            container.Register<IOperacoesRepository, OperacoesRepository>();
            container.Register<IOperacaoService, OperacoesService>();

            container.Register<IOperacoeRealizadaService, OperacoesRealizadasService>();
            container.Register<IOperacoesRealizadasRepository, OperacaoRealizadaRepository>();

            container.Register<IUsuarioRepository, UsuarioRepository>();
            //container.Register<IUsuariosService, UsuarioSeviceDomain>();

            container.Register<Notifications>(Lifestyle.Scoped);

            container.Register<Conexao>(Lifestyle.Scoped);

            container.Verify();

            return container;

        }
    }
}