using ProjetoBanco.Domain.Banco;
using ProjetoBanco.Domain.Bancos;
using ProjetoBanco.Domain.Entities;
using System.Collections.Generic;
using System.Web.Http;

namespace Web_Api.Controllers
{
    public class BancoController : ApiController
    {
        private readonly IBancoService _bancoService;
        private readonly Notifications _notifications;

        public BancoController(Notifications notifications, IBancoService bancoService)
        {
            _notifications = notifications;
            _bancoService = bancoService;
        }

        public IHttpActionResult AddBanco(Banco banco)
        {
            _bancoService.AddBanco(banco);
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
            List<Banco> bancos = new List<Banco>(_bancoService.GetAllBancos());
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
