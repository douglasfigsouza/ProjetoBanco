using System.Collections.Generic;

namespace ProjetoBanco.Domain.Estados
{
    public interface IEstadoRepository
    {
        IEnumerable<Estado> GetAllEstados();
    }
}
