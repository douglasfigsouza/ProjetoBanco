﻿using ProjetoBanco.Domain.Contas;
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

        public List<ContaCliente> GetAllDadosEClientesDaConta()
        {
            var dadosEClientesDaConta = new List<ContaCliente>();
            return dadosEClientesDaConta = _contaClienteRepository.GetAllDadosEClientesDaConta();
        }
        public ContaClienteAlteracao GetConta(int contaId)
        {
            var conta = new ContaClienteAlteracao();
            try
            {
                conta = _contaClienteRepository.GetConta(contaId);
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

        public List<ContaCliente> GetAllClientesConta()
        {
            throw new NotImplementedException();
        }
    }
}
