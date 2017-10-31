﻿using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Usuarios;
using ProjetoBanco.MVC.ViewModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjetoBanco.MVC.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarioAppService _usuarioAppService;
        private readonly IClienteAppService _clienteAppService;

        public UsuariosController(IUsuarioAppService usuarioAppService, IClienteAppService clienteAppService)
        {
            _usuarioAppService = usuarioAppService;
            _clienteAppService = clienteAppService;

        }

        public ActionResult Login()
        {
            Session.Abandon();
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            var usuario = new Usuario
            {
                nome = form["usuario"],
                senha = form["senha"],
            };
            if (usuario.senha != "" && usuario.nome != "")
            {
                usuario = _usuarioAppService.VerificaLogin(usuario);

                if (usuario.nivel != 0)
                {
                    var statusCode = new HttpResponseMessage();
                    statusCode = _clienteAppService.GetByClienteId(usuario.clienteId);
                    if (!statusCode.IsSuccessStatusCode)
                    {
                        Logout();
                        return null;
                    }
                    else
                    {
                        Session["cliente"] = statusCode.Content.ReadAsAsync<ClienteViewModel>().Result;
                        return RedirectToAction("Index", "Home");
                    }
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
            var statusCode = new HttpResponseMessage();
            statusCode = _clienteAppService.GetAllClientes(1);
            if (!statusCode.IsSuccessStatusCode)
            {
                Response.TrySkipIisCustomErrors = true;
                Response.StatusCode = 400;
                return Json(Utilitarios.Utilitarios.limpaMenssagemErro(statusCode.Content.ReadAsStringAsync().Result), JsonRequestBehavior.AllowGet);

            }
            Response.StatusCode = 200;
            ViewBag.clientes = statusCode.Content.ReadAsAsync<IEnumerable<ClienteViewModel>>().Result;
            return View();
        }

        [HttpPost]
        public ActionResult CreateUsuario(UsuarioViewModel usuarioViewModel)
        {
            var error = "";
            var usuario = new Usuario
            {
                clienteId = usuarioViewModel.clienteId,
                nome = usuarioViewModel.nome,
                senha = usuarioViewModel.senha,
            };
            error = _usuarioAppService.AddUsuario(usuario);
            return feedBackOperacao("CreateUsuario", error); ;

        }

        public ActionResult EditUsuario()
        {
            ViewBag.usuarios = _usuarioAppService.GetAllUsuarios();
            return View();
        }

        [HttpPost]
        public ActionResult EditUsuario(UsuarioViewModel usuarioViewModel)
        {
            var error = "";
            var usuario = new Usuario
            {
                clienteId = usuarioViewModel.clienteId,
                senha = usuarioViewModel.senha,
                nome = usuarioViewModel.nome,
                ativo = usuarioViewModel.ativo,
            };
            error = _usuarioAppService.UpdateUsuario(usuario);

            return feedBackOperacao("EditUsuario", error);

        }

        [HttpGet]
        public JsonResult GetByUsuarioId(int clienteId)
        {
            return Json(_usuarioAppService.GetByUsuarioId(clienteId), JsonRequestBehavior.AllowGet);
        }
        private ActionResult feedBackOperacao(string action, string error)
        {
            var usuario = new Usuario();
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