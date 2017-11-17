using ProjetoBanco.Domain.Contas;
using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Domain.Conta
{
    public class ContaClienteService : IContaClienteService
    {
        private readonly IContaClienteRepository _contaClienteRepository;
        private Notifications _notifications;

        public ContaClienteService(IContaClienteRepository contaClienteRepository, Notifications notifications)
        {
            _contaClienteRepository = contaClienteRepository;
            _notifications = notifications;
        }
        public ContaClienteAlteracao GetConta(int contaId)
        {
            var conta = new ContaClienteAlteracao();
            conta = _contaClienteRepository.GetConta(contaId);
            if (conta == null)
            {
                _notifications.Notificacoes.Add("Conta não encontrada!");
            }
            return conta;
        }
    }
}
