using System;
using System.CodeDom;
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
    public class AgenciaAppService:IAgenciaAppService
    {
        private readonly IAgenciaServiceDomain _agenciaServiceDomain;
        private readonly IAgenciaRepositoryDomain _agenciaRepositoryDomain;

        public AgenciaAppService(IAgenciaServiceDomain agenciaServiceDomain,
            IAgenciaRepositoryDomain agenciaRepositoryDomain)
        {
            _agenciaServiceDomain = agenciaServiceDomain;
            _agenciaRepositoryDomain = agenciaRepositoryDomain;
        }

        public void AddAgencia(Agencia agencia)
        {
            _agenciaRepositoryDomain.AddAgencia(agencia);
        }

        public Agencia GetByAgenciaId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Agencia> GetAllAgencias()
        {
            throw new NotImplementedException();
        }

        public void UpdateAgencia(Agencia agencia)
        {
            throw new NotImplementedException();
        }

        public void RemoveAgencia(Agencia agencia)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
