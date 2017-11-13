using ProjetoBanco.Domain.Conta;
using ProjetoBanco.Domain.Contas;
using ProjetoBanco.Domain.Entities;
using System.Collections.Generic;
using System.Web.Http;

namespace Web_Api.Controllers
{
    public class ContaClienteController : ApiController
    {
        private readonly IContaClienteService _iContaClienteService;
        private readonly Notifications _notifications;

        public ContaClienteController(Notifications notifications, IContaClienteService iContaClienteService)
        {
            _notifications = notifications;
            _iContaClienteService = iContaClienteService;
        }
        public IHttpActionResult AddContaCliente(Conta conta)
        {
            _iContaClienteService.AddContaCliente(conta);
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
        public IHttpActionResult GetConta(string conta, string senha)
        {
            var contaClienteAlteracao = new ContaClienteAlteracao();
            contaClienteAlteracao = _iContaClienteService.GetConta(conta, senha);
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
                return Ok(contaClienteAlteracao);
            }
        }
        public IHttpActionResult UpdateConta(Conta conta)
        {
            _iContaClienteService.UpdateConta(conta);
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
        public IHttpActionResult GetAllContas()
        {
            var contas = new List<ContaClienteAlteracao>(_iContaClienteService.GetAllContas());

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
                return Ok(contas);
            }
        }

    }
}

