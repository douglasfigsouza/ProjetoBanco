using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Contas;
using ProjetoBanco.MVC.ViewModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace ProjetoBanco.MVC.Controllers
{
    [Authorize]
    public class ContasController : Controller
    {
        private readonly IAgenciaAppService _agenciaAppService;
        private readonly IClienteAppService _clienteAppService;
        private readonly IContaClienteAppService _contaClienteAppService;

        public ContasController(IAgenciaAppService agenciaAppService, IClienteAppService clienteAppService, IContaClienteAppService contaClienteAppService)
        {
            _agenciaAppService = agenciaAppService;
            _clienteAppService = clienteAppService;
            _contaClienteAppService = contaClienteAppService;
        }
        [Authorize]
        public ActionResult CreateConta()
        {
            CombosContaViewModel cmbContaViewModel = new CombosContaViewModel();
            var statusCode = new HttpResponseMessage();
            statusCode = _agenciaAppService.GetAllAgencias();
            if (!statusCode.IsSuccessStatusCode)
            {
                Response.TrySkipIisCustomErrors = true;
                Response.StatusCode = 400;
                return null;
            }
            foreach (var agencia in statusCode.Content.ReadAsAsync<IEnumerable<AgenciaViewModel>>().Result)
            {
                cmbContaViewModel.Agencias.Add(new AgenciaViewModel
                {
                    bancoId = agencia.bancoId,
                    agencia = agencia.agencia + ""
                });
            }
            statusCode = _clienteAppService.GetAllClientes(1);
            if (!statusCode.IsSuccessStatusCode)
            {
                Response.TrySkipIisCustomErrors = true;
                Response.StatusCode = 400;
                return null;
            }
            foreach (var cliente in statusCode.Content.ReadAsAsync<IEnumerable<ClienteViewModel>>().Result)
            {
                cmbContaViewModel.Clientes.Add(new ClienteViewModel
                {
                    Id = cliente.Id,
                    nome = cliente.nome
                });
            }
            return View(cmbContaViewModel);
        }
        [HttpPost]
        public ActionResult CreateConta(List<int> ClientesSelecionados, ContaViewModel contaViewModel)
        {
            var statusCode = new HttpResponseMessage();
            var conta = new Conta
            {
                num = Utilitarios.Utilitarios.retiraMask(contaViewModel.num),
                senha = contaViewModel.senha,
                tipo = char.Parse(Utilitarios.Utilitarios.retiraMask(contaViewModel.tipo)),
                ativo = true
            };
            int agencia = contaViewModel.dllAgencias;

            foreach (var item in ClientesSelecionados)
            {
                conta.contaClientes.Add(new ContaCliente
                {
                    clienteId = item,
                    agencia = agencia

                });
            }
            statusCode = _contaClienteAppService.AddContaCliente(conta);
            if (!statusCode.IsSuccessStatusCode)
            {
                Response.TrySkipIisCustomErrors = true;
                Response.StatusCode = 400;
                return Content(Utilitarios.Utilitarios.limpaMenssagemErro(statusCode.Content.ReadAsStringAsync().Result));

            }
            Response.StatusCode = 200;
            return Content(statusCode.Content.ReadAsStringAsync().Result);
        }

        public ActionResult EditConta()
        {
            var statusCode = new HttpResponseMessage();
            statusCode = _contaClienteAppService.GetAllDadosEClientesDaConta();
            if (!statusCode.IsSuccessStatusCode)
            {
                Response.TrySkipIisCustomErrors = true;
                Response.StatusCode = 400;
                return Json(Utilitarios.Utilitarios.limpaMenssagemErro(statusCode.Content.ReadAsStringAsync().Result));

            }
            Response.StatusCode = 200;
            IEnumerable<ContaClienteViewModel> model = statusCode.Content.ReadAsAsync<IEnumerable<ContaClienteViewModel>>().Result;
            return View("ContaEdit", model);
        }

        [HttpPost]
        public ActionResult UpdateConta(ContaViewModel contaViewModel)
        {
            var statusCode = new HttpResponseMessage();
            if (contaViewModel != null)
            {
                var conta = new Conta
                {
                    num = Utilitarios.Utilitarios.retiraMask(contaViewModel.conta),
                    senha = contaViewModel.senha,
                    ativo = contaViewModel.ativo,
                };
                statusCode = _contaClienteAppService.UpdateConta(conta);
                if (!statusCode.IsSuccessStatusCode)
                {
                    Response.TrySkipIisCustomErrors = true;
                    Response.StatusCode = 400;
                    return Content(Utilitarios.Utilitarios.limpaMenssagemErro(statusCode.Content.ReadAsStringAsync().Result));

                }
                Response.StatusCode = 200;
                return Json(statusCode.Content.ReadAsStringAsync().Result);
            }
            else
            {
                return View("ContaEdit");
            }
        }

        [HttpPost]
        public JsonResult GetConta(int contaId)
        {
            if (contaId != 0)
            {
                var statusCode = new HttpResponseMessage();

                statusCode = _contaClienteAppService.GetConta(contaId);

                if (!statusCode.IsSuccessStatusCode)
                {
                    Response.TrySkipIisCustomErrors = true;
                    Response.StatusCode = 400;
                    return Json(Utilitarios.Utilitarios.limpaMenssagemErro(statusCode.Content.ReadAsStringAsync().Result));

                }
                Response.StatusCode = 200;
                return Json(statusCode.Content.ReadAsAsync<ContaClienteAlteracao>().Result);
            }
            else
            {
                return null;
            }
        }
    }
}