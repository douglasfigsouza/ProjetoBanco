using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Domain.Interfaces.IServices
{
    public interface IOperacaoServiceDomain
    {
        void AddOperacao(Operacoes op);
        Operacoes GetOperacaoById(int id);
        IEnumerable<Operacoes> GetAllOperacoes();
        void UpdateOperacao(Operacoes op);
        void RemoveOperacao(Operacoes op);
        Transacao VerificaDadosDeposito(Transacao transacao);
        List<Transacao> VerificaDadosTransferencia(List<Transacao> transacoes);
        decimal ConsultaSaldo(Transacao transacao);
        void Dispose();

    }
}
