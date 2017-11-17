using System.Collections.Generic;
namespace ProjetoBanco.Domain.Bancos
{
    public interface IBancoRepository
    {
        void PostBanco(Banco banco);
        IEnumerable<Banco> GetAllBancos();
    }
}
