using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Application.Interfaces
{
    public interface IEstadoAppService
    {
        Estado GetByEstadoId(int id);
        IEnumerable<Estado> GetAllEstados();
        void Dispose();
    }
}
