using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.MVC.ViewModels;

namespace ProjetoBanco.MVC.Controllers
{
    public class AgenciaController : Controller
    {
        private readonly IAgenciaAppService _agenciaAppService;

        private readonly IEstadoAppService _estadoAppService;

        private readonly IBancoAppService _bancoAppService;
        private Agencia agencia;
        public AgenciaController(IAgenciaAppService agenciaAppService,IBancoAppService bancoAppService, IEstadoAppService estadoAppService)
        {
            _agenciaAppService = agenciaAppService;
            _estadoAppService = estadoAppService;
            _bancoAppService = bancoAppService;
            agencia = new Agencia();
        }
        // GET: Agencia
        public ActionResult CreateAgencia()
        {
            ViewBag.estados = _estadoAppService.GetAllEstados();
            ViewBag.bancos = _bancoAppService.GetAllBancos();
            return View();
        }
        [HttpPost]
        public ActionResult CreateAgencia(AgenciaViewModel agenciaViewModel)
        {
            if (ModelState.IsValid)
            {
                agencia.CidadeId = agenciaViewModel.CidadeId;
                agencia.bancoId = agenciaViewModel.bancoId;
                agencia.agencia = agenciaViewModel.agencia;

                _agenciaAppService.AddAgencia(agencia);
                return RedirectToAction("Success", "Index");
            }
            else
            {
                ViewBag.estados = _estadoAppService.GetAllEstados();
                ViewBag.bancos = _bancoAppService.GetAllBancos();
                return View(agenciaViewModel);
            }
        }
    }
}