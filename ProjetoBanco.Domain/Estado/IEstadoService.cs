using System.Collections.Generic;

namespace ProjetoBanco.Domain.Estados
{
    public interface IEstadoService
    {
        IEnumerable<Estado> GetAllEstados();
    }
}
