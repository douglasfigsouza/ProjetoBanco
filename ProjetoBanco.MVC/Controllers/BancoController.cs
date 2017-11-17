using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Bancos;
using ProjetoBanco.MVC.ViewModels;
using System;
using System.Net.Http;
using System.Web.Mvc;

namespace ProjetoBanco.MVC.Controllers
{
    [Authorize]
    public class BancoController : Controller
    {
        private readonly IBancoAppService _bancoAppService;
        public BancoController(IBancoAppService bancoAppService)
        {
            _bancoAppService = bancoAppService;
        }
        public ActionResult CadastraBanco()
        {
            return View("PostBanco");
        }

        [HttpPost]
        public ActionResult PostBanco(BancoViewModel bancoViewModel)
        {
            try
            {
                var banco = new Banco
                {
                    nome = bancoViewModel.nome,
                    ativo = true,
                };
                var statusCode = new HttpResponseMessage();
                statusCode = _bancoAppService.PostBanco(banco);
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
            catch (Exception e)
            {
                ViewBag.erros = $"Ops! algo deu errado. Erro {e.Message}";
                return View();
            }
        }
    }
}
