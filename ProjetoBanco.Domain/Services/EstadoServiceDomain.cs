using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Interfaces.IRepositories;
using ProjetoBanco.Domain.Interfaces.IServices;

namespace ProjetoBanco.Domain.Services
{
    public class EstadoServiceDomain:IEstadoServiceDomain
    {
        private readonly IEstadoRepositoryDomain _IEstadoRepositoryDomain;

        public EstadoServiceDomain(IEstadoRepositoryDomain IEstadoRepositoryDomain)
        {
            _IEstadoRepositoryDomain = IEstadoRepositoryDomain;
        }
        public Estado GetByEstadoId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Estado> GetAllEstados()
        {
            return _IEstadoRepositoryDomain.GetAllEstados();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
