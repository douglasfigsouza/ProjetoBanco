using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.MVC.ViewModels;
using System;
using System.Web.Mvc;

namespace ProjetoBanco.MVC.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteAppService _clienteApp;
        private readonly IEstadoAppService _estadoAppService;
        private readonly ICidadesAppService _cidadesAppService;
        private Cliente cliente;
        private string error;
        private ClienteViewModel clienteViewModel;
        private feedBackViewModel feed;
        private FeedBackController feedCtrl;

        public ClientesController(IClienteAppService clienteApp, IEstadoAppService estadoApp, ICidadesAppService ICidadeAppService, IBancoAppService IBancoAppService)
        {
            _clienteApp = clienteApp;
            _estadoAppService = estadoApp;
            _cidadesAppService = ICidadeAppService;
            cliente = new Cliente();
            clienteViewModel = new ClienteViewModel();
            feed = new feedBackViewModel();
            feedCtrl = new FeedBackController();
        }
        // GET: Clientes/Create
        public ActionResult CreateCliente()
        {
            ViewBag.estados = _estadoAppService.GetAllEstados();
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCliente(ClienteViewModel clienteViewModel, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                cliente.cidadeId = clienteViewModel.cidadeId;
                cliente.nome = clienteViewModel.nome;
                cliente.cpf = Utilitarios.Utilitarios.retiraMask(clienteViewModel.cpf);
                cliente.rg = Utilitarios.Utilitarios.retiraMask(clienteViewModel.rg);
                cliente.fone = Utilitarios.Utilitarios.retiraMask(clienteViewModel.fone);
                cliente.rua = clienteViewModel.rua;
                cliente.bairro = clienteViewModel.bairro;
                cliente.num = clienteViewModel.num;
                cliente.nivel = clienteViewModel.nivel;
                cliente.dataCadastro = DateTime.Now;
                cliente.ativo = true;

                feed.error = _clienteApp.AddCliente(cliente);
                feed.op = "cleinte";
                feed.descricao = "Cadastro do Cliente:" + clienteViewModel.nome;
                feed.url = "/Clientes/CreateCliente";

                return feedBackOperacao(feed);

            }
            else
            {
                ViewBag.estados = _estadoAppService.GetAllEstados();
                return View(clienteViewModel);
            }
        }
        [HttpGet]
        public JsonResult GetCidadesByIdEstado(int id)
        {
            return Json(_cidadesAppService.GetCidadesByEstadoId(id), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetAllClientes()
        {
            return Json(_clienteApp.GetAllClientes(1), JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditCliente()
        {
            ViewBag.clientes = _clienteApp.GetAllClientes(0);
            return View();
        }

        [HttpPost]
        public ActionResult EditCliente(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                cliente.Id = clienteViewModel.Id;
                cliente.nome = clienteViewModel.nome;
                cliente.cpf = Utilitarios.Utilitarios.retiraMask(clienteViewModel.cpf);
                cliente.rg = Utilitarios.Utilitarios.retiraMask(clienteViewModel.rg);
                cliente.fone = Utilitarios.Utilitarios.retiraMask(clienteViewModel.fone);
                cliente.bairro = clienteViewModel.bairro;
                cliente.rua = clienteViewModel.rua;
                cliente.num = clienteViewModel.num;
                cliente.nivel = clienteViewModel.nivel;
                cliente.ativo = clienteViewModel.ativo;
                cliente.cidadeId = clienteViewModel.cidadeId;


                feed.error = _clienteApp.UpdateCliente(cliente);
                feed.descricao = clienteViewModel.nome;
                feed.op = "Cliente";
                feed.url = "/Clientes/CreateCliente";
                return /*feedBackOperacao(error, "EditCliente")*/ null;
            }
            ViewBag.clientes = _clienteApp.GetAllClientes(0);
            return View(clienteViewModel);
        }

        public JsonResult GetByClienteId(int Id)
        {
            return Json(_clienteApp.GetByClienteId(Id), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetClienteByCPF(string cpf)
        {
            cliente = _clienteApp.GetClienteByCpf(Utilitarios.Utilitarios.retiraMask(cpf));
            clienteViewModel.Id = cliente.Id;
            clienteViewModel.nome = cliente.nome;
            return Json(cliente, JsonRequestBehavior.AllowGet);
        }
        private ActionResult feedBackOperacao(feedBackViewModel feed)
        {
            if (feed.error == null)
            {
                //TempData["outraOp"] = "/Clientes/" + action;
                //TempData["menssagem"] = "Cliente: " + clienteViewModel.nome + " cadastrado com sucesso!";
                return RedirectToAction("Success", "FeedBack");
            }
            else
            {
                
                return RedirectToAction("Error", "FeedBack",new {feed= feed});
            }
        }
    }
}
