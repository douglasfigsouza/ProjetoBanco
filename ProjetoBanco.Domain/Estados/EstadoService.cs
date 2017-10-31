using ProjetoBanco.Domain.Estados.Dto;
using System.Collections.Generic;

namespace ProjetoBanco.Domain.Estados
{
    public class EstadoService:IEstadoService
    {
        private readonly IEstadoRepository _IEstadoRepositoryDomain;

        public EstadoService(IEstadoRepository IEstadoRepositoryDomain)
        {
            _IEstadoRepositoryDomain = IEstadoRepositoryDomain;
        }

        public IEnumerable<Estado> GetAllEstados()
        {
            return _IEstadoRepositoryDomain.GetAllEstados();
        }
    }
}
