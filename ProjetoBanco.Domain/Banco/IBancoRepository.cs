using System.Collections.Generic;
namespace ProjetoBanco.Domain.Bancos
{
    public interface IBancoRepository
    {
        void AddBanco(Banco banco);
        IEnumerable<Banco> GetAllBancos();
    }
}
