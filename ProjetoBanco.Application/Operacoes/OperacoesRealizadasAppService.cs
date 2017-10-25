using System.Collections.Generic;
using System.Net.Http;
using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Interfaces.IRepositories;
using ProjetoBanco.Domain.Interfaces.IServices;
using ProjetoBanco.Domain.Operacoes;
using Web_Api.Utilitarios;

namespace ProjetoBanco.Application
{
    public class OperacoesRealizadasAppService:IOperacaoesRealizadasAppService
    {
        private readonly IOperacoesRealizadasRepository _operacoesRealizadasRepository;
        private readonly IOperacoeRealizadaService _operacoesRealizadaService;
        private readonly Notifications _notifications;
        private HttpResponseMessage response;

        public OperacoesRealizadasAppService(IOperacoeRealizadaService operacoesRealizadaService, IOperacoesRealizadasRepository operacoesRealizadasRepository, Notifications notifications)
        {
            _operacoesRealizadaService = operacoesRealizadaService;
            _operacoesRealizadasRepository = operacoesRealizadasRepository;
            _notifications = notifications;
        }
        public HttpResponseMessage Deposito(OperacoesRealizadas operacaoRealizada)
        {
            response = HttpClientConf.HttpClientConfig("Operacoes")
                .PostAsJsonAsync("Deposito", operacaoRealizada).Result;
            return response;
        }

        public string Transferencia(OperacoesRealizadas opConta1, OperacoesRealizadas opConta2)
        {
            if (_operacoesRealizadaService.Transferencia(opConta1, opConta2)==1)
            {
                return "Transferência Realizada com sucesso";
            }
            else
            { 
                return "A transferência não pode ser realizada, você não possui saldo suficiente";

            }
            
        }

        public Estorno GetOpRealizadaEstornoById(int Id)
        {
            Estorno est= null;
            foreach (var op in _operacoesRealizadasRepository.GetAllOperacoesEstorno())
            {
                if (op.Id == Id)
                {
                    est = new Estorno
                    {
                        Id = op.Id,
                        opId = op.opId,
                        cliente = op.cliente,
                        conta = op.conta,
                        agencia = op.agencia,
                        valorOp = op.valorOp,
                        dataOp = op.dataOp,
                        descricao = op.descricao,
                        saldoAnterior = op.saldoAnterior
                    };
                }
            }
            return est;
        }

        public string ConfirmEstorno(int id)
        {
           return _operacoesRealizadasRepository.ConfirmEstorno(id);
        }

        public IEnumerable<Estorno> GetAllOperacoesEstorno()
        {
           return _operacoesRealizadasRepository.GetAllOperacoesEstorno();
        }

        public HttpResponseMessage Saque(OperacoesRealizadas operacaoRealizada)
        {
            response = HttpClientConf.HttpClientConfig("Operacoes")
                .PostAsJsonAsync("Saque", operacaoRealizada).Result;
            return response;
        }

        public IEnumerable<Estorno> GetAllOperacoesPorContaParaEstorno(string conta, string senha, int agencia)
        {
            return _operacoesRealizadasRepository.GetAllOperacoesPorContaParaEstorno(conta, senha,agencia);
        }

    }
}