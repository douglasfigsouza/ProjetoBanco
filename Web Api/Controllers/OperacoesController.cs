using System.Web.Http;

using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Interfaces.IRepositories;

namespace Web_Api.Controllers
{
    public class OperacoesController : ApiController
    {
        private readonly IOperacoesRepositoryDomain _operacoesRepositoryDomain;

        public OperacoesController(IOperacoesRepositoryDomain operacoesRepositoryDomain)
        {
            _operacoesRepositoryDomain = operacoesRepositoryDomain;
        }

        public OperacoesController()
        {
            
        }
        [HttpPost]
        public IHttpActionResult AddOperacao(Operacoes op)
        {
            return Ok(_operacoesRepositoryDomain.AddOperacao(op));
        }
        public IHttpActionResult Get()
        {
            return Ok();
        }
    }
}