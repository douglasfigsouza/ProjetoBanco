using System.Collections.Generic;

namespace ProjetoBanco.Domain.Usuarios
{
    public interface IUsuariosService
    {
        string AddUsuario(Usuario usuario);
        Usuario GetByUsuarioId(int id);
        Usuario VerificaLogin(Usuario usuario);
        IEnumerable<Usuario> GetAllUsuarios();
        string UpdateUsuario(Usuario usuario);
    }
}
