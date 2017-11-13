using ProjetoBanco.Domain.Contas;
using ProjetoBanco.Domain.Entities;
using System;
using System.Collections.Generic;

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

        public void AddContaCliente(Contas.Conta conta)
        {
            try
            {
                _contaClienteRepository.AddContaCliente(conta);
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível cadastrar conta! Erro {e.Message}");
            }
        }

        public List<ContaClienteAlteracao> GetAllContas()
        {
            var contas = new List<ContaClienteAlteracao>();
            try
            {
                contas = _contaClienteRepository.GetAllContas();
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível buscar conta! Erro {e.Message}");
            }
            return contas;
        }

        public ContaClienteAlteracao GetConta(string numConta, string senha)
        {
            var conta = new ContaClienteAlteracao();
            try
            {
               conta = _contaClienteRepository.GetConta(numConta, senha);
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível buscar conta! Erro {e.Message}");
            }
            if (conta == null)
            {
                _notifications.Notificacoes.Add("Conta não encontrada!");
            }
            return conta;
        }

        public void UpdateConta(Contas.Conta conta)
        {
            try
            {
                _contaClienteRepository.UpdateConta(conta);
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível atualizar conta! Erro {e.Message}");
            }
        }
    }
}
