using System.Collections.Generic;
using ProjetoBanco.Domain.Usuarios;

namespace ProjetoBanco.Domain.Interfaces.IServices
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
