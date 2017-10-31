using ProjetoBanco.Domain.Bancos;
using System.Collections.Generic;

namespace ProjetoBanco.Domain.Services
{
    public class BancoService:IBancoService
    {
        private readonly IBancoRepository _bancoRepository;

        public BancoService( IBancoRepository bancoRepository)
        {
            _bancoRepository = bancoRepository;
        }
        public void AddBanco(Banco banco)
        {
           _bancoRepository.AddBanco(banco);
        }

        public IEnumerable<Banco> GetAllBancos()
        {
           return _bancoRepository.GetAllBancos();
        }
    }
}
