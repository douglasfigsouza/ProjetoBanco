using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Estados;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Web_Api.Controllers
{
    public class EstadosController : ApiController
    {
        private readonly IEstadoService _estadoService;
        private readonly Notifications _notifications;

        public EstadosController(Notifications notifications, IEstadoService estadoService)
        {
            _notifications = notifications;
            _estadoService = estadoService;
        }
        public IHttpActionResult GetAllEstados()
        {
            try
            {
                List<Estado> estados = new List<Estado>(_estadoService.GetAllEstados());

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
                    return Ok(estados);
                }
            }
            catch (Exception e)
            {
                return BadRequest($"Ops! algo deu errado. Erro :{e.Message}");
            }
        }
    }
}
