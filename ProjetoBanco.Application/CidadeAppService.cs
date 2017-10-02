using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Interfaces.IServices;

namespace ProjetoBanco.Application
{
    public class CidadeAppService:ICidadesAppService
    {
        private readonly ICidadeServiceDomain _ICidadeServiceDomain;
        public CidadeAppService(ICidadeServiceDomain ICidadeServiceDomain)
        {
            _ICidadeServiceDomain = ICidadeServiceDomain;
        }
        public Cidade GetByCidadeId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cidade> GetCidadesByEstadoId(int id)
        {
           return _ICidadeServiceDomain.GetCidadesByEstadoId(id);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
