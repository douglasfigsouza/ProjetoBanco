using System.Collections.Generic;

namespace ProjetoBanco.Domain.Usuarios
{
    public interface IUsuariosService
    {
        void AddUsuario(Usuario usuario);
        Usuario GetByUsuarioId(int id);
        Usuario VerificaLogin(Usuario usuario);
        IEnumerable<Usuario> GetAllUsuarios();
        void UpdateUsuario(Usuario usuario);
    }
}
