using System.Collections.Generic;

namespace ProjetoBanco.Domain.Usuarios
{
    public interface IUsuarioService
    {
        void AddUsuario(UsuarioDto usuario);
        UsuarioDto VerificaLogin(UsuarioDto usuario);
        UsuarioDto GetByUsuarioId(int id);
        IEnumerable<UsuarioDto> GetAllUsuarios();
        void UpdateUsuario(UsuarioDto usuario);
    }
}
