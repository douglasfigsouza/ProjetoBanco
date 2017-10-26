using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Operacoes.Dto;
using System.Collections.Generic;
using System.Net.Http;

namespace ProjetoBanco.Domain.Operacoes
{
    public class OperacoesRealizadasService:IOperacoeRealizadaService
    {
        private readonly IOperacoesRealizadasRepository _operacoesRealizadasRepository;
        private HttpResponseMessage response;
        private readonly Notifications _notifications;

        public OperacoesRealizadasService(IOperacoesRealizadasRepository operacoesRealizadasRepositoryDomain, Notifications notifications)
        {
            _operacoesRealizadasRepository = operacoesRealizadasRepositoryDomain;
            _notifications = notifications;
        }
        public void Deposito(OperacoesRealizadas operacaoRealizada)
        {
            _operacoesRealizadasRepository.Deposito(operacaoRealizada);
        }

        public void Saque(OperacoesRealizadas operacaoRealizada)
        {
            _operacoesRealizadasRepository.Saque(operacaoRealizada);
        }

        public void ConfirmEstorno(int id)
        {
            _operacoesRealizadasRepository.ConfirmEstorno(id);
        }

        public void Transferencia(List<OperacoesRealizadas>operacoes)
        {
            _operacoesRealizadasRepository.Transferencia(operacoes);
        }

        public IEnumerable<Estorno> GetAllOperacoesEstorno()
        {
            return _operacoesRealizadasRepository.GetAllOperacoesEstorno();
        }

        public IEnumerable<Estorno> GetAllOperacoesPorContaParaEstorno(DadosGetOpReal dadosGetOp)
        {
            return _operacoesRealizadasRepository.GetAllOperacoesPorContaParaEstorno(dadosGetOp);
        }
    }
}
