namespace ProjetoBanco.Domain.Operacoes
{
    public interface IOperacaoService
    {
        void AddOperacao(Domain.Operacoes.Operacoes op);
        Transacao VerificaDadosTransacao(Transacao transacao);
        Transacao VerificaDadosTransferencia(Transacao transacao);
        Transacao ConsultaSaldo(Transacao transacao);

    }
}
