
using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Application.Interfaces
{
    public interface IOperacaoesRealizadasAppService
    {
        void AddOpRealizada(OperacaoRealizada operacaoRealizada, int op);
        void Dispose();
    }
}
