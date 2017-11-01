﻿using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace ProjetoBanco.MVC.Controllers
{
    public class ContasController : Controller
    {
        private readonly IAgenciaAppService _agenciaAppService;
        private readonly IClienteAppService _clienteAppService;
        private readonly IContaClienteAppService _contaClienteAppService;
        private CombosContaViewModel cmbContaViewModel;
        private Conta conta;
        private string error;
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
            contaClientes = new List<ContaCliente>();
        }

        public ActionResult CreateConta()
        {
            var statusCode = new HttpResponseMessage();
            statusCode = _agenciaAppService.GetAllAgencias();
            if (!statusCode.IsSuccessStatusCode)
            {
                Response.TrySkipIisCustomErrors = true;
                Response.StatusCode = 400;
                return null;
            }
            Response.StatusCode = 200;
            foreach (var agencia in statusCode.Content.ReadAsAsync<IEnumerable<AgenciaViewModel>>().Result)
            {
                cmbContaViewModel.Agencias.Add(new AgenciaViewModel
                {
                    bancoId = agencia.bancoId,
                    agencia = agencia.agencia + ""
                });
            }
            statusCode = _clienteAppService.GetAllClientes(1);
            if (!statusCode.IsSuccessStatusCode)
            {
                Response.TrySkipIisCustomErrors = true;
                Response.StatusCode = 400;
                return null;
            }
            foreach (var cliente in statusCode.Content.ReadAsAsync<IEnumerable<ClienteViewModel>>().Result)
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
            conta.num = Utilitarios.Utilitarios.retiraMask(form["num"]);
            conta.senha = form["senha"];
            conta.tipo = char.Parse(Utilitarios.Utilitarios.retiraMask(form["tipoConta"]));
            conta.ativo = true;
            int agencia = int.Parse(form["ddlAgencias"]);

            foreach (var item in ClientesSelecionados)
            {
                contaClientes.Add(new ContaCliente
                {
                    clienteId = item,
                    agencia = agencia

                });
            }
            error = _contaClienteAppService.AddContaCliente(conta, contaClientes);
            return feedBackOperacao("CreateConta", error);
        }

        public ActionResult EditConta()
        {
            return View("ContaEdit");
        }

        [HttpPost]
        public ActionResult UpdateConta(FormCollection form)
        {
            if (form != null)
            {
                conta.num = Utilitarios.Utilitarios.retiraMask(form["conta"]);
                conta.senha = form["senha"];
                conta.ativo = Convert.ToBoolean(form["ativo"]);
                error = _contaClienteAppService.UpdateConta(conta);
                return feedBackOperacao("UpdateConta", error);
            }
            else
            {
                return View("ContaEdit");
            }
        }

        [HttpGet]
        public JsonResult GetConta(string conta, string agencia, string senha)
        {
            if (conta != "" && agencia != "" && senha != "")
            {
                ContaClienteAlteracao contaCliAlter = new ContaClienteAlteracao();
                conta = Utilitarios.Utilitarios.retiraMask(conta);
                agencia = Utilitarios.Utilitarios.retiraMask(agencia);
                contaCliAlter = _contaClienteAppService.GetConta(conta, int.Parse(agencia), senha);
                if (contaCliAlter.conta == null)
                {
                    feedBackOperacao("EditConta", null);
                    return null;
                }
                else
                {
                    return Json(contaCliAlter, JsonRequestBehavior.AllowGet);
                }
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
                TempData["outraOp"] = "/Contas/" + action;
                TempData["menssagem"] = "Conta: " + conta.num + " cadastrada com sucesso!";
                return RedirectToAction("Success", "FeedBack");
            }
            else
            {
                TempData["outraOp"] = "/Contas/" + action;
                TempData["menssagem"] = "Conta: " + conta.num + " Não cadastrada! Erro: " + error;
                return RedirectToAction("Error", "FeedBack");
            }

        }
    }
}