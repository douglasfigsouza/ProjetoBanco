using System;
using System.Collections.Generic;

namespace ProjetoBanco.Domain.Usuarios
{
    public class UsuarioSeviceDomain:IUsuariosService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioSeviceDomain( IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public string AddUsuario(Usuario usuario)
        {
            return _usuarioRepository.AddUsuario(usuario);
        }

        public Usuario GetByUsuarioId(int id)
        {
            throw new NotImplementedException();
        }

        public Usuario VerificaLogin(Usuario usuario)
        {
           return _usuarioRepository.VerificaLogin(usuario);
        }

        public IEnumerable<Usuario> GetAllUsuarios()
        {
            throw new NotImplementedException();
        }

        public string UpdateUsuario(Usuario usuario)
        {
           return _usuarioRepository.UpdateUsuario(usuario);
        }
    }
}
