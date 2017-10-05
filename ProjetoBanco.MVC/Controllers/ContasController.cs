using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.MVC.ViewModels;

namespace ProjetoBanco.MVC.Controllers
{
    public class ContasController : Controller
    {
        private readonly IAgenciaAppService _agenciaAppService;
        private readonly IClienteAppService _clienteAppService;
        private readonly IContaClienteAppService _contaClienteAppService;
        private CombosContaViewModel cmbContaViewModel;
        private Conta conta;
        private List<ContaCliente> contaClientes;

        public ContasController(IAgenciaAppService agenciaAppService, IClienteAppService clienteAppService, IContaClienteAppService contaClienteAppService)
        {
            _agenciaAppService = agenciaAppService;
            _clienteAppService = clienteAppService;
            _contaClienteAppService = contaClienteAppService;

            cmbContaViewModel = new CombosContaViewModel();
            cmbContaViewModel.Agencias = new List<AgenciaViewModel>();
            cmbContaViewModel.Clientes = new List<ClienteViewModel>();
            conta = new Conta();
            contaClientes= new List<ContaCliente>();
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
        [HttpPost]
        public ActionResult CreateConta(List<int> ClientesSelecionados, FormCollection form)
        {
            conta.num = form["num"];
            conta.senha = form["senha"];
            conta.tipo = form["tipoConta"];
            int agencia = Convert.ToInt32(form["ddlAgencias"]);

            foreach (var item in ClientesSelecionados)
            {
               contaClientes.Add(new ContaCliente
               {
                   clienteId = item,
                   agencia = agencia

               });
            }
            _contaClienteAppService.AddContaCliente(conta,contaClientes);
            return View();
        }
    }
}