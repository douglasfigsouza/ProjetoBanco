using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Operacoes;
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
    [Authorize]
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

        public ActionResult VerificaDados(TransacaoViewModel transacaoViewModel)
        {
            var transacao = new Transacao();
            var statusCode = new HttpResponseMessage();
            ClienteViewModel cli = (ClienteViewModel)Session["cliente"];

            transacao.agencia = int.Parse(Utilitarios.Utilitarios.retiraMask(transacaoViewModel.agencia));
            transacao.conta = Utilitarios.Utilitarios.retiraMask(transacaoViewModel.conta);
            transacao.senhaCli = transacaoViewModel.senhaCli;
            transacao.nivel = cli.nivel;
            transacao.op = transacaoViewModel.op;
            transacao.valor = decimal.Parse(Utilitarios.Utilitarios.retiraMaskMoney(transacaoViewModel.valor));

            if (transacaoViewModel.op == 1)
            {
                ViewBag.descOp = "Depósito";
                ViewBag.operacao = 1;
            }
            else if (transacaoViewModel.op == 2)
            {
                ViewBag.descOp = "Saque";
                ViewBag.operacao = 2;
                transacao.clienteId = cli.Id;
            }

            statusCode = _OperacaoAppService.VerificaDadosTransacao(transacao);
            if (!statusCode.IsSuccessStatusCode)
            {
                Response.TrySkipIisCustomErrors = true;
                Response.StatusCode = 400;
                return Content(Utilitarios.Utilitarios.limpaMenssagemErro(statusCode.Content.ReadAsStringAsync().Result));

            }

            Response.StatusCode = 200;
            return Json(statusCode.Content.ReadAsAsync<TransacaoViewModel>().Result);
        }

        //confirma os dados do deposito
        public ActionResult ConfirmaDeposito(string contaId, string valorADepositar)
        {
            var statusCode = new HttpResponseMessage();
            var cliente = (ClienteViewModel)Session["cliente"];
            var operacaoRealizada = new OperacoesRealizadas();
            operacaoRealizada.contaId = int.Parse(contaId);
            operacaoRealizada.clienteId = cliente.Id;
            operacaoRealizada.dataOp = DateTime.Now;
            operacaoRealizada.valorOp = decimal.Parse(valorADepositar);
            operacaoRealizada.operacaoId = 1;

            statusCode = _operacaoesRealizadasAppService.Deposito(operacaoRealizada);
            if (!statusCode.IsSuccessStatusCode)
            {
                Response.TrySkipIisCustomErrors = true;
                Response.StatusCode = 400;
                return Content(Utilitarios.Utilitarios.limpaMenssagemErro(statusCode.Content.ReadAsStringAsync().Result));

            }
            Response.StatusCode = 200;
            return Json(statusCode.Content.ReadAsStringAsync().Result);
        }
        [HttpPost]
        public ActionResult Saldo(TransacaoViewModel trasacaoViewModel)
        {
            var transacao = new Transacao();
            var statusCode = new HttpResponseMessage();

            ClienteViewModel cli = (ClienteViewModel)Session["cliente"];
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
        public ActionResult ConfirmaSaque(string contaId, string valorASacar)
        {
            var cliente = (ClienteViewModel)Session["cliente"];
            var statusCode = new HttpResponseMessage();
            var operacaoRealizada = new OperacoesRealizadas();
            operacaoRealizada.contaId = int.Parse(contaId);
            operacaoRealizada.clienteId = cliente.Id;
            operacaoRealizada.dataOp = DateTime.Now;

            operacaoRealizada.valorOp = decimal.Parse(valorASacar.Replace(".", ","));
            operacaoRealizada.operacaoId = 2;

            statusCode = _operacaoesRealizadasAppService.Saque(operacaoRealizada);
            if (!statusCode.IsSuccessStatusCode)
            {
                Response.TrySkipIisCustomErrors = true;
                Response.StatusCode = 400;
                return Content(Utilitarios.Utilitarios.limpaMenssagemErro(statusCode.Content.ReadAsStringAsync().Result));

            }
            Response.StatusCode = 200;
            return Json(statusCode.Content.ReadAsStringAsync().Result);

        }
        [HttpPost]
        public ActionResult Transferencia(FormCollection transacao)
        {
            var lstTransacoesViewModels = new List<TransacaoViewModel>();
            var statusCode = new HttpResponseMessage();

            ClienteViewModel cli = (ClienteViewModel)Session["cliente"];

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
            statusCode = _OperacaoAppService.VerificaDadosTransacao(transacao1);
            if (!statusCode.IsSuccessStatusCode)
            {
                Response.TrySkipIisCustomErrors = true;
                Response.StatusCode = 400;
                return Content(Utilitarios.Utilitarios.limpaMenssagemErro(statusCode.Content.ReadAsStringAsync().Result));

            }
            transacao1 = statusCode.Content.ReadAsAsync<Transacao>().Result;
            statusCode = _OperacaoAppService.VerificaDadosTransferencia(transacao2);
            if (!statusCode.IsSuccessStatusCode)
            {
                Response.TrySkipIisCustomErrors = true;
                Response.StatusCode = 400;
                return Content(Utilitarios.Utilitarios.limpaMenssagemErro(statusCode.Content.ReadAsStringAsync().Result));
            }
            transacao2 = statusCode.Content.ReadAsAsync<Transacao>().Result;

            TransacaoViewModel transacao1ViewModel = new TransacaoViewModel();
            //insere os valores na view no hidden
            transacao1ViewModel.clienteId = transacao1.clienteId;
            transacao1ViewModel.contaId = transacao1.contaId;
            transacao1ViewModel.agencia = transacao1.agencia + "";
            transacao1ViewModel.nome = transacao1.nome;
            transacao1ViewModel.valor = transacao["valor"];


            TransacaoViewModel transacao2ViewModel = new TransacaoViewModel();
            transacao2ViewModel.clienteId = transacao2.clienteId;
            transacao2ViewModel.contaId = transacao2.contaId;
            transacao2ViewModel.agencia = transacao2.agencia + "";
            transacao2ViewModel.nome = transacao2.nome;
            transacao2ViewModel.valor = transacao["valor"];
            lstTransacoesViewModels.Add(transacao1ViewModel);
            lstTransacoesViewModels.Add(transacao2ViewModel);

            Response.StatusCode = 200;
            return View("ConfirmTransferencia", lstTransacoesViewModels);

            //garante que a primeira conta é a sua própria, para impedir que tranferencia entre conta de terceiros
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
            if (!statusCode.IsSuccessStatusCode)
            {

                Response.TrySkipIisCustomErrors = true;
                Response.StatusCode = 400;
                return Content(Utilitarios.Utilitarios.limpaMenssagemErro(statusCode.Content.ReadAsStringAsync().Result));
            }
            Response.StatusCode = 200;
            return Content(statusCode.Content.ReadAsStringAsync().Result);

        }

        public ActionResult DadosParaEstorno()
        {
            return View("ContaEstorno");

        }

        public ActionResult Estorno(FormCollection form)
        {
            var dadosOpGetReal = new DadosGetOpReal();
            var statusCode = new HttpResponseMessage();
            var opsEstornoViewModels = new List<EstornoViewModel>();

            dadosOpGetReal.conta = Utilitarios.Utilitarios.retiraMask(form["conta"]);
            dadosOpGetReal.senha = Utilitarios.Utilitarios.retiraMask(form["senha"]);
            dadosOpGetReal.agencia = int.Parse(Utilitarios.Utilitarios.retiraMask(form["agencia"]));

            statusCode = _operacaoesRealizadasAppService.GetAllOperacoesPorContaParaEstorno(dadosOpGetReal);
            if (!statusCode.IsSuccessStatusCode)
            {
                Response.TrySkipIisCustomErrors = true;
                Response.StatusCode = 400;
                return Content(Utilitarios.Utilitarios.limpaMenssagemErro(statusCode.Content.ReadAsStringAsync().Result));

            }

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
            Response.StatusCode = 200;
            return View("OpRealizadasEstorno", opsEstornoViewModels);
        }
        [HttpPost]
        public JsonResult ConfirmEstorno(int id)
        {
            var statusCode = new HttpResponseMessage();
            var estorno = new Estorno
            {
                Id = id
            };
            statusCode = _operacaoesRealizadasAppService.ConfirmEstorno(estorno);
            if (!statusCode.IsSuccessStatusCode)
            {
                Response.TrySkipIisCustomErrors = true;
                Response.StatusCode = 400;
                return Json(Utilitarios.Utilitarios.limpaMenssagemErro(statusCode.Content.ReadAsStringAsync().Result), JsonRequestBehavior.AllowGet);

            }
            Response.StatusCode = 200;
            return Json(statusCode.Content.ReadAsStringAsync().Result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetOpRealizadaEstornoById(int id)
        {
            var statusCode = new HttpResponseMessage();
            statusCode = _operacaoesRealizadasAppService.GetOpRealizadaEstornoById(id);
            if (!statusCode.IsSuccessStatusCode)
            {
                Response.TrySkipIisCustomErrors = true;
                Response.StatusCode = 400;
                return Json(statusCode.Content.ReadAsStringAsync().Result, JsonRequestBehavior.AllowGet);
            }
            Response.StatusCode = 200;
            return Json(statusCode.Content.ReadAsAsync<Estorno>().Result, JsonRequestBehavior.AllowGet);
        }
    }
}
