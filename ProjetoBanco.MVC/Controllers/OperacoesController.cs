using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Operacoes;
using ProjetoBanco.MVC.ViewModels;

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
        private OperacoesRealizadas operacaoRealizada;
        private OperacoesRealizadas operacaoRealizada1;
        private Operacoes op;
        private Transacao transacao;
        private List<TransacaoViewModel> lstTransacoesViewModels;
        private List<EstornoViewModel> opsEstornoViewModels;
        private decimal valor;
        private HttpResponseMessage statusCode;
        private dynamic transact;


        public OperacoesController(IOperacoesAppService OperacaoAppService, IOperacaoesRealizadasAppService operacaoesRealizadasAppService)
        {
            _OperacaoAppService = OperacaoAppService;
            _operacaoesRealizadasAppService = operacaoesRealizadasAppService;
            operacaoRealizada = new OperacoesRealizadas();
            operacaoRealizada1 = new OperacoesRealizadas();
            transacao = new Transacao();
            lstTransacoesViewModels = new List<TransacaoViewModel>();
            op = new Operacoes();
            opsEstornoViewModels = new List<EstornoViewModel>();
        }

        // GET: Operacoes
        public ActionResult CreateOperacao()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateOperacao(OperacaoViewModel opViewModel)
        {
            if (ModelState.IsValid)
            {
                op.descricao = opViewModel.descricao;
                op.ativo = true;
                statusCode = _OperacaoAppService.AddOperacao(op);
                if (statusCode.IsSuccessStatusCode)
                {
                    TempData["outraOp"] = "/Operacoes/CreateOperacao";
                    TempData["menssagem"] = "Operação: " + opViewModel.descricao + " cadastrada com sucesso!";
                    return RedirectToAction("Success", "FeedBack");
                }
                else
                {
                    transact = await statusCode.Content.ReadAsStringAsync();
                    TempData["outraOp"] = "/Operacoes/CreateOperacao";
                    TempData["menssagem"] = Utilitarios.Utilitarios.limpaMenssagemErro(transact + "");
                    return RedirectToAction("Error", "FeedBack");
                }
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
            ViewBag.cliente = (Cliente)Session["cliente"];
            return View();
        }

        public async Task<ActionResult> VerificaDados(TransacaoViewModel trasacaoViewModel)
        {
            if (ModelState.IsValid)
            {
                Cliente cli = (Cliente)Session["cliente"];

                transacao.clienteId = cli.Id;
                valor = decimal.Parse(Utilitarios.Utilitarios.retiraMaskMoney(trasacaoViewModel.valor));
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
                    transact = await statusCode.Content.ReadAsAsync<Transacao>();
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
        public async Task<ActionResult> ConfirmDeposito(TransacaoViewModel trasacaoViewModel)
        {
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
                transact = await statusCode.Content.ReadAsStringAsync();
                ViewBag.erro = Utilitarios.Utilitarios.limpaMenssagemErro(transact);
                return View("FeedBackOp");
            }
        }

        public async Task<ActionResult> ConsultaSaldo(TransacaoViewModel trasacaoViewModel)
        {
            Cliente cli = (Cliente)Session["cliente"];
            transacao.nivel = cli.nivel;
            transacao.senhaCli = trasacaoViewModel.senhaCli;
            transacao.clienteId = cli.Id;
            transacao.agencia = int.Parse(Utilitarios.Utilitarios.retiraMask(trasacaoViewModel.agencia));
            transacao.conta = Utilitarios.Utilitarios.retiraMask(trasacaoViewModel.conta);

            statusCode = _OperacaoAppService.ConsultaSaldo(transacao);
            if (statusCode.IsSuccessStatusCode)
            {
                //faz a deserialização do json retornado da requisiçao 
                transact = await statusCode.Content.ReadAsAsync<Transacao>();
                ViewBag.saldo = transact;
                return View("MostraSaldo");
            }
            else
            {
                transact = await statusCode.Content.ReadAsStringAsync();
                ViewBag.erro = Utilitarios.Utilitarios.limpaMenssagemErro(transact + "");
                return View("MostraSaldo");

            }

        }
        //confirma os dados do saque
        public async Task<ActionResult> ConfirmSaque(TransacaoViewModel trasacaoViewModel)
        {
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
                transact = await statusCode.Content.ReadAsStringAsync();
                TempData["menssagem"] = Utilitarios.Utilitarios.limpaMenssagemErro(transact + "");
                TempData["outraOp"] = "/Operacoes/Saque";
                return View("FeedBackOp");
            }

        }
        [HttpPost]
        public async Task<ActionResult> Transferencia(FormCollection transacao)
        {
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
            transacao1 = await statusCode.Content.ReadAsAsync<Transacao>();
            statusCode = _OperacaoAppService.VerificaDadosTransferencia(transacao2);

            if (statusCode.IsSuccessStatusCode)
            {
                transacao2 = await statusCode.Content.ReadAsAsync<Transacao>();

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
            operacaoRealizada.agencia = int.Parse(Transacoes[0].agencia);
            operacaoRealizada.clienteId = Transacoes[0].clienteId;
            operacaoRealizada.contaId = Transacoes[0].contaId;
            operacaoRealizada.dataOp = DateTime.Now;
            operacaoRealizada.valorOp = decimal.Parse(Utilitarios.Utilitarios.retiraMaskMoney(Transacoes[0].valor));
            operacaoRealizada1.agencia = int.Parse(Transacoes[1].agencia);
            operacaoRealizada1.clienteId = Transacoes[1].clienteId;
            operacaoRealizada1.contaId = Transacoes[1].contaId;
            operacaoRealizada1.dataOp = DateTime.Now;

            TempData["menssagem"] = _operacaoesRealizadasAppService.Transferencia(operacaoRealizada, operacaoRealizada1);
            TempData["outraOp"] = "/Operacoes/Transferencia";
            return View("FeedBackOp");

        }

        public ActionResult DadosParaEstorno()
        {
            return View("Estorno");

        }

        public ActionResult Estorno(FormCollection form)
        {
            string conta, senha;
            int agencia;

            conta = Utilitarios.Utilitarios.retiraMask(form["conta"]);
            senha = Utilitarios.Utilitarios.retiraMask(form["senha"]);
            agencia = int.Parse(Utilitarios.Utilitarios.retiraMask(form["agencia"]));
            foreach (var op in _operacaoesRealizadasAppService.GetAllOperacoesPorContaParaEstorno(conta, senha, agencia))
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

        //[System.Web.Mvc.HttpPost]
        //public ActionResult ConfirmEstorno(int id)
        //{
        //    statusCode = _operacaoesRealizadasAppService.ConfirmEstorno(id);
        //    if (statusCode == null)
        //    {
        //        TempData["menssagem"] = "Estorno realizado com sucesso!";
        //        TempData["outraOp"] = "/Operacoes/Estorno";
        //        return View("FeedBackOp");
        //    }
        //    else
        //    {
        //        TempData["menssagem"] = "Estorno não Realizado!";
        //        TempData["outraOp"] = "/Operacoes/Estorno";
        //        return View("FeedBackOp");
        //    }
        //}
        [HttpGet]
        public JsonResult GetOpRealizadaEstornoById(int id)
        {
            return Json(_operacaoesRealizadasAppService.GetOpRealizadaEstornoById(id), JsonRequestBehavior.AllowGet);
        }
    }
}
