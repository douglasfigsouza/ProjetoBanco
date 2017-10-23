using System;
using System.Collections.Generic;
using System.Web.Http;
using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Interfaces.IRepositories;
using ProjetoBanco.Domain.Interfaces.IServices;
using Web_Api.Controllers;

namespace ProjetoBanco.Application
{
    public class OperacoesAppService : IOperacoesAppService
    {
        private readonly IOperacaoServiceDomain _OperacaoServiceDomain;
        private readonly IOperacoesRepositoryDomain _OperacaoRepositoryDomain;
        private readonly OperacoesController opController;

        public OperacoesAppService(IOperacaoServiceDomain OperacaoServiceDomain, IOperacoesRepositoryDomain OperacaoRepositoryDomain)
        {
            _OperacaoServiceDomain = OperacaoServiceDomain;
            _OperacaoRepositoryDomain = OperacaoRepositoryDomain;
            opController = new OperacoesController(OperacaoRepositoryDomain);
        }
        public IHttpActionResult AddOperacao(Operacoes op)
        {
            return opController.AddOperacao(op);
            //return _OperacaoRepositoryDomain.AddOperacao(op);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Operacoes> GetAllOperacoes()
        {
            throw new NotImplementedException();
        }

        public Operacoes GetOperacaoById(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveOperacao(Operacoes op)
        {
            throw new NotImplementedException();
        }

        public void UpdateOperacao(Operacoes op)
        {
            throw new NotImplementedException();
        }

        public Transacao VerificaDadosTransacao(Transacao transacao, int op)
        {
            return _OperacaoServiceDomain.VerificaDadosTransacao(transacao,op);
        }

        public Transacao VerificaDadosTransferencia(Transacao transacao)
        {
           return _OperacaoServiceDomain.VerificaDadosTransferencia(transacao);
        }


        public decimal ConsultaSaldo(Transacao transacao)
        {
            decimal saldo= _OperacaoRepositoryDomain.ConsultaSaldo(transacao);
            if( saldo==(-1))
            {
                return -1;
            }
            else
            {
                return saldo;
            }
        }
    }
}
