using ProjetoBanco.Domain.Entities;
using System;
using System.Collections.Generic;

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

        public void AddCliente(ClienteDto cliente)
        {
            try
            {
                _clienteRepository.AddCliente(cliente);
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível cadastrar cliente! Erro {e.Message}");
            }
        }

        public IEnumerable<ClienteDto> GetAllClientes(int op)
        {
            IEnumerable<ClienteDto> clientes = null;
            try
            {
                clientes = new List<ClienteDto>(_clienteRepository.GetAllClientes(op));
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível buscar clientes! Erro {e.Message}");
            }
            return clientes;
        }

        public ClienteDto GetByClienteId(int id)
        {
            var cliente = new ClienteDto();
            try
            {
                cliente = _clienteRepository.GetByClienteId(id);
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível buscar cliente! Erro {e.Message}");
            }
            if (cliente.nome == "")
            {
                _notifications.Notificacoes.Add("Cliente não encontrado!");
            }
            return cliente;
        }

        public ClienteDto GetClienteByCpf(string cpf)
        {
            var cliente = new ClienteDto();
            try
            {
                cliente = _clienteRepository.GetClienteByCpf(cpf);
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível buscar cliente! Erro {e.Message}");
            }
            if (cliente.nome == "")
            {
                _notifications.Notificacoes.Add("Cliente não encontrado!");
            }
            return cliente;
        }

        public void UpdateClientes(ClienteDto cliente)
        {
            try
            {
                _clienteRepository.UpdateClientes(cliente);
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível atualizar cliente! Erro {e.Message}");
            }
        }
    }
}
