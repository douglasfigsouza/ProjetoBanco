using ProjetoBanco.Domain.Agencia;
using ProjetoBanco.Domain.Agencias;
using ProjetoBanco.Domain.Entities;
using System.Collections.Generic;
using System.Web.Http;

namespace Web_Api.Controllers
{
    public class AgenciasController : ApiController
    {
        private readonly IAgenciaService _agenciaService;
        private readonly Notifications _notifications;

        public AgenciasController(Notifications notifications, IAgenciaService agenciaService)
        {
            _notifications = notifications;
            _agenciaService = agenciaService;
        }

        public IHttpActionResult AddAgencia(AgenciaDto agencia)
        {
            _agenciaService.AddAgencia(agencia);
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
        public IHttpActionResult GetAgenciaByNum(int agencia)
        {
            var Agencia = new AgenciaDto();
            Agencia = _agenciaService.GetAgenciaByNum(agencia);
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
                return Ok(Agencia);
            }
        }
        public IHttpActionResult GetAllAgencias()
        {
            var agencias = new List<AgenciaDto>(_agenciaService.GetAllAgencias());
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
                return Ok(agencias);
            }
        }
        public IHttpActionResult UpdateAgencia(AgenciaDto agencia)
        {
            _agenciaService.UpdateAgencia(agencia);
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
