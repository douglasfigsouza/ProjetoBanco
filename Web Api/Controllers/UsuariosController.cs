using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Usuarios;
using System.Collections.Generic;
using System.Web.Http;

namespace Web_Api.Controllers
{
    public class UsuariosController : ApiController
    {
        private readonly Notifications _notifications;
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(Notifications notifications, IUsuarioService usuarioService)
        {
            _notifications = notifications;
            _usuarioService = usuarioService;
        }

        public IHttpActionResult AddUsuario(Usuario usuario)
        {
            _usuarioService.AddUsuario(usuario);
            if (_notifications.Notificacoes.Count > 0)
            {
                string erros = "";
                foreach (var erro in _notifications.Notificacoes)
                {
                    erros = erros + " " + erro;
                }
                return BadRequest(erros);
            }
            else
            {
                return Ok();
            }
        }
        public IHttpActionResult GetAllUsuarios()
        {
            IEnumerable<Usuario> usuarios = new List<Usuario>(_usuarioService.GetAllUsuarios());
            if (_notifications.Notificacoes.Count > 0)
            {
                string erros = "";
                foreach (var erro in _notifications.Notificacoes)
                {
                    erros = erros + " " + erro;
                }
                return BadRequest(erros);
            }
            else
            {
                return Ok(usuarios);
            }
        }
        public IHttpActionResult GetByUsuarioId(int id)
        {
            var usuario = new Usuario();
            usuario = _usuarioService.GetByUsuarioId(id);
            if (_notifications.Notificacoes.Count > 0)
            {
                string erros = "";
                foreach (var erro in _notifications.Notificacoes)
                {
                    erros = erros + " " + erro;
                }
                return BadRequest(erros);
            }
            else
            {
                return Ok(usuario);
            }
        }
        public IHttpActionResult UpdateUsuario(Usuario usuario)
        {
            _usuarioService.UpdateUsuario(usuario);
            if (_notifications.Notificacoes.Count > 0)
            {
                string erros = "";
                foreach (var erro in _notifications.Notificacoes)
                {
                    erros = erros + " " + erro;
                }
                return BadRequest(erros);
            }
            else
            {
                return Ok(usuario);
            }
        }
        public IHttpActionResult VerificaLogin(Usuario usuario)
        {
            usuario = _usuarioService.VerificaLogin(usuario);
            if (_notifications.Notificacoes.Count > 0)
            {
                string erros = "";
                foreach (var erro in _notifications.Notificacoes)
                {
                    erros = erros + " " + erro;
                }
                return BadRequest(erros);
            }
            else
            {
                return Ok(usuario);
            }
        }
    }
}
