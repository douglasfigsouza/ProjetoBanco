using ProjetoBanco.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ProjetoBanco.Domain.Usuarios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private Notifications _notifications;

        public UsuarioService(IUsuarioRepository usuarioRepository, Notifications notifications)
        {
            _usuarioRepository = usuarioRepository;
            _notifications = notifications;
        }

        public void AddUsuario(UsuarioDto usuario)
        {
            try
            {
                _usuarioRepository.AddUsuario(usuario);
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível cadastrar usuário! Erro {e.Message}");
            }
        }

        public UsuarioDto VerificaLogin(UsuarioDto usuario)
        {
            var user = new UsuarioDto();
            try
            {
                user = _usuarioRepository.VerificaLogin(usuario);
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível buscar usuário! Erro {e.Message}");
            }
            if (usuario.nome == "")
            {
                _notifications.Notificacoes.Add("Usuário/Senha não conferem!");
            }
            return user;
        }

        public UsuarioDto GetByUsuarioId(int id)
        {
            var usuario = new UsuarioDto();
            try
            {
                usuario = _usuarioRepository.GetByUsuarioId(id);
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível buscar usuário! Erro {e.Message}");
            }
            if (usuario.nome == "")
            {
                _notifications.Notificacoes.Add("Usuário não encontrado!");
            }
            return usuario;
        }

        public IEnumerable<UsuarioDto> GetAllUsuarios()
        {
            IEnumerable<UsuarioDto> usuarios = new List<UsuarioDto>();
            try
            {
                usuarios = _usuarioRepository.GetAllUsuarios();
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível buscar usuários! Erro {e.Message}");
            }
            return usuarios;
        }

        public void UpdateUsuario(UsuarioDto usuario)
        {
            try
            {
                _usuarioRepository.UpdateUsuario(usuario);
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível atualizar usuário! Erro {e.Message}");
            }
        }
    }
}
