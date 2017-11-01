using ProjetoBanco.Domain.Contas;
using ProjetoBanco.Domain.Entities;
using System.Web.Http;

namespace Web_Api.Controllers
{
    public class ContaClienteController : ApiController
    {
        private readonly IContaClienteRepository _contaClienteRepository;
        private readonly Notifications _notifications;

        public ContaClienteController(IContaClienteRepository contaClienteRepository, Notifications notifications)
        {
            _contaClienteRepository = contaClienteRepository;
            _notifications = notifications;
        }
        public IHttpActionResult AddContaCliente(Conta conta)
        {
            _contaClienteRepository.AddContaCliente(conta);
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
        public IHttpActionResult GetConta(string conta, int agencia, string senha)
        {
            var contaClienteAlteracao = new ContaClienteAlteracao();
            contaClienteAlteracao = _contaClienteRepository.GetConta(conta, agencia, senha);
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
            _contaClienteRepository.UpdateConta(conta);
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
    }
}
