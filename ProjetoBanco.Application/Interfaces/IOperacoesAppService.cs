using ProjetoBanco.Domain.Operacoes.Dto;
using System.Net.Http;

namespace ProjetoBanco.Application.Interfaces
{
    public interface IOperacoesAppService
    {
        HttpResponseMessage AddOperacao(Operacoes op);
        HttpResponseMessage VerificaDadosTransacao(Transacao transacao);
        HttpResponseMessage VerificaDadosTransferencia(Transacao transacao);
        HttpResponseMessage ConsultaSaldo(Transacao transacao);
    }
}
