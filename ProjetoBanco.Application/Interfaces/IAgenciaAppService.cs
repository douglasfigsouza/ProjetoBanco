using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Application.Interfaces
{
    public interface IAgenciaAppService
    {
        void AddAgencia(Agencia agencia);
        Agencia GetByAgenciaId(int id);
        IEnumerable<Agencia> GetAllAgencias();
        void UpdateAgencia(Agencia agencia);
        void RemoveAgencia(Agencia agencia);
        void Dispose();
    }
}
