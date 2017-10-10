using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Domain.Interfaces.IRepositories
{
    public interface IOperacoesRepositoryDomain
    {
        void AddOperacao(Operacoes op);
        Operacoes GetOperacaoById(int id);
        IEnumerable<Operacoes> GetAllOperacoes();
        void UpdateOperacao(Operacoes op);
        void RemoveOperacao(Operacoes op);
        Transacao VerificaDadosDeposito(Transacao transacao);
        //List<Transacao> VerificaDadosTransferencia(Transacao transacaoConta1,Transacao transacaoConta2);
        decimal ConsultaSaldo(Transacao transacao);
        void Dispose();
    }
}
