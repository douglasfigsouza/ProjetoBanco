using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Domain.Interfaces.IServices
{
    public interface ICidadeServiceDomain
    {
        Cidade GetByCidadeId(int id);
        IEnumerable<Cidade> GetCidadesByEstadoId(int id);
        void Dispose();
    }
}
