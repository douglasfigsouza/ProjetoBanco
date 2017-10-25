using System;
using System.Net.Http;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Interfaces.IRepositories;
using ProjetoBanco.Domain.Interfaces.IServices;
using ProjetoBanco.Domain.Operacoes;

namespace ProjetoBanco.Domain.Services
{
    public class OperacoesService:IOperacaoService
    {
        private readonly IOperacoesRepository _repository;
        private readonly Notifications _notifications;
        public OperacoesService(IOperacoesRepository repository, Notifications notifications)
        {
            _repository = repository;
            _notifications = notifications;
        }
        public HttpResponseMessage AddOperacao(Operacoes.Operacoes op)
        {
           return _repository.AddOperacao(op);
        }


        public Transacao VerificaDadosTransacao(Transacao transacao)
        {
            transacao = _repository.VerificaDadosTransacao(transacao);

            if (transacao!=null)
            {
                return transacao; 
            }
            else
            {
                return null;
            }
        }
        public Transacao VerificaDadosTransferencia(Transacao transacao)
        {
           return _repository.VerificaDadosTransferencia(transacao);
        }


        public Transacao ConsultaSaldo(Transacao transacao)
        {
            return _repository.ConsultaSaldo(transacao);
        }


    }
}
