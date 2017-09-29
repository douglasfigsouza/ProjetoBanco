using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.MVC.ViewModels;
using System;
using System.Web.Mvc;

namespace ProjetoBanco.MVC.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteAppService _clienteApp;
        private Cliente cliente;
        public ClientesController(IClienteAppService clienteApp)
        {
            _clienteApp = clienteApp;
            cliente = new Cliente();
        }
        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel clienteViewModel)
        {
            ModelState.Clear();
            if (ModelState.IsValid)
            {
                cliente.cidadeId = 2761;
                cliente.nome = clienteViewModel.nome;
                cliente.cpf = clienteViewModel.cpf;
                cliente.rg = clienteViewModel.rg;
                cliente.fone = clienteViewModel.fone;
                cliente.rua = clienteViewModel.rua;
                cliente.bairro = clienteViewModel.bairro;
                cliente.num = clienteViewModel.num;
                cliente.nivel = clienteViewModel.nivel;
                cliente.dataCadastro = DateTime.Now;
                cliente.ativo = true;
                _clienteApp.Add(cliente);
                return RedirectToAction("Index");
            }
            else
            {
                return View(clienteViewModel);
            }
        }

        //// GET: Clientes/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    var cliente = _clienteApp.GetById(id);
        //    var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);
        //    return View(clienteViewModel);
        //}

        //// POST: Clientes/Edit/5
        //[HttpPost]
        //public ActionResult Edit(ClienteViewModel clienteViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(clienteViewModel);
        //        _clienteApp.Update(clienteDomain);

        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}

        //// GET: Clientes/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    var cliente = _clienteApp.GetById(id);
        //    var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);

        //    return View(clienteViewModel);
        //}

        //// POST: Clientes/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, FormCollection f)
        //{
        //    var cliente = _clienteApp.GetById(id);
        //    _clienteApp.Remove(cliente);
        //    return RedirectToAction("Index");
        //}
    }
}
