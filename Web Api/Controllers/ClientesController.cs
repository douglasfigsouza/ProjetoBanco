using ProjetoBanco.Domain.Clientes;
using ProjetoBanco.Domain.Clientes.Dto;
using ProjetoBanco.Domain.Entities;
using System.Collections.Generic;
using System.Web.Http;

namespace Web_Api.Controllers
{
    public class ClientesController : ApiController
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly Notifications _notifications;
        public ClientesController(IClienteRepository clienteRepository, Notifications notifications)
        {
            _clienteRepository = clienteRepository;
            _notifications = notifications;
        }
        public IHttpActionResult AddCliente(Cliente cliente)
        {
            _clienteRepository.AddCliente(cliente);
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
            clientes = _clienteRepository.GetAllClientes(op);
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
            _clienteRepository.UpdateClientes(cliente);
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
            cliente = _clienteRepository.GetByClienteId(id);

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
            cliente = _clienteRepository.GetClienteByCpf(cpf);

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
