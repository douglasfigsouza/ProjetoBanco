using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Interfaces.IRepositories;
using ProjetoBanco.Domain.Interfaces.IServices;

namespace ProjetoBanco.Domain.Services
{
    public class OpercoesServiceDomain:IOperacaoServiceDomain
    {
        private readonly IOperacoesRepository _repository;
        public OpercoesServiceDomain(IOperacoesRepository repository)
        {
            _repository = repository;
        }
        public HttpResponseMessage AddOperacao(Operacoes op)
        {
           return _repository.AddOperacao(op);
        }

        public Transacao VerificaDadosTransacao(Transacao transacao, int op)
        {
            transacao = _repository.VerificaDadosTransacao(transacao, op);

            if (transacao!=null)
            {
                return transacao; ;
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


        public decimal ConsultaSaldo(Transacao transacao)
        {
           return _repository.ConsultaSaldo(transacao);
        }
    }
}
