using ProjetoBanco.Domain.Operacoes.Dto;
using System.Collections.Generic;
using System.Net.Http;

namespace ProjetoBanco.Application.Interfaces
{
    public interface IOperacaoesRealizadasAppService
    {
        HttpResponseMessage Deposito(OperacoesRealizadas operacaoRealizada);
        HttpResponseMessage Saque(OperacoesRealizadas operacaoRealizada);
        HttpResponseMessage Transferencia(List<OperacoesRealizadas> operacoesRealizadases);
        HttpResponseMessage GetAllOperacoesPorContaParaEstorno(DadosGetOpReal dadosGetOpReal);
        HttpResponseMessage GetOpRealizadaEstornoById(int Id);
        HttpResponseMessage ConfirmEstorno(Estorno estorno);
        HttpResponseMessage GetAllOperacoesEstorno();
        HttpResponseMessage ExtratoPorData(DadosGetOpReal dadosGetOp);
    }
}
