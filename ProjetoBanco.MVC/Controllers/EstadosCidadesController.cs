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
        private List<SelectListItem> Cidades;

        public EstadosCidadesController(IEstadoAppService IEstadoAppService, ICidadesAppService ICidadeAppService)
        {
            _EstadoAppService = IEstadoAppService;
            _CidadeAppService = ICidadeAppService;
            Cidades = new List<SelectListItem>();;
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
        [HttpGet]
        public JsonResult GetCidadeJaCadastrada(int cidadeId, int EstadoId)
        {
            foreach (var item in _CidadeAppService.GetCidadesByEstadoId(EstadoId).ToList())
            {
                if (item.cidadeId == cidadeId)
                {
                    Cidades.Add(new SelectListItem(){ Text = item.Nome, Value = item.cidadeId + "" });
                }
            }
            foreach (var item in _CidadeAppService.GetCidadesByEstadoId(EstadoId))
            {
                Cidades.Add(new SelectListItem() { Text = item.Nome, Value = item.cidadeId + "" });
            }
            return Json(new SelectList(Cidades, "Value", "Text", 0), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetEstadoJaCadastrado(int EstadoId)
        {
            foreach (var item in _EstadoAppService.GetAllEstados().ToList())
            {
                if (item.EstadoId == EstadoId)
                {
                    Cidades.Add(new SelectListItem() { Text = item.Sigla, Value = item.EstadoId + "" });
                }
            }
            foreach (var item in _EstadoAppService.GetAllEstados().ToList())
            {
                Cidades.Add(new SelectListItem() { Text = item.Sigla, Value = item.EstadoId + "" });
            }
            return Json(new SelectList(Cidades, "Value", "Text", 0), JsonRequestBehavior.AllowGet);
        }
    }
}