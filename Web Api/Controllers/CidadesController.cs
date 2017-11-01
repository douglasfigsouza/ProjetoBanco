using ProjetoBanco.Domain.Cidades;
using ProjetoBanco.Domain.Entities;
using System.Collections.Generic;
using System.Web.Http;

namespace Web_Api.Controllers
{
    public class CidadesController : ApiController
    {
        private readonly ICidadeRepository _cidadeRepository;
        private readonly Notifications _notifications;

        public CidadesController(ICidadeRepository cidadeRepository, Notifications notifications)
        {
            _cidadeRepository = cidadeRepository;
            _notifications = notifications;
        }

        public IHttpActionResult GetCidadesByEstadoId(int id)
        {
            List<Cidade> cidades = new List<Cidade>(_cidadeRepository.GetCidadesByEstadoId(id));
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
                return Ok(cidades);
            }
        }
    }
}
