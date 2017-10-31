using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Estados;
using ProjetoBanco.Domain.Estados.Dto;
using System.Collections.Generic;
using System.Web.Http;

namespace Web_Api.Controllers
{
    public class EstadosController : ApiController
    {
        private readonly IEstadoRepository _estadoRepository;
        private readonly Notifications _notifications;

        public EstadosController(IEstadoRepository estadoRepository, Notifications notifications)
        {
            _estadoRepository = estadoRepository;
            _notifications = notifications;
        }
        public IHttpActionResult GetAllEstados()
        {
            List<Estado> estados = new List<Estado>(_estadoRepository.GetAllEstados());

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
    }
}
