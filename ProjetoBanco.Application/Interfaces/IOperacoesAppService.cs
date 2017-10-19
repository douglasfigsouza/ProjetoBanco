using System.Collections.Generic;
using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Application.Interfaces
{
    public interface IOperacoesAppService
    {
        string AddOperacao(Operacoes op);
        Operacoes GetOperacaoById(int id);
        IEnumerable<Operacoes> GetAllOperacoes();
        void UpdateOperacao(Operacoes op);
        void RemoveOperacao(Operacoes op);
        Transacao VerificaDadosTransacao(Transacao transacao, int op);
        Transacao VerificaDadosTransferencia(Transacao transacao);
        decimal ConsultaSaldo(Transacao transacao);
        void Dispose();
    }
}
