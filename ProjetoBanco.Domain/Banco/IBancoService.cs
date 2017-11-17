using System.Collections.Generic;

namespace ProjetoBanco.Domain.Banco
{
    public interface IBancoService
    {
        IEnumerable<Bancos.Banco> GetAllBancos();
    }
}
