using System.Web.Http;
using ProjetoBanco.Domain.Interfaces.IRepositories;

namespace Web_Api.Controllers
{
    public class OlaController : ApiController
    {
        private readonly IOlaRepository _olaRepository;

        public OlaController(IOlaRepository olaRepository)
        {
            _olaRepository = olaRepository;
        }

        public IHttpActionResult GetOlaMundo()
        {
            return Ok(_olaRepository.Ola());
        }
    }
}