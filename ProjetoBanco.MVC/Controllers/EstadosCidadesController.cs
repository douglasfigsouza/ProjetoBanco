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
        private readonly IEstadoAppService _IEstadoAppService;
        private readonly ICidadesAppService _ICidadeAppService;

        public EstadosCidadesController(IEstadoAppService IEstadoAppService, ICidadesAppService ICidadeAppService)
        {
            _IEstadoAppService = IEstadoAppService;
            _ICidadeAppService = ICidadeAppService;
        }

        // GET: EstadosCidades
        public IEnumerable<Estado> GetAllEstados()
        {
            return _IEstadoAppService.GetAllEstados();
        }

        //Busca Cidades pelo id do estado
        public IEnumerable<Cidade> GetCidadesByIdEstado(int id)
        {
            return _ICidadeAppService.GetCidadesByEstadoId(id);
        }
    }
}