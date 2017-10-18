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
    public class AgenciaServiceDomain : IAgenciaServiceDomain
    {
        private readonly IAgenciaRepositoryDomain _repository;

        public AgenciaServiceDomain(IAgenciaRepositoryDomain repository)
        {
            _repository = repository;
        }
        public string AddAgencia(Agencia agencia)
        {
            return _repository.AddAgencia(agencia);
        }

        public Agencia GetByAgenciaId(int id)
        {
            return _repository.GetByAgenciaId(id);
        }

        public Agencia GetAgenciaByNum(int agencia)
        {
            return _repository.GetAgenciaByNum(agencia);
        }

        public IEnumerable<Agencia> GetAllAgencias()
        {
            return _repository.GetAllAgencias();
        }

        public string UpdateAgencia(Agencia agencia)
        {
            return _repository.UpdateAgencia(agencia);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
