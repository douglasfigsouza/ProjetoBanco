using ProjetoBanco.Domain.Agencias;
using ProjetoBanco.Domain.Entities;
using System.Collections.Generic;
using System.Web.Http;

namespace Web_Api.Controllers
{
    public class AgenciasController : ApiController
    {
        private readonly IAgenciaRepository _agenciaRepository;
        private readonly Notifications _notifications;

        public AgenciasController(IAgenciaRepository agenciaRepository, Notifications notifications)
        {
            _agenciaRepository = agenciaRepository;
            _notifications = notifications;
        }

        public IHttpActionResult AddAgencia(Agencia agencia)
        {
            _agenciaRepository.AddAgencia(agencia);
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
            var Agencia = new Agencia();
            Agencia = _agenciaRepository.GetAgenciaByNum(agencia);
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
            var agencias = new List<Agencia>(_agenciaRepository.GetAllAgencias());
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
        public IHttpActionResult UpdateAgencia(Agencia agencia)
        {
            _agenciaRepository.UpdateAgencia(agencia);
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
