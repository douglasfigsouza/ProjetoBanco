using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Interfaces.IRepositories;
using ProjetoBanco.Domain.Interfaces.IServices;

namespace ProjetoBanco.Application
{
    public class OperacoesRealizadasAppService:IOperacaoesRealizadasAppService
    {
        private readonly IOperacoesRealizadasRepositoryDomain _operacoesRealizadasRepositoryDomain;
        private readonly IOperacoeRealizadaServiceDomain _operacoesRealizadaServiceDomain;
        public OperacoesRealizadasAppService(IOperacoeRealizadaServiceDomain operacoesRealizadaServiceDomain, IOperacoesRealizadasRepositoryDomain operacoesRealizadasRepositoryDomain)
        {
            _operacoesRealizadaServiceDomain = operacoesRealizadaServiceDomain;
            _operacoesRealizadasRepositoryDomain = operacoesRealizadasRepositoryDomain;
        }
        public void Deposito(OperacaoRealizada operacaoRealizada, int op)
        {
           _operacoesRealizadasRepositoryDomain.Deposito(operacaoRealizada,op);
        }

        public string Transferencia(OperacaoRealizada opConta1, OperacaoRealizada opConta2)
        {
            if (_operacoesRealizadaServiceDomain.Transferencia(opConta1, opConta2)==1)
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
            foreach (var op in _operacoesRealizadasRepositoryDomain.GetAllOperacoesEstorno())
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
                        dataFormatada = String.Format("{0:MM/dd/yyyy}", op.dataOp),
                        descricao = op.descricao,
                        saldoAnterior = op.saldoAnterior
                    };
                }
            }
            return est;
        }

        public void ConfirmEstorno(int id)
        {
            _operacoesRealizadasRepositoryDomain.ConfirmEstorno(id);
        }

        public IEnumerable<Estorno> GetAllOperacoesEstorno()
        {
           return _operacoesRealizadasRepositoryDomain.GetAllOperacoesEstorno();
        }

        public void Dispose()
        {
            _operacoesRealizadasRepositoryDomain.Dispose();
            _operacoesRealizadaServiceDomain.Dispose();
        }

        public string Saque(OperacaoRealizada operacaoRealizada, int op)
        {
           return _operacoesRealizadaServiceDomain.Saque(operacaoRealizada,op);
        }

        public IEnumerable<Estorno> GetAllOperacoesPorContaParaEstorno(string conta, string senha, int agencia)
        {
            return _operacoesRealizadasRepositoryDomain.GetAllOperacoesPorContaParaEstorno(conta, senha,agencia);
        }
    }
}