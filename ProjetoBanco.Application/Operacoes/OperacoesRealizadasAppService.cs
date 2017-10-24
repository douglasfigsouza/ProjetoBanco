using System.Collections.Generic;
using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Interfaces.IRepositories;
using ProjetoBanco.Domain.Interfaces.IServices;
using ProjetoBanco.Domain.Operacoes;

namespace ProjetoBanco.Application
{
    public class OperacoesRealizadasAppService:IOperacaoesRealizadasAppService
    {
        private readonly IOperacoesRealizadasRepository _operacoesRealizadasRepository;
        private readonly IOperacoeRealizadaService _operacoesRealizadaService;
        public OperacoesRealizadasAppService(IOperacoeRealizadaService operacoesRealizadaService, IOperacoesRealizadasRepository operacoesRealizadasRepository)
        {
            _operacoesRealizadaService = operacoesRealizadaService;
            _operacoesRealizadasRepository = operacoesRealizadasRepository;
        }
        public void Deposito(OperacoesRealizadas operacaoRealizada, int op)
        {
           _operacoesRealizadasRepository.Deposito(operacaoRealizada,op);
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

        public void Dispose()
        {
            _operacoesRealizadasRepository.Dispose();
            _operacoesRealizadaService.Dispose();
        }

        public string Saque(OperacoesRealizadas operacaoRealizada, int op)
        {
           return _operacoesRealizadaService.Saque(operacaoRealizada,op);
        }

        public IEnumerable<Estorno> GetAllOperacoesPorContaParaEstorno(string conta, string senha, int agencia)
        {
            return _operacoesRealizadasRepository.GetAllOperacoesPorContaParaEstorno(conta, senha,agencia);
        }

    }
}