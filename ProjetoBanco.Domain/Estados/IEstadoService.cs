using ProjetoBanco.Domain.Estados.Dto;
using System.Collections.Generic;

namespace ProjetoBanco.Domain.Estados
{
    public interface IEstadoService
    {
        IEnumerable<Estado> GetAllEstados();
    }
}
