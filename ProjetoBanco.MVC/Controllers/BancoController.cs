using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Bancos;
using ProjetoBanco.MVC.ViewModels;
using System.Net.Http;
using System.Web.Mvc;

namespace ProjetoBanco.MVC.Controllers
{
    public class BancoController : Controller
    {
        private readonly IBancoAppService _bancoAppService;
        public BancoController(IBancoAppService bancoAppService)
        {
            _bancoAppService = bancoAppService;
        }
        public ActionResult CreateBanco()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBanco(BancoViewModel bancoViewModel)
        {
            var banco = new Banco
            {
                nome = bancoViewModel.nome,
                ativo = true,
            };
            var statusCode = new HttpResponseMessage();
            statusCode = _bancoAppService.AddBanco(banco);
            if (!statusCode.IsSuccessStatusCode)
            {
                Response.TrySkipIisCustomErrors = true;
                Response.StatusCode = 400;
                return Content(
                    Utilitarios.Utilitarios.limpaMenssagemErro(statusCode.
                                Content.ReadAsStringAsync().Result));
            }
            Response.StatusCode = 200;
            return Content(statusCode.Content.ReadAsStringAsync().Result);
        }
    }
}
