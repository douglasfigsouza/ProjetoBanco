using System.Web.Http;
using ProjetoBanco.Domain.Interfaces.IRepositories;

namespace Web_Api.Controllers
{
    public class Operacoes2Controller : ApiController
    {
        private readonly IOperacoesRepository _operacoesRepository;

        public Operacoes2Controller(IOperacoesRepository operacoesRepository)
        {
            _operacoesRepository = operacoesRepository;
        }

        public IHttpActionResult GetAll()
        {
            return Ok();
        }
    }
}