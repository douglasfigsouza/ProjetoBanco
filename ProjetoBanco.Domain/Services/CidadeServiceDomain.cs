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
    public class CidadeServiceDomain:ICidadeServiceDomain
    {
        private readonly ICidadeRepositoryDomain _ICidadeRepositoryDomain;

        public CidadeServiceDomain(ICidadeRepositoryDomain ICidadeRepositoryDomain)
        {
            _ICidadeRepositoryDomain = ICidadeRepositoryDomain;
        }
        public Cidade GetByCidadeId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cidade> GetCidadesByEstadoId(int id)
        {
            return _ICidadeRepositoryDomain.GetCidadesByEstadoId(id);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
