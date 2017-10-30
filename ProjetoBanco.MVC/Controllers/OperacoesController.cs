﻿using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Operacoes.Dto;
using ProjetoBanco.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace ProjetoBanco.MVC.Controllers
{
    /*
        Códigos de Operações
        1 - Depósito
        2 - Saque
        3 - Saldo
        4 - Transferencia
        5 - Estorno
    */
    public class OperacoesController : Controller
    {
        private readonly IOperacoesAppService _OperacaoAppService;
        private readonly IOperacaoesRealizadasAppService _operacaoesRealizadasAppService;

        public OperacoesController(IOperacoesAppService OperacaoAppService, IOperacaoesRealizadasAppService operacaoesRealizadasAppService)
        {
            _OperacaoAppService = OperacaoAppService;
            _operacaoesRealizadasAppService = operacaoesRealizadasAppService;
        }

        // GET: Operacoes
        public ActionResult CreateOperacao()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateOperacao(OperacaoViewModel opViewModel)
        {
            var op = new Operacoes();
            var statusCode = new HttpResponseMessage();
            op.descricao = opViewModel.descricao;
            op.ativo = true;

            statusCode = _OperacaoAppService.AddOperacao(op);
            if (!statusCode.IsSuccessStatusCode)
            {
                Response.TrySkipIisCustomErrors = true;
                Response.StatusCode = 400;
                return Content(Utilitarios.Utilitarios.limpaMenssagemErro(statusCode.Content.ReadAsStringAsync().Result));

            }
            Response.StatusCode = 200;
            return Json(statusCode.Content.ReadAsStringAsync().Result);
        }

        public ActionResult Deposito()
        {
            TempData["operacao"] = 1;
            return View("Operacoes");
        }

        public ActionResult Saque()
        {
            TempData["operacao"] = 2;
            return View("Operacoes");
        }

        public ActionResult Saldo()
        {
            TempData["operacao"] = 3;
            return View("Operacoes");
        }

        public ActionResult Transferencia()
        {
            return View();
        }

        public ActionResult VerificaDados(TransacaoViewModel trasacaoViewModel)
        {
            var transacao = new Transacao();
            var statusCode = new HttpResponseMessage();
            Transacao transact;

            if (ModelState.IsValid)
            {
                Cliente cli = (Cliente)Session["cliente"];

                transacao.clienteId = cli.Id;
                var valor = decimal.Parse(Utilitarios.Utilitarios.retiraMaskMoney(trasacaoViewModel.valor));
                transacao.agencia = int.Parse(Utilitarios.Utilitarios.retiraMask(trasacaoViewModel.agencia));
                transacao.conta = Utilitarios.Utilitarios.retiraMask(trasacaoViewModel.conta);
                transacao.senhaCli = trasacaoViewModel.senhaCli;
                transacao.nivel = cli.nivel;
                transacao.op = trasacaoViewModel.op;

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

                statusCode = _OperacaoAppService.VerificaDadosTransacao(transacao);
                if (statusCode.IsSuccessStatusCode)
                {
                    transact = statusCode.Content.ReadAsAsync<Transacao>().Result;
                    //insere os valores na view no hidden
                    trasacaoViewModel.clienteId = transact.clienteId;
                    trasacaoViewModel.contaId = transact.contaId;
                    trasacaoViewModel.agencia = transact.agencia + "";
                    trasacaoViewModel.nome = transact.nome;
                    trasacaoViewModel.valor = valor + "";

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
            var statusCode = new HttpResponseMessage();

            var operacaoRealizada = new OperacoesRealizadas();
            operacaoRealizada.agencia = int.Parse(Utilitarios.Utilitarios.retiraMask(trasacaoViewModel.agencia));
            operacaoRealizada.clienteId = trasacaoViewModel.clienteId;
            operacaoRealizada.contaId = trasacaoViewModel.contaId;
            operacaoRealizada.dataOp = DateTime.Now;
            operacaoRealizada.valorOp = decimal.Parse(Utilitarios.Utilitarios.retiraMaskMoney(trasacaoViewModel.valor));

            TempData["menssagem"] = "Depósito Realizado com sucesso!";
            TempData["outraOp"] = "/Operacoes/Deposito";

            operacaoRealizada.operacaoId = 1;
            statusCode = _operacaoesRealizadasAppService.Deposito(operacaoRealizada);
            if (statusCode.IsSuccessStatusCode)
            {
                return View("FeedBackOp");
            }
            else
            {

                ViewBag.erro = Utilitarios.Utilitarios.limpaMenssagemErro(statusCode.Content.ReadAsStringAsync().Result);
                return View("FeedBackOp");
            }
        }
        [HttpPost]
        public ActionResult Saldo(TransacaoViewModel trasacaoViewModel)
        {
            var transacao = new Transacao();
            var statusCode = new HttpResponseMessage();

            Cliente cli = (Cliente)Session["cliente"];
            transacao.nivel = cli.nivel;
            transacao.senhaCli = trasacaoViewModel.senhaCli;
            transacao.clienteId = cli.Id;
            transacao.agencia = int.Parse(Utilitarios.Utilitarios.retiraMask(trasacaoViewModel.agencia));
            transacao.conta = Utilitarios.Utilitarios.retiraMask(trasacaoViewModel.conta);

            statusCode = _OperacaoAppService.ConsultaSaldo(transacao);
            if (!statusCode.IsSuccessStatusCode)
            {
                Response.TrySkipIisCustomErrors = true;
                Response.StatusCode = 400;
                return Content(Utilitarios.Utilitarios.limpaMenssagemErro(statusCode.Content.ReadAsStringAsync().Result));

            }
            Response.StatusCode = 200;
            return Json(statusCode.Content.ReadAsAsync<TransacaoViewModel>().Result);
        }
        //confirma os dados do saque
        public ActionResult ConfirmSaque(TransacaoViewModel trasacaoViewModel)
        {
            var statusCode = new HttpResponseMessage();
            var operacaoRealizada = new OperacoesRealizadas();

            operacaoRealizada.agencia = int.Parse(Utilitarios.Utilitarios.retiraMask(trasacaoViewModel.agencia));
            operacaoRealizada.clienteId = trasacaoViewModel.clienteId;
            operacaoRealizada.contaId = trasacaoViewModel.contaId;
            operacaoRealizada.dataOp = DateTime.Now;
            operacaoRealizada.valorOp = decimal.Parse(Utilitarios.Utilitarios.retiraMaskMoney(trasacaoViewModel.valor));
            operacaoRealizada.operacaoId = 2;

            statusCode = _operacaoesRealizadasAppService.Saque(operacaoRealizada);
            if (statusCode.IsSuccessStatusCode)
            {
                TempData["menssagem"] = "Saque realizado com sucesso!";
                TempData["outraOp"] = "/Operacoes/Saque";
                return View("FeedBackOp");
            }
            else
            {
                TempData["menssagem"] = Utilitarios.Utilitarios.limpaMenssagemErro(statusCode.Content.ReadAsStringAsync().Result);
                TempData["outraOp"] = "/Operacoes/Saque";
                return View("FeedBackOp");
            }

        }
        [HttpPost]
        public ActionResult Transferencia(FormCollection transacao)
        {
            var lstTransacoesViewModels = new List<TransacaoViewModel>();
            var statusCode = new HttpResponseMessage();

            Cliente cli = (Cliente)Session["cliente"];

            Transacao transacao1 = new Transacao
            {
                nivel = cli.nivel,
                senhaCli = transacao["senha"],
                agencia = int.Parse(Utilitarios.Utilitarios.retiraMask(transacao["agenciaCont1"])),
                conta = Utilitarios.Utilitarios.retiraMask(transacao["numCont1"]),
                clienteId = cli.Id,
                op = 2
            };
            Transacao transacao2 = new Transacao
            {
                agencia = int.Parse(Utilitarios.Utilitarios.retiraMask(transacao["agenciaCont2"])),
                conta = Utilitarios.Utilitarios.retiraMask(transacao["numCont2"]),
                clienteId = cli.Id
            };
            //garante que a primeira conta é a sua própria, para impedir que tranferencia entre conta de terceiros
            statusCode = _OperacaoAppService.VerificaDadosTransacao(transacao1);
            transacao1 = statusCode.Content.ReadAsAsync<Transacao>().Result;
            statusCode = _OperacaoAppService.VerificaDadosTransferencia(transacao2);

            if (statusCode.IsSuccessStatusCode)
            {
                transacao2 = statusCode.Content.ReadAsAsync<Transacao>().Result;

                TransacaoViewModel transacao1ViewModel = new TransacaoViewModel();
                //insere os valores na view no hidden
                transacao1ViewModel.clienteId = transacao1.clienteId;
                transacao1ViewModel.contaId = transacao1.contaId;
                transacao1ViewModel.agencia = transacao1.agencia + "";
                transacao1ViewModel.nome = transacao1.nome;
                transacao1ViewModel.valor = transacao["valor"];

                if (transacao2.nome != null)
                {
                    TransacaoViewModel transacao2ViewModel = new TransacaoViewModel();
                    transacao2ViewModel.clienteId = transacao2.clienteId;
                    transacao2ViewModel.contaId = transacao2.contaId;
                    transacao2ViewModel.agencia = transacao2.agencia + "";
                    transacao2ViewModel.nome = transacao2.nome;
                    transacao2ViewModel.valor = transacao["valor"];
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
            var operacaoRealizada = new OperacoesRealizadas();
            var operacaoRealizada1 = new OperacoesRealizadas();
            var statusCode = new HttpResponseMessage();

            operacaoRealizada.agencia = int.Parse(Transacoes[0].agencia);
            operacaoRealizada.clienteId = Transacoes[0].clienteId;
            operacaoRealizada.contaId = Transacoes[0].contaId;
            operacaoRealizada.dataOp = DateTime.Now;
            operacaoRealizada.valorOp = decimal.Parse(Utilitarios.Utilitarios.retiraMaskMoney(Transacoes[0].valor));
            operacaoRealizada1.agencia = int.Parse(Transacoes[1].agencia);
            operacaoRealizada1.clienteId = Transacoes[1].clienteId;
            operacaoRealizada1.contaId = Transacoes[1].contaId;
            operacaoRealizada1.dataOp = DateTime.Now;

            List<OperacoesRealizadas> operacoes = new List<OperacoesRealizadas>();
            operacoes.Add(operacaoRealizada);
            operacoes.Add(operacaoRealizada1);

            statusCode = _operacaoesRealizadasAppService.Transferencia(operacoes);
            if (statusCode.IsSuccessStatusCode)
            {

                TempData["menssagem"] = "Tranferência realizada com sucesso!";
            }
            else
            {
                TempData["menssagem"] = Utilitarios.Utilitarios.limpaMenssagemErro(statusCode.Content.ReadAsStringAsync().Result);
            }

            TempData["outraOp"] = "/Operacoes/Transferencia";
            return View("FeedBackOp");

        }

        public ActionResult DadosParaEstorno()
        {
            return View("Estorno");

        }

        public ActionResult Estorno(FormCollection form)
        {
            var dadosOpGetReal = new DadosGetOpReal();
            var statusCode = new HttpResponseMessage();
            List<EstornoViewModel> opsEstornoViewModels = new List<EstornoViewModel>();

            dadosOpGetReal.conta = Utilitarios.Utilitarios.retiraMask(form["conta"]);
            dadosOpGetReal.senha = Utilitarios.Utilitarios.retiraMask(form["senha"]);
            dadosOpGetReal.agencia = int.Parse(Utilitarios.Utilitarios.retiraMask(form["agencia"]));

            statusCode = _operacaoesRealizadasAppService.GetAllOperacoesPorContaParaEstorno(dadosOpGetReal);
            if (statusCode.IsSuccessStatusCode)
            {
                foreach (var op in statusCode.Content.ReadAsAsync<IEnumerable<Estorno>>().Result)
                {
                    opsEstornoViewModels.Add(new EstornoViewModel
                    {
                        Id = op.Id,
                        opId = op.opId,
                        cliente = op.cliente,
                        agencia = op.agencia,
                        conta = op.conta,
                        saldoAnterior = op.saldoAnterior,
                        valorOp = op.valorOp,
                        dataOp = op.dataOp,
                        descricao = op.descricao
                    });
                }
                if (opsEstornoViewModels == null || opsEstornoViewModels.Count == 0)
                {
                    TempData["menssagem"] = "Estorno não realizado! Alguns dos dados fornecidos podem ser inválidos.";
                    TempData["outraOp"] = "/Operacoes/DadosParaEstorno";
                    return View("FeedBackOp");
                }
                else
                {
                    return View("OpRealizadasEstorno", opsEstornoViewModels);
                }
            }
            else
            {
                TempData["menssagem"] =
                    Utilitarios.Utilitarios.limpaMenssagemErro(statusCode.Content.ReadAsStringAsync().Result);
                TempData["outraOp"] = "/Operacoes/DadosParaEstorno";
                return View("FeedBackOp");
            }
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult ConfirmEstorno(int id)
        {
            var statusCode = new HttpResponseMessage();
            var estorno = new Estorno
            {
                Id = id
            };
            statusCode = _operacaoesRealizadasAppService.ConfirmEstorno(estorno);
            if (statusCode.IsSuccessStatusCode)
            {
                TempData["menssagem"] = "Estorno realizado com sucesso!";
                TempData["outraOp"] = "/Operacoes/Estorno";
                return View("FeedBackOp");
            }
            else
            {
                TempData["menssagem"] = Utilitarios.Utilitarios.limpaMenssagemErro(statusCode.Content.ReadAsStringAsync().Result);
                TempData["outraOp"] = "/Operacoes/Estorno";
                return View("FeedBackOp");
            }
        }
        [HttpGet]
        public JsonResult GetOpRealizadaEstornoById(int id)
        {
            var statusCode = new HttpResponseMessage();
            if (statusCode.IsSuccessStatusCode)
            {
                statusCode = _operacaoesRealizadasAppService.GetOpRealizadaEstornoById(id);
                return Json(statusCode.Content.ReadAsAsync<Estorno>().Result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(statusCode.Content.ReadAsStringAsync().Result);
            }
        }
    }
}
