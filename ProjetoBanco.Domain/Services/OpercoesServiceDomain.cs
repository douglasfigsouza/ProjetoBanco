using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Interfaces.IRepositories;
using ProjetoBanco.Domain.Interfaces.IServices;

namespace ProjetoBanco.Domain.Services
{
    public class OpercoesServiceDomain:IOperacaoServiceDomain
    {
        private readonly IOperacoesRepositoryDomain _repository;
        public OpercoesServiceDomain(IOperacoesRepositoryDomain repository)
        {
            _repository = repository;
        }
        public string AddOperacao(Operacoes op)
        {
           return _repository.AddOperacao(op);
        }

        public Operacoes GetOperacaoById(int id)
        {
            return _repository.GetOperacaoById(id);
        }

        public IEnumerable<Operacoes> GetAllOperacoes()
        {
            return _repository.GetAllOperacoes();
        }

        public void UpdateOperacao(Operacoes op)
        {
            _repository.UpdateOperacao(op);
        }

        public void RemoveOperacao(Operacoes op)
        {
            _repository.RemoveOperacao(op);
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

        public List<Transacao> VerificaDadosTransferencia(List<Transacao> transacoes)
        {
            throw new NotImplementedException();
        }
    }
}
