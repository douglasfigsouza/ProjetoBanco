using System.Net.Http;
using ProjetoBanco.Domain.Interfaces.IRepositories;
using ProjetoBanco.Domain.Interfaces.IServices;
using ProjetoBanco.Domain.Operacoes;

namespace ProjetoBanco.Domain.Services
{
    public class OperacoesService:IOperacaoService
    {
        private readonly IOperacoesRepository _repository;
        public OperacoesService(IOperacoesRepository repository)
        {
            _repository = repository;
        }
        public HttpResponseMessage AddOperacao(Operacoes.Operacoes op)
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
