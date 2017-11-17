using ProjetoBanco.Domain.Banco;
using ProjetoBanco.Domain.Bancos;
using ProjetoBanco.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Web_Api.Controllers
{
    public class BancoController : ApiController
    {
        private readonly IBancoService _bancoService;
        private readonly IBancoRepository _bancoRepository;
        private readonly Notifications _notifications;

        public BancoController(Notifications notifications, IBancoService bancoService, IBancoRepository bancoRepository)
        {
            _notifications = notifications;
            _bancoService = bancoService;
            _bancoRepository = bancoRepository;
        }

        public IHttpActionResult AddBanco(Banco banco)
        {
            try
            {
                _bancoRepository.PostBanco(banco);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Ops! algo deu errado. Erro: {e.Message}");
            }
        }
        public IHttpActionResult GetAllBancos()
        {
            try
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
            catch (Exception e)
            {
                return BadRequest($"Ops! algo deu errado. Erro: {e.Message}");
            }
        }
    }
}
