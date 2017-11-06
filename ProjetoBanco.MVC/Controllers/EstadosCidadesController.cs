using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Cidades;
using ProjetoBanco.Domain.Estados;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace ProjetoBanco.MVC.Controllers
{
    [Authorize]
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
            var statusCode = new HttpResponseMessage();
            statusCode = _cidadeAppService.GetCidadesByEstadoId(id);
            if (!statusCode.IsSuccessStatusCode)
            {
                Response.TrySkipIisCustomErrors = true;
                Response.StatusCode = 400;
                return Json(statusCode.Content.ReadAsStringAsync().Result, JsonRequestBehavior.AllowGet);
            }
            return Json(statusCode.Content.ReadAsAsync<IEnumerable<Cidade>>().Result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetCidadeJaCadastrada(int cidadeId, int EstadoId)
        {
            var statusCode = new HttpResponseMessage();
            statusCode = _cidadeAppService.GetCidadesByEstadoId(EstadoId);
            if (!statusCode.IsSuccessStatusCode)
            {
                Response.TrySkipIisCustomErrors = true;
                Response.StatusCode = 400;
                return Json(statusCode.Content.ReadAsStringAsync().Result, JsonRequestBehavior.AllowGet);
            }
            var cidades = new List<Cidade>(statusCode.Content.ReadAsAsync<IEnumerable<Cidade>>().Result);
            foreach (var item in cidades)
            {
                if (item.cidadeId == cidadeId)
                {
                    Cidades.Add(new SelectListItem() { Text = item.Nome, Value = item.cidadeId + "" });
                }
            }
            foreach (var item in cidades)
            {
                Cidades.Add(new SelectListItem() { Text = item.Nome, Value = item.cidadeId + "" });
            }
            Response.StatusCode = 200;
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
            var estados = new List<Estado>(statusCode.Content.ReadAsAsync<IEnumerable<Estado>>().Result);
            foreach (var item in estados)
            {
                if (item.EstadoId == EstadoId)
                {
                    Cidades.Add(new SelectListItem() { Text = item.Sigla, Value = item.EstadoId + "" });
                }
            }
            foreach (var item in estados)
            {
                Cidades.Add(new SelectListItem() { Text = item.Sigla, Value = item.EstadoId + "" });
            }
            return Json(new SelectList(Cidades, "Value", "Text", 0), JsonRequestBehavior.AllowGet);
        }
    }
}