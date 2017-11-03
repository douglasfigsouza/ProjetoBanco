using ProjetoBanco.Application.Interfaces;
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
            HttpResponseMessage statusCode;
            var usuario = new Usuario
            {
                nome = form["usuario"],
                senha = form["senha"],
            };
            if (usuario.senha != "" && usuario.nome != "")
            {
                statusCode = _usuarioAppService.VerificaLogin(usuario);
                if (!statusCode.IsSuccessStatusCode)
                {
                    Response.TrySkipIisCustomErrors = true;
                    Response.StatusCode = 400;
                    return Content(Utilitarios.Utilitarios.limpaMenssagemErro(statusCode.Content.ReadAsStringAsync().Result));

                }
                statusCode = _clienteAppService.GetByClienteId(statusCode.Content.ReadAsAsync<Usuario>().Result.clienteId);
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

        public ActionResult Logout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
        [Authorize]
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
        [Authorize]
        [HttpPost]
        public ActionResult CreateUsuario(UsuarioViewModel usuarioViewModel)
        {
            var statusCode = new HttpResponseMessage();
            var usuario = new Usuario
            {
                clienteId = usuarioViewModel.clienteId,
                nome = usuarioViewModel.nome,
                senha = usuarioViewModel.senha,
            };
            statusCode = _usuarioAppService.AddUsuario(usuario);
            if (!statusCode.IsSuccessStatusCode)
            {
                Response.TrySkipIisCustomErrors = true;
                Response.StatusCode = 400;
                return Json(Utilitarios.Utilitarios.limpaMenssagemErro(statusCode.Content.ReadAsStringAsync().Result), JsonRequestBehavior.AllowGet);
            }
            Response.StatusCode = 200;
            return Json(statusCode.Content.ReadAsStringAsync().Result);

        }
        [Authorize]
        public ActionResult EditUsuario()
        {
            var statusCode = new HttpResponseMessage();
            statusCode = _usuarioAppService.GetAllUsuarios();
            if (!statusCode.IsSuccessStatusCode)
            {
                Response.TrySkipIisCustomErrors = true;
                Response.StatusCode = 400;
                return Json(Utilitarios.Utilitarios.limpaMenssagemErro(statusCode.Content.ReadAsStringAsync().Result), JsonRequestBehavior.AllowGet);

            }
            Response.StatusCode = 200;
            UsuarioViewModel usuario = new UsuarioViewModel
            {
                usuarios = statusCode.Content.ReadAsAsync<IEnumerable<UsuarioViewModel>>().Result
            };
            return View(usuario);

        }
        [Authorize]
        [HttpPost]
        public ActionResult EditUsuario(UsuarioViewModel usuarioViewModel)
        {
            HttpResponseMessage statusCode;
            var usuario = new Usuario
            {
                clienteId = usuarioViewModel.clienteId,
                senha = usuarioViewModel.senha,
                nome = usuarioViewModel.nome,
                ativo = usuarioViewModel.ativo,
            };
            statusCode = _usuarioAppService.UpdateUsuario(usuario);
            if (!statusCode.IsSuccessStatusCode)
            {
                Response.TrySkipIisCustomErrors = true;
                Response.StatusCode = 400;
                return Json(Utilitarios.Utilitarios.limpaMenssagemErro(statusCode.Content.ReadAsStringAsync().Result), JsonRequestBehavior.AllowGet);
            }
            Response.StatusCode = 200;
            return Json(statusCode.Content.ReadAsStringAsync().Result);

        }
        [Authorize]
        [HttpGet]
        public JsonResult GetByUsuarioId(int clienteId)
        {
            var statusCode = new HttpResponseMessage();
            statusCode = _usuarioAppService.GetByUsuarioId(clienteId);
            if (!statusCode.IsSuccessStatusCode)
            {
                Response.TrySkipIisCustomErrors = true;
                Response.StatusCode = 400;
                return Json(Utilitarios.Utilitarios.limpaMenssagemErro(statusCode.Content.ReadAsStringAsync().Result), JsonRequestBehavior.AllowGet);

            }
            Response.StatusCode = 200;
            return Json(statusCode.Content.ReadAsAsync<Usuario>().Result, JsonRequestBehavior.AllowGet);
        }
    }
}