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
                agencia.agencia = int.Parse(Utilitarios.Utilitarios.retiraMask(agenciaViewModel.agencia));
                agencia.ativo = agenciaViewModel.ativo;

                error = _agenciaAppService.AddAgencia(agencia);

                return feedBackOperacao("CreateAgencia", error,"Cadastrada com sucesso!");
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
        public ActionResult AtualizaAgencia(AgenciaViewModel agenciaViewModel)
        {
            agencia.agencia = int.Parse(Utilitarios.Utilitarios.retiraMask(agenciaViewModel.agencia));
            agencia.ativo = agenciaViewModel.ativo;

            error = _agenciaAppService.UpdateAgencia(agencia);

            return feedBackOperacao("UpdateAgencia", error,"Atualizada com sucesso!");
        }

        public JsonResult GetAgenciaByNum(string numAg)
        {
            if (numAg != null && numAg!="")
            {
                AgenciaViewModel agenciaViewModel = new AgenciaViewModel();
                agencia = _agenciaAppService.GetAgenciaByNum(int.Parse(Utilitarios.Utilitarios.retiraMask(numAg)));

                agenciaViewModel.agencia = agencia.agencia+"";
                agenciaViewModel.banco = agencia.banco;
                agenciaViewModel.ativo = agencia.ativo;
                if (agencia.agencia!=0)
                {
                    return Json(agenciaViewModel, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        private ActionResult feedBackOperacao(string action, string error, string op)
        {
            if (error == null)
            {
                TempData["outraOp"] = "/Agencia/" + action;
                TempData["menssagem"] = "Agência: " + agencia.agencia + " "+op;
                return RedirectToAction("Success", "FeedBack");
            }
            else
            {
                TempData["outraOp"] = "/Agencia/" + action;
                TempData["menssagem"] = "Agência: " + agencia.agencia +" "+ op +"error";
                return RedirectToAction("Error", "FeedBack");
            }

        }
    }
}