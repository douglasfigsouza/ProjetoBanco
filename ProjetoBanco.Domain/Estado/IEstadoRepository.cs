using ProjetoBanco.Domain.Estados.Dto;
using System.Collections.Generic;

namespace ProjetoBanco.Domain.Estados
{
    public interface IEstadoRepository
    {
        IEnumerable<Estado> GetAllEstados();
    }
}
