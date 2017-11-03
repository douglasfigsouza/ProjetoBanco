using ProjetoBanco.Domain.Agencias;
using ProjetoBanco.Domain.Bancos;
using ProjetoBanco.Domain.Cidades;
using ProjetoBanco.Domain.Clientes;
using ProjetoBanco.Domain.Contas;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Estados;
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

            container.Register<IBancoRepository, BancoRepository>();

            container.Register<ICidadeRepository, CidadeRepository>();

            container.Register<IClienteRepository, ClientesRepository>();

  
            container.Register<IContaClienteRepository, ContaClienteRepository>();

            container.Register<IEstadoRepository, EstadoRepository>();

            container.Register<IOperacoesRepository, OperacoesRepository>();

            container.Register<IOperacoesRealizadasRepository, OperacaoRealizadaRepository>();

            container.Register<IUsuarioRepository, UsuarioRepository>();

            container.Register<Notifications>(Lifestyle.Scoped);

            container.Register<Conexao>(Lifestyle.Scoped);

            container.Verify();

            return container;

        }
    }
}