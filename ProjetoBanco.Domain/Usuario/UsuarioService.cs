using ProjetoBanco.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public void AddUsuario(Usuario usuario)
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

        public Usuario VerificaLogin(Usuario usuario)
        {
            var user = new Usuario();
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

        public Usuario GetByUsuarioId(int id)
        {
            var usuario = new Usuario();
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

        public IEnumerable<Usuario> GetAllUsuarios()
        {
            IEnumerable<Usuario> usuarios = new List<Usuario>();
            try
            {
                usuarios = _usuarioRepository.GetAllUsuarios();
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível buscar usuários! Erro {e.Message}");
            }
            if (usuarios.Count() == 0)
            {
                _notifications.Notificacoes.Add("Não existem usuários cadastrados");
            }
            return usuarios;
        }

        public void UpdateUsuario(Usuario usuario)
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
