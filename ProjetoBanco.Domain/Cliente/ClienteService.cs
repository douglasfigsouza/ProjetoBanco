using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Domain.Clientes
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private Notifications _notifications;

        public ClienteService(IClienteRepository clienteRepository, Notifications notifications)
        {
            _clienteRepository = clienteRepository;
            _notifications = notifications;
        }

        public ClienteDto GetByClienteId(int id)
        {
            var cliente = new ClienteDto();
            cliente = _clienteRepository.GetByClienteId(id);
            if (cliente.nome == "")
            {
                _notifications.Notificacoes.Add("Cliente não encontrado!");
            }
            return cliente;
        }

        public ClienteDto GetClienteByCpf(string cpf)
        {
            var cliente = new ClienteDto();
            cliente = _clienteRepository.GetClienteByCpf(cpf);
            if (cliente.nome == "")
            {
                _notifications.Notificacoes.Add("Cliente não encontrado!");
            }
            return cliente;
        }
    }
}
