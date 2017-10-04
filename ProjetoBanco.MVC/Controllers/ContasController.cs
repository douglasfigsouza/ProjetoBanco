using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.MVC.ViewModels;

namespace ProjetoBanco.MVC.Controllers
{
    public class ContasController : Controller
    {
        private readonly IAgenciaAppService _agenciaAppService;
        private readonly IClienteAppService _clienteAppService;
        private CombosContaViewModel cmbContaViewModel;

        public ContasController(IAgenciaAppService agenciaAppService, IClienteAppService clienteAppService)
        {
            _agenciaAppService = agenciaAppService;
            _clienteAppService = clienteAppService;
            cmbContaViewModel = new CombosContaViewModel();
            cmbContaViewModel.Agencias = new List<AgenciaViewModel>();
            cmbContaViewModel.Clientes = new List<ClienteViewModel>();
        }

        public ActionResult CreateConta()
        {
            foreach (var agencia in _agenciaAppService.GetAllAgencias())
            {
                cmbContaViewModel.Agencias.Add(new AgenciaViewModel
                {
                    bancoId = agencia.bancoId,
                    agencia = agencia.agencia
                });
            }
            foreach (var cliente in _clienteAppService.GetAllClientes())
            {
                cmbContaViewModel.Clientes.Add(new ClienteViewModel
                {
                    Id = cliente.Id,
                    nome = cliente.nome
                });
            }
            return View(cmbContaViewModel);
        }
    }
}