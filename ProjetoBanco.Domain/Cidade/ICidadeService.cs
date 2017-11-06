using System.Collections.Generic;

namespace ProjetoBanco.Domain.Cidade
{
    public interface ICidadeService
    {
        IEnumerable<Cidades.Cidade> GetCidadesByEstadoId(int id);
    }
}
