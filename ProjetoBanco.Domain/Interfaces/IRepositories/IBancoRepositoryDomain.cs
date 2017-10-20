using System.Collections.Generic;
using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Domain.Interfaces.IRepositories
{
    public interface IBancoRepositoryDomain
    {
        string AddBanco(Banco banco);
        IEnumerable<Banco> GetAllBancos();
        void Dispose();
    }
}
