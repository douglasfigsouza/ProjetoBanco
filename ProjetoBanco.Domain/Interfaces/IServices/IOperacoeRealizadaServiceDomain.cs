using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Domain.Interfaces.IServices
{
    public interface IOperacoeRealizadaServiceDomain
    {
        void Deposito(OperacaoRealizada operacaoRealizada, int op);
        string Saque(OperacaoRealizada operacaoRealizada, int op);
        int Transferencia(OperacaoRealizada opConta1, OperacaoRealizada opConta2);
        IEnumerable<Estorno> GetAllOperacoesPorContaParaEstorno(string conta, string senha, int agencia);
        IEnumerable<Estorno> GetAllOperacoesEstorno();
        void ConfirmEstorno(int id);
        void Dispose();
    }
}
