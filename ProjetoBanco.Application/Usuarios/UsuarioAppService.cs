using System.Collections.Generic;
using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Interfaces.IRepositories;
using ProjetoBanco.Domain.Interfaces.IServices;
using ProjetoBanco.Domain.Usuarios;

namespace ProjetoBanco.Application
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuariosService _usuarioService;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioAppService(IUsuariosService usuarioService, IUsuarioRepository usuarioRepository)
        {
            _usuarioService = usuarioService;
            _usuarioRepository = usuarioRepository;
        }
        public string AddUsuario(Usuario usuario)
        {
            return _usuarioRepository.AddUsuario(usuario);
        }

        public Usuario GetByUsuarioId(int id)
        {
            return _usuarioRepository.GetByUsuarioId(id);
        }

        public IEnumerable<Usuario> GetAllUsuarios()
        {
            return _usuarioRepository.GetAllUsuarios();
        }

        public string UpdateUsuario(Usuario usuario)
        {
            return _usuarioRepository.UpdateUsuario(usuario);
        }

        public Usuario VerificaLogin(Usuario usuario)
        {
            return _usuarioRepository.VerificaLogin(usuario);
        }
    }
}
