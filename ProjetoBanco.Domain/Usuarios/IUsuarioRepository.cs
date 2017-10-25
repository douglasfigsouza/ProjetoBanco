using System.Collections.Generic;

namespace ProjetoBanco.Domain.Usuarios
{
    public interface IUsuarioRepository
    {
        string AddUsuario(Usuario usuario);
        Usuario VerificaLogin(Usuario usuario);
        Usuario GetByUsuarioId(int id);
        IEnumerable<Usuario> GetAllUsuarios();
        string UpdateUsuario(Usuario usuario);
    }
}
