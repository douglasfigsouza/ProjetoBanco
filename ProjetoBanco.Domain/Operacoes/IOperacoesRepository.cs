namespace ProjetoBanco.Domain.Operacoes
{
    public interface IOperacoesRepository
    {
        void AddOperacao(Domain.Operacoes.Operacoes op);
        Transacao VerificaDadosTransacao(Transacao transacao);
        Transacao VerificaDadosTransferencia(Transacao transacao);
        Transacao ConsultaSaldo(Transacao transacao);
    }
}