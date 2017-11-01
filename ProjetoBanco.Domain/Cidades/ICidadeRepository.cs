using System.Collections.Generic;

namespace ProjetoBanco.Domain.Cidades
{
    public interface ICidadeRepository
    {
        IEnumerable<Cidade> GetCidadesByEstadoId(int id);
    }
}
