using ProjetoBanco.Domain.Agencia;
using ProjetoBanco.Domain.Agencias;
using ProjetoBanco.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Web_Api.Controllers
{
    public class AgenciasController : ApiController
    {
        private readonly IAgenciaService _agenciaService;
        IAgenciaRepository _agenciaRepository;
        private readonly Notifications _notifications;

        public AgenciasController(Notifications notifications, IAgenciaService agenciaService, IAgenciaRepository agenciaRepository)
        {
            _notifications = notifications;
            _agenciaService = agenciaService;
            _agenciaRepository = agenciaRepository;
        }

        public IHttpActionResult AddAgencia(AgenciaDto agencia)
        {
            try
            {
                _agenciaRepository.PostAgencia(agencia);
            }
            catch (Exception e)
            {
                return BadRequest($"Ops! algo deu errado! Erro: {e.Message}");
            }
            return Ok();
        }
        public IHttpActionResult GetAgenciaByNum(int agencia)
        {
            var Agencia = new AgenciaDto();
            try
            {
                Agencia = _agenciaService.GetAgenciaByNum(agencia);
            }
            catch (Exception e)
            {
                return BadRequest($"Ops! algo de errado! Erro:{e.Message}");
            }
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
            List<AgenciaDto> agencias;
            try
            {
                agencias = new List<AgenciaDto>(_agenciaRepository.GetAllAgencias());
            }
            catch (Exception e)
            {
                return BadRequest($"Ops! algo de errado! Erro:{e.Message}");
            }
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
            try
            {
                _agenciaRepository.PutAgencia(agencia);
            }
            catch (Exception e)
            {
                return BadRequest($"Ops! algo de errado! Erro:{e.Message}");
            }
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
