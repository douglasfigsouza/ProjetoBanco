using System.Collections.Generic;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Operacoes;

namespace ProjetoBanco.Application.Interfaces
{
    public interface IOperacaoesRealizadasAppService
    {
        void Deposito(OperacoesRealizadas operacaoRealizada, int op);
        string Saque(OperacoesRealizadas operacaoRealizada, int op);
        string Transferencia(OperacoesRealizadas opConta1, OperacoesRealizadas opConta2);
        IEnumerable<Estorno> GetAllOperacoesPorContaParaEstorno(string conta, string senha, int agencia);
        Estorno GetOpRealizadaEstornoById(int Id);
        string ConfirmEstorno(int id);
        IEnumerable<Estorno> GetAllOperacoesEstorno();
        void Dispose();
    }
}
