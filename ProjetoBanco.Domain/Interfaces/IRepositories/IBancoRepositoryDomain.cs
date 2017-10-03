using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Domain.Interfaces.IRepositories
{
    public interface IBancoRepositoryDomain
    {
        void AddBanco(Banco banco);
        Banco GetByBancoId(int id);
        IEnumerable<Banco> GetAllBancos();
        void UpdateBanco(Banco banco);
        void RemoveBanco(Banco banco);
        void Dispose();
    }
}
