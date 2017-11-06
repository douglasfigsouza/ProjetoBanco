using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Agencias;
using ProjetoBanco.MVC.ViewModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;
using ProjetoBanco.Domain.Estados;

namespace ProjetoBanco.MVC.Controllers
{
    [Authorize]
    public class AgenciaController : Controller
    {
        private readonly IAgenciaAppService _agenciaAppService;
        private readonly IEstadoAppService _estadoAppService;
        private readonly IBancoAppService _bancoAppService;

        public AgenciaController(IAgenciaAppService agenciaAppService, IBancoAppService bancoAppService, IEstadoAppService estadoAppService)
        {
            _agenciaAppService = agenciaAppService;
            _estadoAppService = estadoAppService;
            _bancoAppService = bancoAppService;
        }

        // GET: Agencia
        public ActionResult CreateAgencia()
        {
            var statusCode = new HttpResponseMessage();

            statusCode = _estadoAppService.GetAllEstados();
            if (!statusCode.IsSuccessStatusCode)
            {
                return null;
            }
            ViewBag.estados = statusCode.Content.ReadAsAsync<IEnumerable<Estado>>().Result;

            statusCode = _bancoAppService.GetAllBancos();
            if (!statusCode.IsSuccessStatusCode)
            {
                return null;
            }
            ViewBag.bancos = statusCode.Content.ReadAsAsync<IEnumerable<BancoViewModel>>().Result;
            return View();
        }

        [HttpPost]
        public ActionResult CreateAgencia(AgenciaViewModel agenciaViewModel)
        {
            var agencia = new Agencia
            {
                CidadeId = agenciaViewModel.CidadeId,
                bancoId = agenciaViewModel.bancoId,
                agencia = int.Parse(Utilitarios.Utilitarios.retiraMask(agenciaViewModel.agencia)),
                ativo = agenciaViewModel.ativo,
            };
            var statusCode = new HttpResponseMessage();
            statusCode = _agenciaAppService.AddAgencia(agencia);
            if (!statusCode.IsSuccessStatusCode)
            {
                Response.TrySkipIisCustomErrors = true;
                Response.StatusCode = 400;
                return Content(
                    Utilitarios.Utilitarios.limpaMenssagemErro(statusCode.
                        Content.ReadAsStringAsync().Result));
            }
            Response.StatusCode = 200;
            return Content(statusCode.Content.ReadAsStringAsync().Result);
        }

        public ActionResult UpdateAgencia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateAgencia(AgenciaViewModel agenciaViewModel)
        {
            var agencia = new Agencia
            {
                agencia = int.Parse(Utilitarios.Utilitarios.retiraMask(agenciaViewModel.agencia)),
                ativo = agenciaViewModel.ativo
            };
            var statusCode = new HttpResponseMessage();
            statusCode = _agenciaAppService.UpdateAgencia(agencia);
            if (!statusCode.IsSuccessStatusCode)
            {
                Response.TrySkipIisCustomErrors = true;
                Response.StatusCode = 400;
                return Content(
                    Utilitarios.Utilitarios.limpaMenssagemErro(statusCode.
                        Content.ReadAsStringAsync().Result));
            }
            Response.StatusCode = 200;
            return Content(statusCode.Content.ReadAsStringAsync().Result);
        }

        public JsonResult GetAgenciaByNum(string numAg)
        {
            if (numAg != null && numAg != "")
            {
                var statusCode = new HttpResponseMessage();
                statusCode = _agenciaAppService.GetAgenciaByNum(int.Parse(Utilitarios.Utilitarios.retiraMask(numAg)));
                if (!statusCode.IsSuccessStatusCode)
                {
                    Response.TrySkipIisCustomErrors = true;
                    Response.StatusCode = 400;
                    return Json(Utilitarios.Utilitarios.limpaMenssagemErro(statusCode.
                            Content.ReadAsStringAsync().Result), JsonRequestBehavior.AllowGet);
                }
                Response.StatusCode = 200;
                return Json(statusCode.Content.ReadAsAsync<AgenciaViewModel>().Result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return null;
            }
        }
    }
}