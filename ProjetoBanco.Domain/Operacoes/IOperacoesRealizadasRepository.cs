using ProjetoBanco.Domain.Entities;
using System.Collections.Generic;

namespace ProjetoBanco.Domain.Operacoes
{
    public interface IOperacoesRealizadasRepository
    {
        void Deposito(OperacoesRealizadas operacaoRealizada);
        void Saque(OperacoesRealizadas operacaoRealizada);
        void Transferencia(List<OperacoesRealizadas>operacoes);
        IEnumerable<Estorno> GetAllOperacoesPorContaParaEstorno(string conta, string senha, int agencia);
        IEnumerable<Estorno> GetAllOperacoesEstorno();
        string ConfirmEstorno(int id);
    }
}
