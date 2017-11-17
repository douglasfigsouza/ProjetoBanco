using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Operacão;
using ProjetoBanco.Domain.Operacoes;
using ProjetoBanco.Domain.Operacoes.Dto;
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
        public void Saque(OperacoesRealizadas operacaoRealizada)
        {
            int result = -1;
            result = _operacoesRealizadasRepository.Saque(operacaoRealizada);
            if (result == 0)
            {
                _notifications.Notificacoes.Add("Você não possui saldo suficiente!");
            }
        }

        public void Transferencia(List<OperacoesRealizadas> operacoes)
        {
            int result = -1;
            result = _operacoesRealizadasRepository.Transferencia(operacoes);
            if (result == 0)
            {
                _notifications.Notificacoes.Add("A transferência não pode ser realizada, você não possui saldo suficiente");
            }

        }

        public List<Estorno> GetAllOperacoesPorContaParaEstorno(DadosGetOpReal dadosGetOp)
        {
            var operacoes = new List<Estorno>();
            operacoes = _operacoesRealizadasRepository.GetAllOperacoesPorContaParaEstorno(dadosGetOp);
            if (operacoes.Count == 0)
            {
                _notifications.Notificacoes.Add("Não existem operações cadastradas");
            }
            return operacoes;
        }

        public IEnumerable<Estorno> GetAllOperacoesEstorno()
        {
            IEnumerable<Estorno> operacoes = new List<Estorno>();
            operacoes = _operacoesRealizadasRepository.GetAllOperacoesEstorno();
            if (operacoes.Count() == 0)
            {
                _notifications.Notificacoes.Add("Não existem operações cadastradas");
            }
            return operacoes;
        }

        public Estorno GetOpRealizadaEstornoById(int id)
        {
            var estorno = new Estorno();
            estorno = _operacoesRealizadasRepository.GetOpRealizadaEstornoById(id);
            if (estorno.conta == "")
            {
                _notifications.Notificacoes.Add("Não existem operação");
            }
            return estorno;
        }

        public List<Estorno> GetExtratoPorData(DadosGetOpReal dadosGetOp)
        {
            List<Estorno> operacoes = new List<Estorno>();
            operacoes = _operacoesRealizadasRepository.GetExtratoPorData(dadosGetOp);
            if (operacoes.Count == 0)
            {
                _notifications.Notificacoes.Add("Não existem movimentações nessa conta!");
            }
            return operacoes;
        }
    }
}
