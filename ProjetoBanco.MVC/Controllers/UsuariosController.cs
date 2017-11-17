using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Usuarios;
using ProjetoBanco.MVC.ViewModels;
using System;
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
        public ActionResult Login(UsuarioViewModel usuarioViewModel)
        {
            try
            {
                HttpResponseMessage statusCode;
                var usuario = new UsuarioDto
                {
                    nome = usuarioViewModel.nome,
                    senha = usuarioViewModel.senha,
                };
                if (usuario.senha != "" && usuario.nome != "")
                {
                    statusCode = _usuarioAppService.VerificaLogin(usuario);
                    if (!statusCode.IsSuccessStatusCode)
                    {
                        Response.TrySkipIisCustomErrors = true;
                        Response.StatusCode = 400;
                        return Content(
                            Utilitarios.Utilitarios.limpaMenssagemErro(statusCode.Content.ReadAsStringAsync().Result));

                    }
                    statusCode =
                        _clienteAppService.GetByClienteId(statusCode.Content.ReadAsAsync<UsuarioDto>().Result
                            .clienteId);
                    if (!statusCode.IsSuccessStatusCode)
                    {
                        Logout();
                        return null;
                    }
                    Response.TrySkipIisCustomErrors = true;
                    Response.StatusCode = 200;
                    Session["cliente"] = statusCode.Content.ReadAsAsync<ClienteViewModel>().Result;
                    FormsAuthentication.SetAuthCookie(usuario.nome, false);
                    return Json(statusCode.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    return View("Login");
                }
            }
            catch (Exception e)
            {
                ViewBag.erros = $"Ops! algo deu errado! Erro: {e.Message}";
                return View("Login");
            }

        }

        public ActionResult Logout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
        [Authorize]
        public ActionResult CadastraUsuario()
        {
            try
            {
                var statusCode = new HttpResponseMessage();
                statusCode = _clienteAppService.GetAllClientes(1);
                if (!statusCode.IsSuccessStatusCode)
                {
                    Response.TrySkipIisCustomErrors = true;
                    Response.StatusCode = 400;
                    return Json(
                        Utilitarios.Utilitarios.limpaMenssagemErro(statusCode.Content.ReadAsStringAsync().Result),
                        JsonRequestBehavior.AllowGet);

                }
                Response.StatusCode = 200;
                ViewBag.clientes = statusCode.Content.ReadAsAsync<IEnumerable<ClienteViewModel>>().Result;
                return View("PostUsuario");
            }
            catch (Exception e)
            {
                ViewBag.erros = $"Ops! algo deu errado! Erro: {e.Message}";
                return View("PostUsuario");
            }
        }
        [Authorize]
        public ActionResult PostUsuario(UsuarioViewModel usuarioViewModel)
        {
            try
            {
                var statusCode = new HttpResponseMessage();
                var usuario = new UsuarioDto
                {
                    clienteId = usuarioViewModel.clienteId,
                    nome = usuarioViewModel.nome,
                    senha = usuarioViewModel.senha,
                };
                statusCode = _usuarioAppService.PostUsuario(usuario);
                if (!statusCode.IsSuccessStatusCode)
                {
                    Response.TrySkipIisCustomErrors = true;
                    Response.StatusCode = 400;
                    return Json(
                        Utilitarios.Utilitarios.limpaMenssagemErro(statusCode.Content.ReadAsStringAsync().Result),
                        JsonRequestBehavior.AllowGet);
                }
                Response.StatusCode = 200;
                return Json(statusCode.Content.ReadAsStringAsync().Result);
            }
            catch (Exception e)
            {
                ViewBag.erros = $"Ops! algo deu errado! Erro: {e.Message}";
                return View("PostUsuario");
            }

        }
        [Authorize]
        public ActionResult EditaUsuario()
        {
            try
            {
                var statusCode = new HttpResponseMessage();
                statusCode = _usuarioAppService.GetAllUsuarios();
                if (!statusCode.IsSuccessStatusCode)
                {
                    Response.TrySkipIisCustomErrors = true;
                    Response.StatusCode = 400;
                    return Json(
                        Utilitarios.Utilitarios.limpaMenssagemErro(statusCode.Content.ReadAsStringAsync().Result),
                        JsonRequestBehavior.AllowGet);

                }
                Response.StatusCode = 200;
                UsuarioViewModel usuario = new UsuarioViewModel
                {
                    usuarios = statusCode.Content.ReadAsAsync<IEnumerable<UsuarioViewModel>>().Result
                };
                return View("PutUsuario", usuario);
            }
            catch (Exception e)
            {
                ViewBag.erros = $"Ops! algo deu errado! Erro: {e.Message}";
                return View("PutUsuario");
            }

        }
        [Authorize]
        public ActionResult PutUsuario(UsuarioViewModel usuarioViewModel)
        {
            try
            {
                HttpResponseMessage statusCode;
                var usuario = new UsuarioDto
                {
                    clienteId = usuarioViewModel.clienteId,
                    senha = usuarioViewModel.senha,
                    nome = usuarioViewModel.nome,
                    ativo = usuarioViewModel.ativo,
                };
                statusCode = _usuarioAppService.PutUsuario(usuario);
                if (!statusCode.IsSuccessStatusCode)
                {
                    Response.TrySkipIisCustomErrors = true;
                    Response.StatusCode = 400;
                    return Json(
                        Utilitarios.Utilitarios.limpaMenssagemErro(statusCode.Content.ReadAsStringAsync().Result),
                        JsonRequestBehavior.AllowGet);
                }
                Response.StatusCode = 200;
                return Json(statusCode.Content.ReadAsStringAsync().Result);
            }
            catch (Exception e)
            {
                ViewBag.erros = $"Ops! algo deu errado! Erro: {e.Message}";
                return View("PutUsuario");
            }

        }
        [Authorize]
        [HttpGet]
        public JsonResult GetByUsuarioId(int clienteId)
        {
            try
            {
                var statusCode = new HttpResponseMessage();
                statusCode = _usuarioAppService.GetByUsuarioId(clienteId);
                if (!statusCode.IsSuccessStatusCode)
                {
                    Response.TrySkipIisCustomErrors = true;
                    Response.StatusCode = 400;
                    return Json(
                        Utilitarios.Utilitarios.limpaMenssagemErro(statusCode.Content.ReadAsStringAsync().Result),
                        JsonRequestBehavior.AllowGet);

                }
                Response.StatusCode = 200;
                return Json(statusCode.Content.ReadAsAsync<UsuarioDto>().Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}