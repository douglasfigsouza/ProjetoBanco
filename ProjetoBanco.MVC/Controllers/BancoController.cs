using System.Web.Mvc;
using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.MVC.ViewModels;

namespace ProjetoBanco.MVC.Controllers
{
    public class BancoController : Controller
    {
        private readonly IBancoAppService _IBancoAppService;
        private Banco banco;
        public BancoController(IBancoAppService IBancoAppService)
        {
            _IBancoAppService = IBancoAppService;
            banco = new Banco();
        }
        public ActionResult CreateBanco()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBanco(BancoViewModel bancoViewModel)
        {
            if (ModelState.IsValid)
            {
                banco.nome = bancoViewModel.nome;
                banco.ativo = true;
                _IBancoAppService.AddBanco(banco);
                ViewBag.messagem = "Banco: " + bancoViewModel.nome + " cadastrado com sucesso!";
                return RedirectToAction("Index", "Success");
            }
            else
            {
                return View(bancoViewModel);
            }

        }
    }
}