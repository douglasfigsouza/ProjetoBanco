using ProjetoBanco.Domain.Operacoes.Dto;
using System.Collections.Generic;

namespace ProjetoBanco.Domain.Operacoes
{
    public interface IOperacoesRealizadasRepository
    {
        void Deposito(OperacoesRealizadas operacaoRealizada);
        int Saque(OperacoesRealizadas operacaoRealizada);
        int Transferencia(List<OperacoesRealizadas>operacoes);
        List<Estorno> GetAllOperacoesPorContaParaEstorno(DadosGetOpReal dadosGetOp);
        IEnumerable<Estorno> GetAllOperacoesEstorno();
        Estorno GetOpRealizadaEstornoById(int id);
        List<Estorno> GetExtratoPorData(DadosGetOpReal dadosGetOp);
        void ConfirmEstorno(int id);
    }
}
