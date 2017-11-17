using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Web_Api.Controllers
{
    public class UsuariosController : ApiController
    {
        private readonly Notifications _notifications;
        private readonly IUsuarioService _usuarioService;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuariosController(Notifications notifications, IUsuarioService usuarioService, IUsuarioRepository usuarioRepository)
        {
            _notifications = notifications;
            _usuarioService = usuarioService;
            _usuarioRepository = usuarioRepository;
        }

        public IHttpActionResult PostUsuario(UsuarioDto usuario)
        {
            try
            {
                _usuarioRepository.PostUsuario(usuario);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Ops! algo deu errado! Erro: {e.Message}");
            }
        }
        public IHttpActionResult GetAllUsuarios()
        {
            try
            {
                IEnumerable<UsuarioDto> usuarios = new List<UsuarioDto>(_usuarioRepository.GetAllUsuarios());
                return Ok(usuarios);
            }
            catch (Exception e)
            {
                return BadRequest($"Ops! algo deu errado! Erro: {e.Message}");
            }
        }
        public IHttpActionResult GetByUsuarioId(int id)
        {
            try
            {
                var usuario = new UsuarioDto();
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
            catch (Exception e)
            {
                return BadRequest($"Ops! algo deu errado! Erro: {e.Message}");
            }
        }
        public IHttpActionResult PutUsuario(UsuarioDto usuario)
        {
            try
            {
                _usuarioRepository.PutUsuario(usuario);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Ops! algo deu errado! Erro: {e.Message}");
            }
        }
        public IHttpActionResult VerificaLogin(UsuarioDto usuario)
        {
            try
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
            catch (Exception e)
            {
                return BadRequest($"Ops! algo deu errado! Erro: {e.Message}");
            }
        }
    }
}
