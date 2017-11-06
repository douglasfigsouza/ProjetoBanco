using ProjetoBanco.Domain.Agencia;
using ProjetoBanco.Domain.Agencias;
using ProjetoBanco.Domain.Banco;
using ProjetoBanco.Domain.Bancos;
using ProjetoBanco.Domain.Cidade;
using ProjetoBanco.Domain.Cidades;
using ProjetoBanco.Domain.Clientes;
using ProjetoBanco.Domain.Conta;
using ProjetoBanco.Domain.Contas;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Estados;
using ProjetoBanco.Domain.Operacao;
using ProjetoBanco.Domain.Operacão;
using ProjetoBanco.Domain.Operacoes;
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

            container.Register<IAgenciaRepository, AgenciaRepository>();
            container.Register<IAgenciaService, AgenciaService>();

            container.Register<IBancoRepository, BancoRepository>();
            container.Register<IBancoService, BancoService>();

            container.Register<ICidadeRepository, CidadeRepository>();
            container.Register<ICidadeService, CidadeService>();

            container.Register<IClienteRepository, ClientesRepository>();
            container.Register<IClienteService, ClienteService>();

            container.Register<IContaClienteRepository, ContaClienteRepository>();
            container.Register<IContaClienteService, ContaClienteService>();

            container.Register<IEstadoRepository, EstadoRepository>();
            container.Register<IEstadoService, EstadoService>();

            container.Register<IOperacoesRepository, OperacoesRepository>();
            container.Register<IOperacaoService,OperacoesService>();

            container.Register<IOperacoesRealizadasRepository, OperacaoRealizadaRepository>();
            container.Register<IOperacaoRealizadaService, OperacaoRealizadaService>();

            container.Register<IUsuarioRepository, UsuarioRepository>();
            container.Register<IUsuarioService, UsuarioService>();

            container.Register<Notifications>(Lifestyle.Scoped);

            container.Register<Conexao>(Lifestyle.Scoped);

            container.Verify();

            return container;

        }
    }
}