

using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Interfaces.IRepositories;
using ProjetoBanco.Domain.Interfaces.IServices;

namespace ProjetoBanco.Domain.Services
{
    public class OperacoesRealizadasServiceDomain:IOperacoeRealizadaServiceDomain
    {
        private readonly IOperacoesRealizadasRepositoryDomain _operacoesRealizadasRepositoryDomain;

        public OperacoesRealizadasServiceDomain(IOperacoesRealizadasRepositoryDomain operacoesRealizadasRepositoryDomain)
        {
            _operacoesRealizadasRepositoryDomain = operacoesRealizadasRepositoryDomain;
        }
        public void AddOpRealizada(OperacaoRealizada operacaoRealizada,int op)
        {
           _operacoesRealizadasRepositoryDomain.AddOpRealizada(operacaoRealizada,op);
        }

        public void Dispose()
        {
            _operacoesRealizadasRepositoryDomain.Dispose();
        }
    }
}
