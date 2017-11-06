using ProjetoBanco.Domain.Bancos;
using ProjetoBanco.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoBanco.Domain.Banco
{
    public class BancoService:IBancoService
    {
        private IBancoRepository _bancoRepository;
        private Notifications _notifications;

        public BancoService(IBancoRepository bancoRepository, Notifications notifications)
        {
            _bancoRepository = bancoRepository;
            _notifications = notifications;
        }

        public void AddBanco(Bancos.Banco banco)
        {
            try
            {
                _bancoRepository.AddBanco(banco);
            }
            catch (Exception e)
            {
               _notifications.Notificacoes.Add($"Impossível cadastrar Banco! Erro {e.Message}");
            }
        }

        public IEnumerable<Bancos.Banco> GetAllBancos()
        {
            IEnumerable<Bancos.Banco> bancos = new List<Bancos.Banco>();
            try
            {
               bancos =_bancoRepository.GetAllBancos();
            }
            catch (Exception e)
            {
               _notifications.Notificacoes.Add($"Impossível buscar bancos! Erro {e.Message}");
            }
            if (bancos.Count() == 0)
            {
                _notifications.Notificacoes.Add("Não existem bancos cadastrados!");
            }
            return bancos;
        }


    }
}
