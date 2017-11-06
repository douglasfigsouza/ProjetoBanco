using ProjetoBanco.Application;
using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Agencia;
using ProjetoBanco.Domain.Agencias;
using ProjetoBanco.Domain.Banco;
using ProjetoBanco.Domain.Bancos;
using ProjetoBanco.Domain.Cidade;
using ProjetoBanco.Domain.Cidades;
using ProjetoBanco.Domain.Clientes;
using ProjetoBanco.Domain.Conta;
using ProjetoBanco.Domain.Contas;
using ProjetoBanco.Domain.Estados;
using ProjetoBanco.Domain.Operacao;
using ProjetoBanco.Domain.Operacão;
using ProjetoBanco.Domain.Operacoes;
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
            container.Register<IAgenciaService, AgenciaService>();

            container.Register<IBancoAppService, BancoAppService>();
            container.Register<IBancoRepository, BancoRepository>();
            container.Register<IBancoService, BancoService>();

            container.Register<ICidadesAppService, CidadeAppService>();
            container.Register<ICidadeRepository, CidadeRepository>();
            container.Register<ICidadeService, CidadeService>();

            container.Register<IClienteAppService, ClienteAppService>();
            container.Register<IClienteRepository, ClientesRepository>();
            container.Register<IClienteService, ClienteService>();

            container.Register<IContaClienteAppService, ContaClienteAppService>();
            container.Register<IContaClienteRepository, ContaClienteRepository>();
            container.Register<IContaClienteService, ContaClienteService>();

            container.Register<IEstadoAppService, EstadoAppService>();
            container.Register<IEstadoRepository, EstadoRepository>();
            container.Register<IEstadoService, EstadoService>();

            container.Register<IOperacoesRepository, OperacoesRepository>();
            container.Register<IOperacoesAppService, OperacoesAppService>();
            container.Register<IOperacaoService, OperacoesService>();

            container.Register<IOperacaoesRealizadasAppService, OperacoesRealizadasAppService>();
            container.Register<IOperacoesRealizadasRepository, OperacaoRealizadaRepository>();
            container.Register<IOperacaoRealizadaService, OperacaoRealizadaService>();

            container.Register<IUsuarioAppService, UsuarioAppService>();

            container.Verify();

            return container;
        }
    }
}