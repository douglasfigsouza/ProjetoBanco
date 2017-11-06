using System.Collections.Generic;

namespace ProjetoBanco.Domain.Usuarios
{
    public interface IUsuarioService
    {
        void AddUsuario(Usuario usuario);
        Usuario VerificaLogin(Usuario usuario);
        Usuario GetByUsuarioId(int id);
        IEnumerable<Usuario> GetAllUsuarios();
        void UpdateUsuario(Usuario usuario);
    }
}
