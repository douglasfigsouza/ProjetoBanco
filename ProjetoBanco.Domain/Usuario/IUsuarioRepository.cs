using System.Collections.Generic;

namespace ProjetoBanco.Domain.Usuarios
{
    public interface IUsuarioRepository
    {
        void AddUsuario(UsuarioDto usuario);
        UsuarioDto VerificaLogin(UsuarioDto usuario);
        UsuarioDto GetByUsuarioId(int id);
        IEnumerable<UsuarioDto> GetAllUsuarios();
        void UpdateUsuario(UsuarioDto usuario);
    }
}
