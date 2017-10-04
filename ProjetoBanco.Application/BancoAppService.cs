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
    public  class BancoAppService:IBancoAppService
    {
        private readonly IBancoServiceDomain _bancoServiceDomain;
        private readonly IBancoRepositoryDomain _bancoRepositoryDomain;
        public BancoAppService(IBancoServiceDomain IBancoServiceDomain, IBancoRepositoryDomain bancoRepositoryDomain)
        {
            _bancoServiceDomain = IBancoServiceDomain;
            _bancoRepositoryDomain = bancoRepositoryDomain;
        }
        public void AddBanco(Banco banco)
        {
            _bancoRepositoryDomain.AddBanco(banco);
        }

        public Banco GetByBancoId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Banco> GetAllBancos()
        {
            return _bancoRepositoryDomain.GetAllBancos();
        }

        public void UpdateBanco(Banco banco)
        {
            throw new NotImplementedException();
        }

        public void RemoveBanco(Banco banco)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
