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
