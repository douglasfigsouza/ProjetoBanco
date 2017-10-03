using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.MVC.ViewModels;

namespace ProjetoBanco.MVC.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarioAppService _IUsuarioAppService;
        private readonly IClienteAppService _IClienteAppService;
        private Usuario usuario,usuarioAutenticado;

        public UsuariosController(IUsuarioAppService IUsuarioAppService, IClienteAppService IClienteAppService)
        {
            _IUsuarioAppService = IUsuarioAppService;
            _IClienteAppService = IClienteAppService;
            usuario = new Usuario();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            usuario.nome = form["usuario"];
            usuario.senha = form["senha"];
            if (usuario.senha != "" && usuario.nome != "")
            {
                usuario = _IUsuarioAppService.VerificaLogin(usuario);

                if (usuario.nivel !=0)
                {
                    Session["nivel"] = usuario.nivel;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View("Login");
                }
            }
            else
            {
                return View("Login");
            }
        }

        public ActionResult CreateUsuario()
        {
            ViewBag.clientes = _IClienteAppService.GetAllClientes();
            return View();
        }

        [HttpPost]
        public ActionResult CreateUsuario(UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                usuario.clienteId = usuarioViewModel.clienteId;
                usuario.nome = usuarioViewModel.nome;
                usuario.senha = usuarioViewModel.senha;
                _IUsuarioAppService.AddUsuario(usuario);
                return RedirectToAction("Success", "Index");
            }
            else
            {
                ViewBag.clientes = _IClienteAppService.GetAllClientes();
                return View(usuarioViewModel);
            }
        }
    }
}