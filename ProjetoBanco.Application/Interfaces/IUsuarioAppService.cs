using System.Collections.Generic;
using ProjetoBanco.Domain.Usuarios;

namespace ProjetoBanco.Application.Interfaces
{
    public interface IUsuarioAppService
    {
        string AddUsuario(Usuario usuario);
        Usuario VerificaLogin(Usuario usuario);
        Usuario GetByUsuarioId(int id);
        IEnumerable<Usuario> GetAllUsuarios();
        string UpdateUsuario(Usuario usuario);
    }
}
