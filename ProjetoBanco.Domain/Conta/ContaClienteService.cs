using ProjetoBanco.Domain.Contas;
using ProjetoBanco.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public List<ContaCliente> GetAllClientesConta()
        {
            throw new NotImplementedException();
        }

        public List<ContaCliente> GetAllContas()
        {
            var contas = new List<ContaClienteAlteracao>();
            var clientesConta = new List<ContaCliente>();
            var contaCliente = new List<ContaCliente>();
            var dadosContasClientesUnicos = new List<ContaCliente>();
            try
            {
                contas = _contaClienteRepository.GetAllContas();
                clientesConta = _contaClienteRepository.GetAllClientesConta();
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível buscar conta! Erro {e.Message}");
            }
            foreach (var conta in contas)
            {
                var contacli = new ContaCliente
                {
                    contaId = conta.contaId,
                    agencia = conta.agencia,
                    senha = conta.senha,
                    conta = conta.conta
                };
                foreach (var cli in clientesConta)
                {
                    if (cli.contaId == conta.contaId)
                    {
                        contacli.clientes.Add(new Clientes.ClienteDto
                        {
                            nome = cli.nome
                        });
                    }
                }
                contaCliente.Add(contacli);
            }
            dadosContasClientesUnicos.Add(contaCliente.AsEnumerable().ElementAt(0));
            foreach (var dado in contaCliente)
            {
                foreach (var conta in new List<ContaCliente>(dadosContasClientesUnicos))
                {
                    if (conta.contaId != dado.contaId)
                    {
                        dadosContasClientesUnicos.Add(dado);
                    }
                }
            }
            return dadosContasClientesUnicos;
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
    }
}
