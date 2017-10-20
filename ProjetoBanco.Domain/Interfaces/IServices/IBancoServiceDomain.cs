using System.Collections.Generic;
using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Domain.Interfaces.IServices
{
    public interface IBancoServiceDomain
    {
        string AddBanco(Banco banco);
        IEnumerable<Banco> GetAllBancos();
        void Dispose();
    }
}
