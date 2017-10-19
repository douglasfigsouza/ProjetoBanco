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
        private string error;
        private Agencia agencia;

        public AgenciaController(IAgenciaAppService agenciaAppService, IBancoAppService bancoAppService, IEstadoAppService estadoAppService)
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

                error = _agenciaAppService.AddAgencia(agencia);

                return feedBackOperacao("CreateAgencia", error);
            }
            else
            {
                ViewBag.estados = _estadoAppService.GetAllEstados();
                ViewBag.bancos = _bancoAppService.GetAllBancos();
                return View(agenciaViewModel);
            }
        }

        public ActionResult UpdateAgencia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateAgencia(AgenciaViewModel agenciaViewModel)
        {
            agencia.agencia = agenciaViewModel.agencia;
            agencia.ativo = agenciaViewModel.ativo;

            error = _agenciaAppService.UpdateAgencia(agencia);

            return feedBackOperacao("UpdateAgencia", error);

        }

        public JsonResult GetAgenciaByNum(int agencia)
        {
            if (agencia != null)
            {
                return Json(_agenciaAppService.GetAgenciaByNum(agencia), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return null;
            }
        }
        private ActionResult feedBackOperacao(string action, string error)
        {
            if (error == null)
            {
                TempData["outraOp"] = "/Agencia/"+action;
                TempData["menssagem"] = "Agência: " + agencia.agencia + " cadastrada com sucesso!";
                return RedirectToAction("Success", "FeedBack");
            }
            else
            {
                TempData["outraOp"] = "/Agencia/"+action;
                TempData["menssagem"] = "Agência: " + agencia.agencia + " Não cadastrada! Erro: " + error;
                return RedirectToAction("Error", "FeedBack");
            }
            
        }
    }
}