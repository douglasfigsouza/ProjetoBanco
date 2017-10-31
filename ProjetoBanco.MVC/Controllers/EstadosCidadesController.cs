using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Estados.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;

namespace ProjetoBanco.MVC.Controllers
{
    public class EstadosCidadesController : Controller
    {
        private readonly IEstadoAppService _estadoAppService;
        private readonly ICidadesAppService _cidadeAppService;
        private List<SelectListItem> Cidades;

        public EstadosCidadesController(IEstadoAppService estadoAppService, ICidadesAppService cidadeAppService)
        {
            _estadoAppService = estadoAppService;
            _cidadeAppService = cidadeAppService;
            Cidades = new List<SelectListItem>(); ;
        }

        // GET: EstadosCidades
        public IEnumerable<Estado> GetAllEstados()
        {
            var statusCode = _estadoAppService.GetAllEstados();
            if (!statusCode.IsSuccessStatusCode)
            {
                return null;
            }
            return statusCode.Content.ReadAsAsync<IEnumerable<Estado>>().Result;
        }

        //Busca Cidades pelo id do estado
        [HttpGet]
        public JsonResult GetCidadesByIdEstado(int id)
        {
            return Json(_cidadeAppService.GetCidadesByEstadoId(id), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetCidadeJaCadastrada(int cidadeId, int EstadoId)
        {
            foreach (var item in _cidadeAppService.GetCidadesByEstadoId(EstadoId).ToList())
            {
                if (item.cidadeId == cidadeId)
                {
                    Cidades.Add(new SelectListItem() { Text = item.Nome, Value = item.cidadeId + "" });
                }
            }
            foreach (var item in _cidadeAppService.GetCidadesByEstadoId(EstadoId))
            {
                Cidades.Add(new SelectListItem() { Text = item.Nome, Value = item.cidadeId + "" });
            }
            return Json(new SelectList(Cidades, "Value", "Text", 0), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetEstadoJaCadastrado(int EstadoId)
        {
            var statusCode = new HttpResponseMessage();
            statusCode = _estadoAppService.GetAllEstados();
            if (!statusCode.IsSuccessStatusCode)
            {
                return null;
            }
            foreach (var item in statusCode.Content.ReadAsAsync<IEnumerable<Estado>>().Result)
            {
                if (item.EstadoId == EstadoId)
                {
                    Cidades.Add(new SelectListItem() { Text = item.Sigla, Value = item.EstadoId + "" });
                }
            }
            foreach (var item in statusCode.Content.ReadAsAsync<IEnumerable<Estado>>().Result)
            {
                Cidades.Add(new SelectListItem() { Text = item.Sigla, Value = item.EstadoId + "" });
            }
            return Json(new SelectList(Cidades, "Value", "Text", 0), JsonRequestBehavior.AllowGet);
        }
    }
}