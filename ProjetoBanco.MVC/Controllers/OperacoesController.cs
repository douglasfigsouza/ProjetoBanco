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
        1 - Depósito
        2 - Saldo
        3 - Saque
    */
    public class OperacoesController : Controller
    {
        private readonly IOperacoesAppService _OperacaoAppService;
        private readonly IOperacaoesRealizadasAppService _operacaoesRealizadasAppService;
        private OperacaoRealizada operacaoRealizada;
        private Operacoes op;
        private Transacao transacao;
        private decimal valor;

        public OperacoesController(IOperacoesAppService OperacaoAppService, IOperacaoesRealizadasAppService operacaoesRealizadasAppService)
        {
            _OperacaoAppService = OperacaoAppService;
            _operacaoesRealizadasAppService = operacaoesRealizadasAppService;
            operacaoRealizada = new OperacaoRealizada();
            transacao = new Transacao();
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
            TempData["operacao"] = 1;
            return View("Operacoes");
        }
        public ActionResult VerificaDadosDeposito(TrasacaoViewModel trasacaoViewModel)
        {
            if (ModelState.IsValid)
            {
                Cliente cli = (Cliente)Session["cliente"];

                transacao.clienteId = cli.Id;
                valor = trasacaoViewModel.valor;
                transacao.agencia = trasacaoViewModel.agencia;
                transacao.conta = trasacaoViewModel.conta;


                transacao =_OperacaoAppService.VerificaDadosDeposito(transacao);
                if (transacao != null)
                {
                    //insere os valores na view no hidden
                    trasacaoViewModel.clienteId = transacao.clienteId;
                    trasacaoViewModel.contaId = transacao.contaId;
                    trasacaoViewModel.agencia= transacao.agencia;
                    trasacaoViewModel.nome = transacao.nome;
                    trasacaoViewModel.valor = valor;
                    return View("Confirmacao",trasacaoViewModel);
                }
                else
                {
                    ViewBag.erroTrasacao ="Trasação nao pode ser realizada, pois nao foi possivel localizar uma conta com os dados informado";
                    return View("Confirmacao");
                }

            }
            else
            {
                return View("Deposito",trasacaoViewModel);
            }
        }

        public ActionResult ConfirmTrasacao(TrasacaoViewModel trasacaoViewModel)
        {
            operacaoRealizada.agencia = trasacaoViewModel.agencia;
            operacaoRealizada.clienteId = trasacaoViewModel.clienteId;
            operacaoRealizada.contaId = trasacaoViewModel.contaId;
            operacaoRealizada.dataOp=DateTime.Now;
            operacaoRealizada.valorOp = trasacaoViewModel.valor;
            _operacaoesRealizadasAppService.AddOpRealizada(operacaoRealizada,1);
            return View();
        }
        public ActionResult Saldo()
        {
            ViewBag.cliente = (Cliente)Session["cliente"];
            TempData["operacao"] = 2;
            return View("Operacoes");
        }

        public ActionResult ConsultaSaldo(TrasacaoViewModel trasacaoViewModel)
        {
            Cliente cli = (Cliente)Session["cliente"];
            transacao.clienteId = cli.Id;
            transacao.agencia = trasacaoViewModel.agencia;
            transacao.conta = trasacaoViewModel.conta;
            ViewBag.saldo = _OperacaoAppService.ConsultaSaldo(transacao);
            return View("MostraSaldo");
        }
    }
}