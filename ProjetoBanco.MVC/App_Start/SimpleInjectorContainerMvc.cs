using ProjetoBanco.Application;
using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Agencias;
using ProjetoBanco.Domain.Bancos;
using ProjetoBanco.Domain.Cidades;
using ProjetoBanco.Domain.Clientes;
using ProjetoBanco.Domain.Contas;
using ProjetoBanco.Domain.Estados;
using ProjetoBanco.Domain.Operacoes;
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

            container.Register<IAgenciaRepository, AgenciaRepository>();

            container.Register<IBancoAppService, BancoAppService>();

            container.Register<IBancoRepository, BancoRepository>();

            container.Register<ICidadesAppService, CidadeAppService>();

            container.Register<ICidadeRepository, CidadeRepository>();

            container.Register<IClienteAppService, ClienteAppService>();

            container.Register<IClienteRepository, ClientesRepository>();

            container.Register<IContaClienteAppService, ContaClienteAppService>();

            container.Register<IContaClienteRepository, ContaClienteRepository>();

            container.Register<IEstadoAppService, EstadoAppService>();

            container.Register<IEstadoRepository, EstadoRepository>();

            container.Register<IOperacoesRepository, OperacoesRepository>();

            container.Register<IOperacoesAppService, OperacoesAppService>();

            container.Register<IOperacaoesRealizadasAppService, OperacoesRealizadasAppService>();

            container.Register<IOperacoesRealizadasRepository, OperacaoRealizadaRepository>();

            container.Register<IUsuarioRepository, UsuarioRepository>();

            container.Register<IUsuarioAppService, UsuarioAppService>();

            container.Verify();

            return container;
        }
    }
}