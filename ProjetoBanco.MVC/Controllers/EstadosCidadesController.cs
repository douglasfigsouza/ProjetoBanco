using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.MVC.Controllers
{
    public class EstadosCidadesController : Controller
    {
        private readonly IEstadoAppService _EstadoAppService;
        private readonly ICidadesAppService _CidadeAppService;

        public EstadosCidadesController(IEstadoAppService IEstadoAppService, ICidadesAppService ICidadeAppService)
        {
            _EstadoAppService = IEstadoAppService;
            _CidadeAppService = ICidadeAppService;
        }

        // GET: EstadosCidades
        public IEnumerable<Estado> GetAllEstados()
        {
            return _EstadoAppService.GetAllEstados();
        }

        //Busca Cidades pelo id do estado
        [HttpGet]
        public JsonResult GetCidadesByIdEstado(int id)
        {
            return Json(_CidadeAppService.GetCidadesByEstadoId(id), JsonRequestBehavior.AllowGet);
        }
    }
}