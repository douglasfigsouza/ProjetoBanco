using ProjetoBanco.Domain.Clientes;
using ProjetoBanco.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Web_Api.Controllers
{
    public class ClientesController : ApiController
    {
        private readonly IClienteService _clienteService;
        private readonly IClienteRepository _clienteRepository;
        private readonly Notifications _notifications;
        public ClientesController(Notifications notifications, IClienteService clienteService, IClienteRepository clienteRepository)
        {
            _notifications = notifications;
            _clienteService = clienteService;
            _clienteRepository = clienteRepository;
        }
        public IHttpActionResult PostCliente(ClienteDto cliente)
        {
            try
            {
                _clienteRepository.PostCliente(cliente);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Ops! algo deu errado! Erro: {e.Message}");
            }

        }
        public IHttpActionResult GetAllClientes(int op)
        {
            try
            {
                var clientes = new List<ClienteDto>(_clienteRepository.GetAllClientes(op));
                return Ok(clientes);

            }
            catch (Exception e)
            {
                return BadRequest($"Ops! algo deu errado! Erro: {e.Message}");
            }
        }
        public IHttpActionResult PutCliente(ClienteDto cliente)
        {
            try
            {
                _clienteRepository.PutClientes(cliente);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Ops! algo deu errado! Erro: {e.Message}");
            }

        }
        public IHttpActionResult GetByClienteId(int id)
        {
            try
            {
                var cliente = new ClienteDto();
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
            catch (Exception e)
            {
                return BadRequest($"Ops! algo deu errado! Erro: {e.Message}");
            }
        }
        public IHttpActionResult GetClienteByCpf(string cpf)
        {
            try
            {
                var cliente = new ClienteDto();
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
            catch (Exception e)
            {
                return BadRequest($"Ops! algo deu errado! Erro: {e.Message}");
            }
        }
    }
}
