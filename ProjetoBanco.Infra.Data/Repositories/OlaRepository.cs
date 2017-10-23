using ProjetoBanco.Domain.Interfaces.IRepositories;

namespace ProjetoBanco.Infra.Data.Repositories
{
    public class OlaRepository : IOlaRepository
    {
        public string Ola()
        {
            return "Olá mundo!";
        }
    }
}