using ProjetoBanco.Domain.Conta;
using ProjetoBanco.Domain.Contas;
using ProjetoBanco.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Web_Api.Controllers
{
    public class ContaClienteController : ApiController
    {
        private readonly IContaClienteService _contaClienteService;
        private readonly IContaClienteRepository _contaClienteRepository;
        private readonly Notifications _notifications;

        public ContaClienteController(Notifications notifications, IContaClienteService iContaClienteService, IContaClienteRepository contaClienteRepository)
        {
            _notifications = notifications;
            _contaClienteService = iContaClienteService;
            _contaClienteRepository = contaClienteRepository;
        }
        public IHttpActionResult PostContaCliente(Conta conta)
        {
            try
            {
                _contaClienteRepository.PostContaCliente(conta);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Ops! algo deu errado! Erro: {e.Message}");
            }
        }
        public IHttpActionResult GetConta(int contaId)
        {
            try
            {
                var contaClienteAlteracao = new ContaClienteAlteracao();
                contaClienteAlteracao = _contaClienteService.GetConta(contaId);
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
            catch (Exception e)
            {
                return BadRequest($"Ops! algo deu errado! Erro: {e.Message}");
            }
        }
        public IHttpActionResult PutConta(Conta conta)
        {
            try
            {
                _contaClienteRepository.PutConta(conta);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Ops! algo deu errado! Erro: {e.Message}");
            }

        }
        public IHttpActionResult GetAllDadosEClientesDaConta()
        {
            try
            {
                var contas = new List<ContaCliente>(_contaClienteRepository.GetAllDadosEClientesDaConta());
                return Ok(contas);
            }
            catch (Exception e)
            {
                return BadRequest($"Ops! algo deu errado! Erro: {e.Message}");
            }
        }

    }
}

