using System.Collections.Generic;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Operacoes;

namespace ProjetoBanco.Domain.Interfaces.IRepositories
{
    public interface IOperacoesRealizadasRepository
    {
        void Deposito(OperacoesRealizadas operacaoRealizada, int op);
        int Saque(OperacoesRealizadas operacaoRealizada, int op);
        int Transferencia(OperacoesRealizadas opConta1, OperacoesRealizadas opConta2);
        IEnumerable<Estorno> GetAllOperacoesPorContaParaEstorno(string conta, string senha, int agencia);
        IEnumerable<Estorno> GetAllOperacoesEstorno();
        string ConfirmEstorno(int id);
        void Dispose();
    }
}
