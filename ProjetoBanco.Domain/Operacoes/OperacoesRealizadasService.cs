using System.Collections.Generic;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Interfaces.IRepositories;
using ProjetoBanco.Domain.Interfaces.IServices;
using ProjetoBanco.Domain.Operacoes;

namespace ProjetoBanco.Domain.Services
{
    public class OperacoesRealizadasService:IOperacoeRealizadaService
    {
        private readonly IOperacoesRealizadasRepository _operacoesRealizadasRepository;

        public OperacoesRealizadasService(IOperacoesRealizadasRepository operacoesRealizadasRepositoryDomain)
        {
            _operacoesRealizadasRepository = operacoesRealizadasRepositoryDomain;
        }
        public void Deposito(OperacoesRealizadas operacaoRealizada,int op)
        {
           _operacoesRealizadasRepository.Deposito(operacaoRealizada,op);
        }

        public string Saque(OperacoesRealizadas operacaoRealizada, int op)
        {
            if (_operacoesRealizadasRepository.Saque(operacaoRealizada, op) == 0)
            {
                return "Não foi possivel realizar o saque, pois você não possui saldo suficiente";
            }
            else
            {
                return "Saque realizado com sucesso";
            }
        }

        public string ConfirmEstorno(int id)
        {
           return _operacoesRealizadasRepository.ConfirmEstorno(id);
        }

        public void Dispose()
        {
            _operacoesRealizadasRepository.Dispose();
        }

        public int Transferencia(OperacoesRealizadas opConta1, OperacoesRealizadas opConta2)
        {
           return  _operacoesRealizadasRepository.Transferencia(opConta1, opConta2);
        }

        public IEnumerable<Estorno> GetAllOperacoesEstorno()
        {
            return _operacoesRealizadasRepository.GetAllOperacoesEstorno();
        }

        public IEnumerable<Estorno> GetAllOperacoesPorContaParaEstorno(string conta, string senha, int agencia)
        {
            return _operacoesRealizadasRepository.GetAllOperacoesPorContaParaEstorno(conta, senha, agencia);
        }
    }
}
