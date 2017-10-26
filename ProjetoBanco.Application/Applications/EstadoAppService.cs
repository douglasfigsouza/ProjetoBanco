using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Interfaces.IServices;

namespace ProjetoBanco.Application
{
    public class EstadoAppService : IEstadoAppService
    {
        private readonly IEstadoServiceDomain _IEstadoService;

        public EstadoAppService( IEstadoServiceDomain IEestadoService)
        {
            _IEstadoService = IEestadoService;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Estado> GetAllEstados()
        {
           return _IEstadoService.GetAllEstados();
        }

        public Estado GetByEstadoId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
