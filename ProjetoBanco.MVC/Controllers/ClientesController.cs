using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Clientes;
using ProjetoBanco.Domain.Estados;
using ProjetoBanco.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace ProjetoBanco.MVC.Controllers
{
    [Authorize]
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
            var statusCode = new HttpResponseMessage();
            statusCode = _estadoAppService.GetAllEstados();
            if (!statusCode.IsSuccessStatusCode)
            {
                return null;
            }
            ViewBag.estados = statusCode.Content.ReadAsAsync<IEnumerable<Estado>>().Result;
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCliente(ClienteViewModel clienteViewModel, FormCollection form)
        {

            var cliente = new Cliente
            {
                cidadeId = clienteViewModel.cidadeId,
                nome = clienteViewModel.nome,
                cpf = Utilitarios.Utilitarios.retiraMask(clienteViewModel.cpf),
                rg = Utilitarios.Utilitarios.retiraMask(clienteViewModel.rg),
                fone = Utilitarios.Utilitarios.retiraMask(clienteViewModel.fone),
                rua = clienteViewModel.rua,
                bairro = clienteViewModel.bairro,
                num = clienteViewModel.num,
                nivel = clienteViewModel.nivel,
                dataCadastro = DateTime.Now,
                ativo = true
            };
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
            var statusCode = new HttpResponseMessage();

            statusCode = _clienteApp.GetAllClientes(1);
            if (!statusCode.IsSuccessStatusCode)
            {
                Response.TrySkipIisCustomErrors = true;
                Response.StatusCode = 400;

                return Json(Utilitarios.Utilitarios.limpaMenssagemErro(statusCode.Content.ReadAsStringAsync().Result), JsonRequestBehavior.AllowGet);

            }
            Response.StatusCode = 200;
            return Json(statusCode.Content.ReadAsAsync<IEnumerable<ClienteViewModel>>().Result, JsonRequestBehavior.AllowGet);
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
            var statusCode = new HttpResponseMessage();

            statusCode = _clienteApp.GetByClienteId(Id);
            if (!statusCode.IsSuccessStatusCode)
            {
                Response.TrySkipIisCustomErrors = true;
                Response.StatusCode = 400;
                return Json(Utilitarios.Utilitarios.limpaMenssagemErro(statusCode.Content.ReadAsStringAsync().Result), JsonRequestBehavior.AllowGet);

            }
            Response.StatusCode = 200;
            return Json(statusCode.Content.ReadAsAsync<ClienteViewModel>().Result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetClienteByCPF(string cpf)
        {
            var statusCode = new HttpResponseMessage();

            statusCode = _clienteApp.GetClienteByCpf(cpf);
            if (!statusCode.IsSuccessStatusCode)
            {
                Response.TrySkipIisCustomErrors = true;
                Response.StatusCode = 400;
                return Json(Utilitarios.Utilitarios.limpaMenssagemErro(statusCode.Content.ReadAsStringAsync().Result), JsonRequestBehavior.AllowGet);

            }
            Response.StatusCode = 200;
            return Json(statusCode.Content.ReadAsAsync<ClienteViewModel>().Result, JsonRequestBehavior.AllowGet);
        }
    }
}
