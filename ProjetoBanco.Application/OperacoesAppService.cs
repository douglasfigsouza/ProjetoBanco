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
    public class OperacoesAppService : IOperacoesAppService
    {
        private readonly IOperacaoServiceDomain _OperacaoServiceDomain;
        private readonly IOperacoesRepositoryDomain _OperacaoRepositoryDomain;

        public OperacoesAppService(IOperacaoServiceDomain OperacaoServiceDomain, IOperacoesRepositoryDomain OperacaoRepositoryDomain)
        {
            _OperacaoServiceDomain = OperacaoServiceDomain;
            _OperacaoRepositoryDomain = OperacaoRepositoryDomain;
        }
        public void AddOperacao(Operacoes op)
        {
            _OperacaoRepositoryDomain.AddOperacao(op);
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
    }
}
