using System.Collections.Generic;

namespace ProjetoBanco.Domain.Cidades
{
    public interface ICidadeService
    {
        Cidade GetByCidadeId(int id);
        IEnumerable<Cidade> GetCidadesByEstadoId(int id);
        void Dispose();
    }
}
