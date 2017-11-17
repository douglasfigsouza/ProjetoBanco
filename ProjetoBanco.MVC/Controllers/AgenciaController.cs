using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Agencias;
using ProjetoBanco.Domain.Estados;
using ProjetoBanco.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

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
        public ActionResult CadastraAgencia()
        {
            var statusCodeEstados = new HttpResponseMessage();
            var statusCodeBancos = new HttpResponseMessage();
            try
            {
                statusCodeEstados = _estadoAppService.GetAllEstados();
                statusCodeBancos = _bancoAppService.GetAllBancos();
                if (!statusCodeEstados.IsSuccessStatusCode)
                {
                    Response.StatusCode = 400;
                    ViewBag.erros = Utilitarios.Utilitarios.limpaMenssagemErro(statusCodeEstados.
                            Content.ReadAsStringAsync().Result);
                    return View("PostAgencia");
                }
                if (!statusCodeBancos.IsSuccessStatusCode)
                {
                    Response.StatusCode = 400;
                    ViewBag.erros = Utilitarios.Utilitarios.limpaMenssagemErro(statusCodeBancos.
                            Content.ReadAsStringAsync().Result);
                    return View("PostAgencia");
                }

                ViewBag.estados = statusCodeEstados.Content.ReadAsAsync<IEnumerable<Estado>>().Result;
                ViewBag.bancos = statusCodeBancos.Content.ReadAsAsync<IEnumerable<BancoViewModel>>().Result;
                return View();
            }
            catch (Exception e)
            {
                ViewBag.erros = "Ops! algo deu errado!" + e.Message;
                return View("PostAgencia");
            }

        }
        public ActionResult PostAgencia(AgenciaViewModel agenciaViewModel)
        {
            try
            {
                var agencia = new AgenciaDto
                {
                    CidadeId = agenciaViewModel.CidadeId,
                    bancoId = agenciaViewModel.bancoId,
                    agencia = int.Parse(Utilitarios.Utilitarios.retiraMask(agenciaViewModel.agencia)),
                    ativo = agenciaViewModel.ativo,
                };
                var statusCode = new HttpResponseMessage();
                statusCode = _agenciaAppService.PostAgencia(agencia);
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
            catch (Exception e)
            {
                ViewBag.erros = "Ops! algo deu errado!" + e.Message;
                return View();
            }


        }
        public ActionResult EditaAgencia()
        {
            try
            {
                var agenciaViewModel = new AgenciaViewModel();

                var statusCode = new HttpResponseMessage();
                statusCode = _agenciaAppService.GetAllAgencias();
                if (!statusCode.IsSuccessStatusCode)
                {
                    Response.TrySkipIisCustomErrors = true;
                    Response.StatusCode = 400;
                    return Content(
                        Utilitarios.Utilitarios.limpaMenssagemErro(statusCode.
                            Content.ReadAsStringAsync().Result));
                }
                Response.StatusCode = 200;
                agenciaViewModel.agencias = statusCode.Content.ReadAsAsync<List<AgenciaViewModel>>().Result;

                return View("PutAgencia",agenciaViewModel);
            }
            catch (Exception e)
            {
                ViewBag.erros = "Ops! algo deu errado!" + e.Message;
                return View("PutAgencia");
            }
        }

        public ActionResult PutAgencia(AgenciaViewModel agenciaViewModel)
        {
            try
            {
                var agencia = new AgenciaDto
                {
                    agencia = int.Parse(Utilitarios.Utilitarios.retiraMask(agenciaViewModel.agencia)),
                    ativo = agenciaViewModel.ativo
                };
                var statusCode = new HttpResponseMessage();
                statusCode = _agenciaAppService.PutAgencia(agencia);
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
            catch (Exception e)
            {
                ViewBag.erros = "Ops! algo deu errado!" + e.Message;
                return View();
            }
        }

        public JsonResult GetAgenciaByNum(string numAg)
        {
            try
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
            catch (Exception)
            {
                return null;
            }
        }
    }
}