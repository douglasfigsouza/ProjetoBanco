
using System.Collections.Generic;
using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Application.Interfaces
{
    public interface IOperacaoesRealizadasAppService
    {
        void Deposito(OperacaoRealizada operacaoRealizada, int op);
        string Saque(OperacaoRealizada operacaoRealizada, int op);
        string Transferencia(OperacaoRealizada opConta1, OperacaoRealizada opConta2);
        IEnumerable<Estorno> GetAllOperacoesPorContaParaEstorno(string conta, string senha, int agencia);
        Estorno GetOpRealizadaEstornoById(int Id);
        string ConfirmEstorno(int id);
        IEnumerable<Estorno> GetAllOperacoesEstorno();
        void Dispose();
    }
}
