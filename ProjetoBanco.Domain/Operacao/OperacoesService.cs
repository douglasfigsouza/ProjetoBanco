using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Operacao;
using ProjetoBanco.Domain.Operacoes;
using ProjetoBanco.Domain.Operacoes.Dto;

namespace ProjetoBanco.Domain.Operacão
{
    public class OperacoesService : IOperacaoService
    {
        private readonly IOperacoesRepository _operacoesRepository;
        private Notifications _notifications;

        public OperacoesService(IOperacoesRepository operacoesRepository, Notifications notifications)
        {
            _operacoesRepository = operacoesRepository;
            _notifications = notifications;
        }
        public Transacao VerificaDadosTransacao(Transacao transacao)
        {
            var transact = new Transacao();
            transact = _operacoesRepository.VerificaDadosTransacao(transacao);
            if (transact.nome == null)
            {
                _notifications.Notificacoes.Add("Cliente inexistente ou você não é o proprietario da conta!");
            }
            return transact;
        }

        public Transacao VerificaDadosTransferencia(Transacao transacao)
        {
            var transact = new Transacao();
            transact = _operacoesRepository.VerificaDadosTransferencia(transacao);
            if (transact.conta == "")
            {
                _notifications.Notificacoes.Add("Conta para a transferência não existe!");
            }
            return transact;
        }

        public Transacao ConsultaSaldo(Transacao transacao)
        {
            var transact = new Transacao();
            transact = _operacoesRepository.ConsultaSaldo(transacao);
            if (transact.nome == null)
            {
                _notifications.Notificacoes.Add("Conta não encontrada!");
            }
            return transact;
        }
    }
}
