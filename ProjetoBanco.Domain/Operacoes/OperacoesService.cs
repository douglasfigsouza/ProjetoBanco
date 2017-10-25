using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Domain.Operacoes
{
    public class OperacoesService:IOperacaoService
    {
        private readonly IOperacoesRepository _repository;
        private readonly Notifications _notifications;
        private Transacao transact;
        public OperacoesService(IOperacoesRepository repository, Notifications notifications)
        {
            _repository = repository;
            _notifications = notifications;
        }
        public void AddOperacao(Domain.Operacoes.Operacoes op)
        {
            _repository.AddOperacao(op);
        }


        public Transacao VerificaDadosTransacao(Transacao transacao)
        {
            return _repository.VerificaDadosTransacao(transacao);
        }
        public Transacao VerificaDadosTransferencia(Transacao transacao)
        {
           return _repository.VerificaDadosTransferencia(transacao);
        }


        public Transacao ConsultaSaldo(Transacao transacao)
        {
            return _repository.ConsultaSaldo(transacao);
        }


    }
}
