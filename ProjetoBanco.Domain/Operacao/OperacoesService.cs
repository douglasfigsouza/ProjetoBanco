using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Operacao;
using ProjetoBanco.Domain.Operacoes;
using ProjetoBanco.Domain.Operacoes.Dto;
using System;

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

        public void AddOperacao(Operacoes.Operacoes op)
        {
            try
            {
                _operacoesRepository.AddOperacao(op);
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível castrar operação! Erro {e.Message}");
            }
        }

        public Transacao VerificaDadosTransacao(Transacao transacao)
        {
            var transact = new Transacao();
            try
            {
                transact = _operacoesRepository.VerificaDadosTransacao(transacao);
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível localizar conta! Erro{e.Message}");
            }
            if (transact.nome == null)
            {
                _notifications.Notificacoes.Add("Cliente inexistente ou você não é o proprietario da conta!");
            }
            return transact;
        }

        public Transacao VerificaDadosTransferencia(Transacao transacao)
        {
            var transact = new Transacao();
            try
            {
                transact = _operacoesRepository.VerificaDadosTransferencia(transacao);
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível realizar a transferência! Erro{e.Message}");
            }
            if (transact.conta == "")
            {
                _notifications.Notificacoes.Add("Conta para a transferência não existe!");
            }
            return transact;
        }

        public Transacao ConsultaSaldo(Transacao transacao)
        {
            var transact = new Transacao();
            try
            {
                transact = _operacoesRepository.ConsultaSaldo(transacao);
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Conta não encontrada!{e.Message}");
            }
            if (transact.nome == null)
            {
                _notifications.Notificacoes.Add("Conta não encontrada!");
            }
            return transact;
        }
    }
}
