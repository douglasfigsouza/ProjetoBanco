using System.Collections.Generic;
using System.Net.Http;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Operacoes;

namespace ProjetoBanco.Application.Interfaces
{
    public interface IOperacaoesRealizadasAppService
    {
        HttpResponseMessage Deposito(OperacoesRealizadas operacaoRealizada);
        HttpResponseMessage Saque(OperacoesRealizadas operacaoRealizada);
        HttpResponseMessage Transferencia(List<OperacoesRealizadas>operacoesRealizadases);
        IEnumerable<Estorno> GetAllOperacoesPorContaParaEstorno(string conta, string senha, int agencia);
        Estorno GetOpRealizadaEstornoById(int Id);
        string ConfirmEstorno(int id);
        IEnumerable<Estorno> GetAllOperacoesEstorno();
    }
}
