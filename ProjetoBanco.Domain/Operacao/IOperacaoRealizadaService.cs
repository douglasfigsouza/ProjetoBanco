using ProjetoBanco.Domain.Operacoes.Dto;
using System.Collections.Generic;

namespace ProjetoBanco.Domain.Operacão
{
    public interface IOperacaoRealizadaService
    {
        void Deposito(OperacoesRealizadas operacaoRealizada);
        void Saque(OperacoesRealizadas operacaoRealizada);
        void Transferencia(List<OperacoesRealizadas> operacoes);
        List<Estorno> GetAllOperacoesPorContaParaEstorno(DadosGetOpReal dadosGetOp);
        IEnumerable<Estorno> GetAllOperacoesEstorno();
        Estorno GetOpRealizadaEstornoById(int id);
        void ConfirmEstorno(int id);
    }
}
