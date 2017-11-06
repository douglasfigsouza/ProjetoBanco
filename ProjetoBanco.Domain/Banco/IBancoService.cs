using System.Collections.Generic;

namespace ProjetoBanco.Domain.Banco
{
    public interface IBancoService
    {
        void AddBanco(Bancos.Banco banco);
        IEnumerable<Bancos.Banco> GetAllBancos();
    }
}
