using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Usuarios;
using ProjetoBanco.MVC.ViewModels;

namespace ProjetoBanco.MVC.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarioAppService _IUsuarioAppService;
        private readonly IClienteAppService _IClienteAppService;
        private Usuario usuario;
        private string error;

        public UsuariosController(IUsuarioAppService IUsuarioAppService, IClienteAppService IClienteAppService)
        {
            _IUsuarioAppService = IUsuarioAppService;
            _IClienteAppService = IClienteAppService;
            usuario = new Usuario();
        }

        public ActionResult Login()
        {
            Session.Abandon();
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
                    Session["cliente"] = _IClienteAppService.GetByClienteId(usuario.clienteId);
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

        public ActionResult Logout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return Redirect("/");
        }

        public ActionResult CreateUsuario()
        {
            ViewBag.clientes = _IClienteAppService.GetAllClientes(1);
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
                error = _IUsuarioAppService.AddUsuario(usuario);
                return feedBackOperacao("CreateUsuario", error);

            }
            else
            {
                ViewBag.clientes = _IClienteAppService.GetAllClientes(1);
                return View(usuarioViewModel);
            }
        }

        public ActionResult EditUsuario()
        {
            ViewBag.usuarios = _IUsuarioAppService.GetAllUsuarios();
            return View();
        }

        [HttpPost]
        public ActionResult EditUsuario(UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                usuario.clienteId = usuarioViewModel.clienteId;
                usuario.senha = usuarioViewModel.senha;
                usuario.nome = usuarioViewModel.nome;
                usuario.ativo = usuarioViewModel.ativo;
                error =_IUsuarioAppService.UpdateUsuario(usuario);

                return feedBackOperacao("EditUsuario", error);
            }
            else
            {

                ViewBag.usuarios = _IUsuarioAppService.GetAllUsuarios();
                return View(usuarioViewModel);
            }
        }

        [HttpGet]
        public JsonResult GetByUsuarioId(int clienteId)
        {
           return Json(_IUsuarioAppService.GetByUsuarioId(clienteId), JsonRequestBehavior.AllowGet);
        }
        private ActionResult feedBackOperacao(string action, string error)
        {
            if (error == null)
            {
                TempData["outraOp"] = "/Usuarios/" + action;
                TempData["menssagem"] = "Usuario: " + usuario.nomeCli + " cadastrado com sucesso!";
                return RedirectToAction("Success", "FeedBack");
            }
            else
            {
                TempData["outraOp"] = "/Usuarios/" + action;
                TempData["menssagem"] = "Usuario: " + usuario.nomeCli + " Não cadastrada! Erro: " + error;
                return RedirectToAction("Error", "FeedBack");
            }

        }
    }
}