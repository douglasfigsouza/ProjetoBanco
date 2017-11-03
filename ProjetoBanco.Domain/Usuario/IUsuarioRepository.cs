using System.Collections.Generic;

namespace ProjetoBanco.Domain.Usuarios
{
    public interface IUsuarioRepository
    {
        void AddUsuario(Usuario usuario);
        Usuario VerificaLogin(Usuario usuario);
        Usuario GetByUsuarioId(int id);
        IEnumerable<Usuario> GetAllUsuarios();
        void UpdateUsuario(Usuario usuario);
    }
}
