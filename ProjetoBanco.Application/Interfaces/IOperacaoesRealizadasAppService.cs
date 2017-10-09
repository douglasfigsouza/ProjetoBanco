
using System.Collections.Generic;
using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Application.Interfaces
{
    public interface IOperacaoesRealizadasAppService
    {
        void Deposito(OperacaoRealizada operacaoRealizada, int op);
        string Saque(OperacaoRealizada operacaoRealizada, int op);
        void Dispose();
    }
}
