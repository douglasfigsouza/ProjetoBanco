using ProjetoBanco.Domain.Operacoes.Dto;

namespace ProjetoBanco.Domain.Operacoes
{
    public class OperacoesService:IOperacaoService
    {
        private readonly IOperacoesRepository _repository;
        public OperacoesService(IOperacoesRepository repository)
        {
            _repository = repository;
        }
        public void AddOperacao(Dto.Operacoes op)
        {
            _repository.AddOperacao(op);
        }


        public Transacao VerificaDadosTransacao(Transacao transacao)
        {
            return _repository.VerificaDadosTransacao(transacao);
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
