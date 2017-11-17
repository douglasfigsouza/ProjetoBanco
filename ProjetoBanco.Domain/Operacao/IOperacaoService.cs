using ProjetoBanco.Domain.Operacoes.Dto;

namespace ProjetoBanco.Domain.Operacao
{
    public interface IOperacaoService
    {
        Transacao VerificaDadosTransacao(Transacao transacao);
        Transacao VerificaDadosTransferencia(Transacao transacao);
        Transacao ConsultaSaldo(Transacao transacao);
    }
}
