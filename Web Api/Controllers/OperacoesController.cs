using System.Web.Http;
using ProjetoBanco.Domain.Interfaces.IRepositories;

namespace Web_Api.Controllers
{
    public class OperacoesController : ApiController
    {
        private readonly IOperacoesRepository _operacoesRepository;

        public OperacoesController(IOperacoesRepository operacoesRepository)
        {
            _operacoesRepository = operacoesRepository;
        }

        public IHttpActionResult AddOperacao()
        {
            return Ok();
        }
    }
}
