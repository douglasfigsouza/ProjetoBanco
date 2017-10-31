using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Clientes.Dto;
using ProjetoBanco.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace ProjetoBanco.MVC.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteAppService _clienteApp;
        private readonly IEstadoAppService _estadoAppService;
        private readonly ICidadesAppService _cidadesAppService;

        public ClientesController(IClienteAppService clienteApp, IEstadoAppService estadoApp, ICidadesAppService ICidadeAppService, IBancoAppService IBancoAppService)
        {
            _clienteApp = clienteApp;
            _estadoAppService = estadoApp;
            _cidadesAppService = ICidadeAppService;
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

            var cliente = new Cliente();
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
            var statusCode = new HttpResponseMessage();

            statusCode = _clienteApp.AddCliente(cliente);
            if (!statusCode.IsSuccessStatusCode)
            {
                Response.TrySkipIisCustomErrors = true;
                Response.StatusCode = 400;
                return Content(Utilitarios.Utilitarios.limpaMenssagemErro(statusCode.Content.ReadAsStringAsync().Result));

            }
            Response.StatusCode = 200;
            return Json(statusCode.Content.ReadAsStringAsync().Result);
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

        public ActionResult EditarCliente()
        {
            var statusCode = new HttpResponseMessage();

            statusCode = _clienteApp.GetAllClientes(0);
            if (!statusCode.IsSuccessStatusCode)
            {
                Response.TrySkipIisCustomErrors = true;
                Response.StatusCode = 400;
                return Content(Utilitarios.Utilitarios.limpaMenssagemErro(statusCode.Content.ReadAsStringAsync().Result));

            }
            Response.StatusCode = 200;
            var cliente = new ClienteViewModel
            {
                Clientes = statusCode.Content.ReadAsAsync<IEnumerable<ClienteViewModel>>().Result
            };
            return View(cliente);
        }

        [HttpPost]
        public ActionResult EditarCliente(ClienteViewModel clienteViewModel)
        {
            var cliente = new Cliente
            {
                Id = clienteViewModel.Id,
                nome = clienteViewModel.nome,
                cpf = Utilitarios.Utilitarios.retiraMask(clienteViewModel.cpf),
                rg = Utilitarios.Utilitarios.retiraMask(clienteViewModel.rg),
                fone = Utilitarios.Utilitarios.retiraMask(clienteViewModel.fone),
                bairro = clienteViewModel.bairro,
                rua = clienteViewModel.rua,
                num = clienteViewModel.num,
                nivel = clienteViewModel.nivel,
                ativo = clienteViewModel.ativo,
                cidadeId = clienteViewModel.cidadeId,
            };
            var statusCode = new HttpResponseMessage();

            statusCode = _clienteApp.UpdateCliente(cliente);
            if (!statusCode.IsSuccessStatusCode)
            {
                Response.TrySkipIisCustomErrors = true;
                Response.StatusCode = 400;
                return Content(Utilitarios.Utilitarios.limpaMenssagemErro(statusCode.Content.ReadAsStringAsync().Result));

            }
            Response.StatusCode = 200;
            return Json(statusCode.Content.ReadAsStringAsync().Result);

        }

        public JsonResult GetByClienteId(int Id)
        {
            return Json(_clienteApp.GetByClienteId(Id), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetClienteByCPF(string cpf)
        {
            var cliente = new Cliente();
            var clienteViewModel = new ClienteViewModel();
            cliente = _clienteApp.GetClienteByCpf(Utilitarios.Utilitarios.retiraMask(cpf));
            clienteViewModel.Id = cliente.Id;
            clienteViewModel.nome = cliente.nome;
            return Json(cliente, JsonRequestBehavior.AllowGet);
        }
        private ActionResult feedBackOperacao(string action, string error, string nome, string op)
        {
            if (error == null)
            {
                TempData["outraOp"] = "/Clientes/" + action;
                TempData["menssagem"] = "Cliente: " + nome + " " + op;
                return RedirectToAction("Success", "FeedBack");
            }
            else
            {

                TempData["outraOp"] = "/Clientes/" + action;
                TempData["menssagem"] = "Cliente: " + nome + " " + op + " Erro:" + error;
                return RedirectToAction("Error", "FeedBack");
            }
        }
    }
}
