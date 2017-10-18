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
    public class BancoServiceDomain:IBancoServiceDomain
    {
        private readonly IBancoRepositoryDomain _bancoRepositoryDomain;

        public BancoServiceDomain( IBancoRepositoryDomain bancoRepositoryDomain)
        {
            _bancoRepositoryDomain = bancoRepositoryDomain;
        }
        public string AddBanco(Banco banco)
        {
           return _bancoRepositoryDomain.AddBanco(banco);
        }

        public Banco GetByBancoId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Banco> GetAllBancos()
        {
           return _bancoRepositoryDomain.GetAllBancos();
        }

        public string UpdateBanco(Banco banco)
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
