using ProjetoBanco.Domain.Operacoes.Dto;
using System.Collections.Generic;

namespace ProjetoBanco.Domain.Operacoes
{
    public interface IOperacoeRealizadaService
    {
        void Deposito(OperacoesRealizadas operacaoRealizada);
        void Saque(OperacoesRealizadas operacaoRealizada);
        void Transferencia(List<OperacoesRealizadas>operacoes);
        IEnumerable<Estorno> GetAllOperacoesPorContaParaEstorno(DadosGetOpReal dadosGetOp);
        IEnumerable<Estorno> GetAllOperacoesEstorno();
        void ConfirmEstorno(int id);
    }
}
