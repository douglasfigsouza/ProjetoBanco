using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Operacão;
using ProjetoBanco.Domain.Operacoes;
using ProjetoBanco.Domain.Operacoes.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoBanco.Domain.Operacao
{
    public class OperacaoRealizadaService : IOperacaoRealizadaService
    {
        private readonly IOperacoesRealizadasRepository _operacoesRealizadasRepository;
        private Notifications _notifications;

        public OperacaoRealizadaService(IOperacoesRealizadasRepository operacoesRealizadasRepository, Notifications notifications)
        {
            _operacoesRealizadasRepository = operacoesRealizadasRepository;
            _notifications = notifications;
        }

        public void Deposito(OperacoesRealizadas operacaoRealizada)
        {
            try
            {
                _operacoesRealizadasRepository.Deposito(operacaoRealizada);
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível efetuar depósito! Erro {e.Message}");
            }
        }

        public void Saque(OperacoesRealizadas operacaoRealizada)
        {
            int result = -1;
            try
            {
                result =_operacoesRealizadasRepository.Saque(operacaoRealizada);
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível efetuar saque! Erro {e.Message}");
            }
            if (result == 0)
            {
                _notifications.Notificacoes.Add("Você não possui saldo suficiente!");
            }
        }

        public void Transferencia(List<OperacoesRealizadas> operacoes)
        {
            int result = -1;
            try
            {
                result = _operacoesRealizadasRepository.Transferencia(operacoes);
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível efetuar transferência! Erro {e.Message}");
            }
            if (result == 0)
            {
                _notifications.Notificacoes.Add("A transferência não pode ser realizada, você não possui saldo suficiente");
            }

        }

        public List<Estorno> GetAllOperacoesPorContaParaEstorno(DadosGetOpReal dadosGetOp)
        {
            var operacoes = new List<Estorno>();
            try
            {
                operacoes = _operacoesRealizadasRepository.GetAllOperacoesPorContaParaEstorno(dadosGetOp);
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível buscar operacões! Erro {e.Message}");
            }
            if (operacoes.Count == 0)
            {
                _notifications.Notificacoes.Add("Não existem operações cadastradas");
            }
            return operacoes;
        }

        public IEnumerable<Estorno> GetAllOperacoesEstorno()
        {
            IEnumerable<Estorno> operacoes = new List<Estorno>();
            try
            {
                operacoes = _operacoesRealizadasRepository.GetAllOperacoesEstorno();
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível buscar operacões! Erro {e.Message}");
            }
            if (operacoes.Count() == 0)
            {
                _notifications.Notificacoes.Add("Não existem operações cadastradas");
            }
            return operacoes;
        }

        public Estorno GetOpRealizadaEstornoById(int id)
        {
            var estorno = new Estorno();
            try
            {
                estorno = _operacoesRealizadasRepository.GetOpRealizadaEstornoById(id);
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível buscar operacão! Erro {e.Message}");
            }
            if (estorno.conta == "")
            {
                _notifications.Notificacoes.Add("Não existem operação");
            }
            return estorno;
        }

        public List<Estorno> GetExtratoPorData(DadosGetOpReal dadosGetOp)
        {
            List<Estorno> operacoes = new List<Estorno>();
            try
            {
                operacoes = _operacoesRealizadasRepository.GetExtratoPorData(dadosGetOp);
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível buscar Extrato! Erro {e.Message}");
            }
            if (operacoes.Count == 0)
            {
                _notifications.Notificacoes.Add("Não existem movimentações nessa conta!");
            }
            return operacoes;
        }

        public void ConfirmEstorno(int id)
        {
            try
            {
                _operacoesRealizadasRepository.ConfirmEstorno(id);
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível realizar estorno! Erro {e.Message}");
            }
        }
    }
}
