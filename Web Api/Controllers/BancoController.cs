using ProjetoBanco.Domain.Bancos;
using ProjetoBanco.Domain.Entities;
using System.Collections.Generic;
using System.Web.Http;

namespace Web_Api.Controllers
{
    public class BancoController : ApiController
    {
        private readonly IBancoRepository _bancoRepository;
        private readonly Notifications _notifications;

        public BancoController(IBancoRepository bancoRepository, Notifications notifications)
        {
            _bancoRepository = bancoRepository;
            _notifications = notifications;
        }

        public IHttpActionResult AddBanco(Banco banco)
        {
            _bancoRepository.AddBanco(banco);
            if (_notifications.Notificacoes.Count > 0)
            {
                string erros = "";
                foreach (var erro in _notifications.Notificacoes)
                {
                    erros = erros + " " + erro;
                }
                return BadRequest(erros);
            }
            else
            {
                return Ok();
            }
        }
        public IHttpActionResult GetAllBancos()
        {
            List<Banco> bancos = new List<Banco>(_bancoRepository.GetAllBancos());
            if (_notifications.Notificacoes.Count > 0)
            {
                string erros = "";
                foreach (var erro in _notifications.Notificacoes)
                {
                    erros = erros + " " + erro;
                }
                return BadRequest(erros);
            }
            else
            {
                return Ok(bancos);
            }
        }
    }
}
