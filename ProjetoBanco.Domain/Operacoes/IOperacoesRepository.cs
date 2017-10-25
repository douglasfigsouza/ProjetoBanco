using ProjetoBanco.Domain.Operacoes;

namespace ProjetoBanco.Domain.Interfaces.IRepositories
{
    public interface IOperacoesRepository
    {
        void AddOperacao(Operacoes.Operacoes op);
        Transacao VerificaDadosTransacao(Transacao transacao);
        Transacao VerificaDadosTransferencia(Transacao transacao);
        Transacao ConsultaSaldo(Transacao transacao);
    }
}