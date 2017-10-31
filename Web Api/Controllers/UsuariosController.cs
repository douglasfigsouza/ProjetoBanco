using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Usuarios;
using System.Collections.Generic;
using System.Web.Http;

namespace Web_Api.Controllers
{
    public class UsuariosController : ApiController
    {
        private readonly Notifications _notifications;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuariosController(Notifications notifications, IUsuarioRepository usuarioRepository)
        {
            _notifications = notifications;
            _usuarioRepository = usuarioRepository;
        }

        public IHttpActionResult AddUsuario(Usuario usuario)
        {
            _usuarioRepository.AddUsuario(usuario);
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
            IEnumerable<Usuario> usuarios = new List<Usuario>(_usuarioRepository.GetAllUsuarios());
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
            usuario = _usuarioRepository.GetByUsuarioId(id);
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
            _usuarioRepository.UpdateUsuario(usuario);
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
            usuario = _usuarioRepository.VerificaLogin(usuario);
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
