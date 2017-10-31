using System.Collections.Generic;

namespace ProjetoBanco.Domain.Bancos
{
    public interface IBancoService
    {
        void AddBanco(Banco banco);
        IEnumerable<Banco> GetAllBancos();
    }
}
