using ProjetoBanco.Domain.Clientes;
using ProjetoBanco.Domain.Clientes.Dto;
using ProjetoBanco.Domain.Entities;
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

    }
}
