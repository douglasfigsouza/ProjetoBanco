
using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Application.Interfaces
{
    public interface IOperacaoesRealizadasAppService
    {
        void AddOpRealizada(OperacaoRealizada operacaoRealizada, Operacoes op);
        void Dispose();
    }
}
