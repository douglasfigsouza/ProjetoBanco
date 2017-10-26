using ProjetoBanco.Domain.Operacoes.Dto;

namespace ProjetoBanco.Domain.Operacoes
{
    public interface IOperacaoService
    {
        void AddOperacao(Dto.Operacoes op);
        Transacao VerificaDadosTransacao(Transacao transacao);
        Transacao VerificaDadosTransferencia(Transacao transacao);
        Transacao ConsultaSaldo(Transacao transacao);

    }
}
