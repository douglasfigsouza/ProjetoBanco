using System.Web.Mvc;
using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.MVC.ViewModels;

namespace ProjetoBanco.MVC.Controllers
{
    public class BancoController : Controller
    {
        private readonly IBancoAppService _bancoAppServiceancoAppService;
        private Banco banco;
        private string error;
        public BancoController(IBancoAppService bancoAppService)
        {
            _bancoAppServiceancoAppService = bancoAppService;
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
                error = _bancoAppServiceancoAppService.AddBanco(banco);
                if (error == null)
                {
                    TempData["outraOp"] = "/Banco/CreateBanco";
                    TempData["menssagem"] = "Banco: " + bancoViewModel.nome + " cadastrado com sucesso!";
                    return RedirectToAction("Success", "FeedBack");
                }
                else
                {
                    TempData["outraOp"] = "/Banco/CreateBanco";
                    TempData["menssagem"] = "Banco: " + bancoViewModel.nome + " Não cadastrado! Erro: " + error;
                    return RedirectToAction("Error", "FeedBack");
                }
            }
            else
            {
                return View(bancoViewModel);
            }

        }
    }
}