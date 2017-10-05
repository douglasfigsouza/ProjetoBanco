using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.MVC.ViewModels;

namespace ProjetoBanco.MVC.Controllers
{
    /*
        Códigos de Operações
        0 - Depósito
        1 - Saque 
        2 - Saldo
    */
    public class OperacoesController : Controller
    {
        private readonly IOperacoesAppService _OperacaoAppService;
        private Operacoes op;

        public OperacoesController(IOperacoesAppService OperacaoAppService)
        {
            _OperacaoAppService = OperacaoAppService;
            op = new Operacoes();
        }
        // GET: Operacoes
        public ActionResult CreateOperacao()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateOperacao(OperacaoViewModel opViewModel)
        {
            if (ModelState.IsValid)
            {
                op.descricao = opViewModel.descricao;
                _OperacaoAppService.AddOperacao(op);
                return RedirectToAction("Success", "Index");
            }
            else
            {
                return View(opViewModel);
            }
        }

        public ActionResult Deposito()
        {
            ViewBag.cliente = (Cliente) Session["cliente"];
            TempData["operacao"] = 0;
            return View("Operacoes");
        }
        public ActionResult VerificaDadosDeposito(FormCollection form)
        {
            
        }
        public ActionResult Saldo()
        {
            ViewBag.cliente = (Cliente)Session["cliente"];
            TempData["operacao"] = 2;
            return View("Operacoes");
        }
    }
}