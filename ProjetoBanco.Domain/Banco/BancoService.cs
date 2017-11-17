using ProjetoBanco.Domain.Bancos;
using ProjetoBanco.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoBanco.Domain.Banco
{
    public class BancoService : IBancoService
    {
        private IBancoRepository _bancoRepository;
        private Notifications _notifications;

        public BancoService(IBancoRepository bancoRepository, Notifications notifications)
        {
            _bancoRepository = bancoRepository;
            _notifications = notifications;
        }

        public IEnumerable<Bancos.Banco> GetAllBancos()
        {
            IEnumerable<Bancos.Banco> bancos = new List<Bancos.Banco>();
            bancos = _bancoRepository.GetAllBancos();
            if (bancos.Count() == 0)
            {
                _notifications.Notificacoes.Add("Não existem bancos cadastrados!");
            }
            return bancos;
        }


    }
}
