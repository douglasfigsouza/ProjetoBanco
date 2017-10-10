using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.MVC.ViewModels;

namespace ProjetoBanco.MVC.Controllers
{
    /*
        Códigos de Operações
        1 - Depósito
        2 - Saque
        3 - Saldo
        4 - Transferencia
    */
    public class OperacoesController : Controller
    {
        private readonly IOperacoesAppService _OperacaoAppService;
        private readonly IOperacaoesRealizadasAppService _operacaoesRealizadasAppService;
        private OperacaoRealizada operacaoRealizada;
        private OperacaoRealizada operacaoRealizada1;
        private Operacoes op;
        private Transacao transacao;
        private List<TransacaoViewModel> lstTransacoesViewModels;
        private decimal valor;


        public OperacoesController(IOperacoesAppService OperacaoAppService, IOperacaoesRealizadasAppService operacaoesRealizadasAppService)
        {
            _OperacaoAppService = OperacaoAppService;
            _operacaoesRealizadasAppService = operacaoesRealizadasAppService;
            operacaoRealizada = new OperacaoRealizada();
            operacaoRealizada1 = new OperacaoRealizada();
            transacao = new Transacao();
            lstTransacoesViewModels = new List<TransacaoViewModel>();
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
                ViewBag.messagem = "Operação: " + opViewModel.descricao + " cadastrada com sucesso!";
                return RedirectToAction("Index", "Success");
            }
            else
            {
                return View(opViewModel);
            }
        }

        public ActionResult Deposito()
        {
            ViewBag.cliente = (Cliente)Session["cliente"];
            TempData["operacao"] = 1;
            return View("Operacoes");
        }
        public ActionResult Saque()
        {
            TempData["operacao"] = 2;
            ViewBag.cliente = (Cliente)Session["cliente"];
            return View("Operacoes");
        }
        public ActionResult Saldo()
        {
            ViewBag.cliente = (Cliente)Session["cliente"];
            TempData["operacao"] = 3;
            return View("Operacoes");
        }

        public ActionResult Transferencia()
        {
            return View();
        }

        public ActionResult VerificaDados(TransacaoViewModel trasacaoViewModel)
        {
            if (ModelState.IsValid)
            {
                Cliente cli = (Cliente)Session["cliente"];

                transacao.clienteId = cli.Id;
                valor = trasacaoViewModel.valor;
                transacao.agencia = trasacaoViewModel.agencia;
                transacao.conta = trasacaoViewModel.conta;
                transacao.senhaCli = trasacaoViewModel.senhaCli;
                transacao.nivel = cli.nivel;

                if (trasacaoViewModel.op == 1)
                {
                    ViewBag.descOp = "Depósito";
                    ViewBag.operacao = 1;
                }
                else if (trasacaoViewModel.op == 2)
                {
                    ViewBag.descOp = "Saque";
                    ViewBag.operacao = 2;
                }

                transacao = _OperacaoAppService.VerificaDadosTransacao(transacao,trasacaoViewModel.op);
                if (transacao.nome != null)
                {
                    //insere os valores na view no hidden
                    trasacaoViewModel.clienteId = transacao.clienteId;
                    trasacaoViewModel.contaId = transacao.contaId;
                    trasacaoViewModel.agencia = transacao.agencia;
                    trasacaoViewModel.nome = transacao.nome;
                    trasacaoViewModel.valor = valor;

                    return View("Confirmacao", trasacaoViewModel);
                }
                else
                {
                    ViewBag.erroTransacao = "Trasação nao pode ser realizada, pois nao foi possivel localizar uma conta com os dados informado";
                    return View("Confirmacao");
                }

            }
            else
            {
                return View("Deposito", trasacaoViewModel);
            }
        }
        //confirma os dados do deposito
        public ActionResult ConfirmDeposito(TransacaoViewModel trasacaoViewModel)
        {
            operacaoRealizada.agencia = trasacaoViewModel.agencia;
            operacaoRealizada.clienteId = trasacaoViewModel.clienteId;
            operacaoRealizada.contaId = trasacaoViewModel.contaId;
            operacaoRealizada.dataOp = DateTime.Now;
            operacaoRealizada.valorOp = trasacaoViewModel.valor;


            _operacaoesRealizadasAppService.Deposito(operacaoRealizada, 1);
            return View();
        }

        public ActionResult ConsultaSaldo(TransacaoViewModel trasacaoViewModel)
        {
            Cliente cli = (Cliente)Session["cliente"];
            transacao.nivel = cli.nivel;
            transacao.senhaCli = trasacaoViewModel.senhaCli;
            transacao.clienteId = cli.Id;
            transacao.agencia = trasacaoViewModel.agencia;
            transacao.conta = trasacaoViewModel.conta;
            if (_OperacaoAppService.ConsultaSaldo(transacao) == null)
            {
                ViewBag.erro ="Conta não encontrada!" ;
                return View("MostraSaldo");
            }
            else
            {
                ViewBag.saldo = _OperacaoAppService.ConsultaSaldo(transacao);
                return View("MostraSaldo");
            }

        }
        //confirma os dados do saque
        public ActionResult ConfirmSaque(TransacaoViewModel trasacaoViewModel)
        {
            operacaoRealizada.agencia = trasacaoViewModel.agencia;
            operacaoRealizada.clienteId = trasacaoViewModel.clienteId;
            operacaoRealizada.contaId = trasacaoViewModel.contaId;
            operacaoRealizada.dataOp = DateTime.Now;
            operacaoRealizada.valorOp = trasacaoViewModel.valor;


            TempData["menssagem"] = _operacaoesRealizadasAppService.Saque(operacaoRealizada, 2);
            return RedirectToAction("Index", "Success");
        }
        [HttpPost]
        public ActionResult Transferencia(TransacaoViewModel transacaoConta1, TransacaoViewModel transacaoConta2)
        {
            Cliente cli = (Cliente)Session["cliente"];
            Transacao transacao1 = new Transacao
            {
                nivel = cli.nivel,
                senhaCli = transacaoConta1.senhaCli,
                agencia = transacaoConta1.agencia,
                conta = transacaoConta1.conta,
                clienteId = cli.Id
            };
            Transacao transacao2 = new Transacao
            {
                agencia = transacaoConta2.agencia,
                conta = transacaoConta2.conta,
                clienteId = cli.Id
            };
            //garante que a primeira conta é a sua própria, para impedir que tranferencia entre conta de terceiros
            transacao1 = _OperacaoAppService.VerificaDadosTransacao(transacao1,2);
            transacao2 = _OperacaoAppService.VerificaDadosTransferencia(transacao2);
            if (transacao1.nome != null)
            {
                TransacaoViewModel transacao1ViewModel = new TransacaoViewModel();
                //insere os valores na view no hidden
                transacao1ViewModel.clienteId = transacao1.clienteId;
                transacao1ViewModel.contaId = transacao1.contaId;
                transacao1ViewModel.agencia = transacao1.agencia;
                transacao1ViewModel.nome = transacao1.nome;
                transacao1ViewModel.valor = transacaoConta1.valor;

                if (transacao2.nome != null)
                {
                    TransacaoViewModel transacao2ViewModel = new TransacaoViewModel();
                    transacao2ViewModel.clienteId = transacao2.clienteId;
                    transacao2ViewModel.contaId = transacao2.contaId;
                    transacao2ViewModel.agencia = transacao2.agencia;
                    transacao2ViewModel.nome = transacao2.nome;
                    transacao2ViewModel.valor = transacaoConta2.valor;
                    lstTransacoesViewModels.Add(transacao1ViewModel);
                    lstTransacoesViewModels.Add(transacao2ViewModel);
                    if (transacao1ViewModel.contaId == transacao2ViewModel.contaId)
                    {
                        ViewBag.erroTransacao = "Trasação nao pode ser realizada, pois não é possivel fazer tranferencia para você mesmo! Use a opção de depósito.";
                        return View("ConfirmTransferencia");
                    }
                    else
                    {
                        return View("ConfirmTransferencia", lstTransacoesViewModels);
                    }
                }
                else
                {
                    ViewBag.erroTransacao = "Trasação nao pode ser realizada, pois nao foi possivel localizar uma conta com os dados informado";
                    return View("ConfirmTransferencia");
                }

            }
            else
            {
                ViewBag.erroTransacao = "Trasação nao pode ser realizada, pois nao foi possivel localizar uma conta com os dados informado";
                return View("ConfirmTransferencia");
            }
        }

        public ActionResult ConfirmTransferencia(List<TransacaoViewModel> Transacoes)
        {


            operacaoRealizada.agencia = Transacoes[0].agencia;
            operacaoRealizada.clienteId = Transacoes[0].clienteId;
            operacaoRealizada.contaId = Transacoes[0].contaId;
            operacaoRealizada.dataOp = DateTime.Now;
            operacaoRealizada.valorOp = Transacoes[0].valor;

            operacaoRealizada1.agencia = Transacoes[1].agencia;
            operacaoRealizada1.clienteId = Transacoes[1].clienteId;
            operacaoRealizada1.contaId = Transacoes[1].contaId;
            operacaoRealizada1.dataOp = DateTime.Now;

            TempData["menssagem"] = _operacaoesRealizadasAppService.Transferencia(operacaoRealizada, operacaoRealizada1);

            return RedirectToAction("Index", "Success");

        }
    }
}
