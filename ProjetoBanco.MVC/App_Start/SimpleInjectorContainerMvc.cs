using ProjetoBanco.Application;
using ProjetoBanco.Application.Interfaces;
using SimpleInjector;
namespace ProjetoBanco.MVC.App_Start
{
    public static class SimpleInjectorContainerMvc
    {
        public static Container RegisterServices()
        {

            var container = new Container();

            container.Register<IAgenciaAppService, AgenciaAppService>();

            container.Register<IBancoAppService, BancoAppService>();

            container.Register<ICidadesAppService, CidadeAppService>();

            container.Register<IClienteAppService, ClienteAppService>();

            container.Register<IContaClienteAppService, ContaClienteAppService>();

            container.Register<IEstadoAppService, EstadoAppService>();

            container.Register<IOperacoesAppService, OperacoesAppService>();

            container.Register<IOperacaoesRealizadasAppService, OperacoesRealizadasAppService>();

            container.Register<IUsuarioAppService, UsuarioAppService>();

            container.Verify();

            return container;
        }
    }
}