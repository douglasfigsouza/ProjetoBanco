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
        public void AddOperacao(Operacoes op)
        {
            _repository.AddOperacao(op);
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

        public Transacao VerificaDadosDeposito(Transacao transacao)
        {
            transacao = _repository.VerificaDadosDeposito(transacao);

            if (transacao!=null)
            {
                return transacao; ;
            }
            else
            {
                return null;
            }
        }

        //public List<Transacao> VerificaDadosTransferencia(List<Transacao> transacoes)
        //{
        //    return _repository.VerificaDadosTransferencia(transacoes);
        //}

        public void Dispose()
        {
            _repository.Dispose();
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
