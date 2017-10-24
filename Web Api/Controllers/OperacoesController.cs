using System.Web.Http;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Interfaces.IRepositories;
using ProjetoBanco.Domain.Operacoes;

namespace Web_Api.Controllers
{
    public class OperacoesController : ApiController
    {
        private readonly IOperacoesRepository _operacoesRepository;
        private readonly Notifications _notifications;

        public OperacoesController(IOperacoesRepository operacoesRepository, Notifications notifications)
        {
            _operacoesRepository = operacoesRepository;
            _notifications = notifications;
        
        }

        public IHttpActionResult AddOperacao(Operacoes op)
        {
            return Ok(_operacoesRepository.AddOperacao(op));
        }

        public IHttpActionResult VerificaDadosTransacao(Transacao transacao)
        {
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
                return Ok(_operacoesRepository.VerificaDadosTransacao(transacao));
            }
        }
    }
}
