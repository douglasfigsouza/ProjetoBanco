

using System;
using System.Collections.Generic;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Interfaces.IRepositories;
using ProjetoBanco.Domain.Interfaces.IServices;

namespace ProjetoBanco.Domain.Services
{
    public class OperacoesRealizadasServiceDomain:IOperacoeRealizadaServiceDomain
    {
        private readonly IOperacoesRealizadasRepositoryDomain _operacoesRealizadasRepositoryDomain;

        public OperacoesRealizadasServiceDomain(IOperacoesRealizadasRepositoryDomain operacoesRealizadasRepositoryDomain)
        {
            _operacoesRealizadasRepositoryDomain = operacoesRealizadasRepositoryDomain;
        }
        public void Deposito(OperacaoRealizada operacaoRealizada,int op)
        {
           _operacoesRealizadasRepositoryDomain.Deposito(operacaoRealizada,op);
        }

        public string Saque(OperacaoRealizada operacaoRealizada, int op)
        {
            if (_operacoesRealizadasRepositoryDomain.Saque(operacaoRealizada, op) == 0)
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
           return _operacoesRealizadasRepositoryDomain.ConfirmEstorno(id);
        }

        public void Dispose()
        {
            _operacoesRealizadasRepositoryDomain.Dispose();
        }

        public int Transferencia(OperacaoRealizada opConta1, OperacaoRealizada opConta2)
        {
           return  _operacoesRealizadasRepositoryDomain.Transferencia(opConta1, opConta2);
        }

        public IEnumerable<Estorno> GetAllOperacoesEstorno()
        {
            return _operacoesRealizadasRepositoryDomain.GetAllOperacoesEstorno();
        }

        public IEnumerable<Estorno> GetAllOperacoesPorContaParaEstorno(string conta, string senha, int agencia)
        {
            return _operacoesRealizadasRepositoryDomain.GetAllOperacoesPorContaParaEstorno(conta, senha, agencia);
        }
    }
}
