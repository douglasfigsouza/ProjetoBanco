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
    }
}