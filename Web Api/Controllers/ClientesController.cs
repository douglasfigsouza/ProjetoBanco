using ProjetoBanco.Domain.Clientes;
using ProjetoBanco.Domain.Entities;
using System.Collections.Generic;
using System.Web.Http;

namespace Web_Api.Controllers
{
    public class ClientesController : ApiController
    {
        private readonly IClienteService _clienteService;
        private readonly Notifications _notifications;
        public ClientesController(Notifications notifications, IClienteService clienteService)
        {
            _notifications = notifications;
            _clienteService = clienteService;
        }
        public IHttpActionResult AddCliente(Cliente cliente)
        {
            _clienteService.AddCliente(cliente);
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
        public IHttpActionResult GetAllClientes(int op)
        {
            IEnumerable<Cliente> clientes = new List<Cliente>();
            clientes = _clienteService.GetAllClientes(op);
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
                return Ok(clientes);
            }
        }
        public IHttpActionResult UpdateCliente(Cliente cliente)
        {
            _clienteService.UpdateClientes(cliente);
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
        public IHttpActionResult GetByClienteId(int id)
        {
            var cliente = new Cliente();
            cliente = _clienteService.GetByClienteId(id);

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
                return Ok(cliente);
            }
        }
        public IHttpActionResult GetClienteByCpf(string cpf)
        {
            var cliente = new Cliente();
            cliente = _clienteService.GetClienteByCpf(cpf);

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
                return Ok(cliente);
            }
        }
    }
}
