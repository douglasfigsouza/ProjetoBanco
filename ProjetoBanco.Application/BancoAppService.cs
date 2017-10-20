using System;
using System.Collections.Generic;
using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Interfaces.IRepositories;
using ProjetoBanco.Domain.Interfaces.IServices;

namespace ProjetoBanco.Application
{
    public class BancoAppService : IBancoAppService
    {
        private readonly IBancoServiceDomain _bancoServiceDomain;
        private readonly IBancoRepositoryDomain _bancoRepositoryDomain;
        public BancoAppService(IBancoServiceDomain IBancoServiceDomain, IBancoRepositoryDomain bancoRepositoryDomain)
        {
            _bancoServiceDomain = IBancoServiceDomain;
            _bancoRepositoryDomain = bancoRepositoryDomain;
        }
        public string AddBanco(Banco banco)
        {
            return _bancoRepositoryDomain.AddBanco(banco);
        }

        public IEnumerable<Banco> GetAllBancos()
        {
            return _bancoRepositoryDomain.GetAllBancos();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
