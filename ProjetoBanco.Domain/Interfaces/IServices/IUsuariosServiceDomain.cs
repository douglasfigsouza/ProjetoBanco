using System.Collections.Generic;
using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Domain.Interfaces.IServices
{
    public interface IUsuariosServiceDomain
    {
        string AddUsuario(Usuario usuario);
        Usuario GetByUsuarioId(int id);
        Usuario VerificaLogin(Usuario usuario);
        IEnumerable<Usuario> GetAllUsuarios();
        void UpdateUsuario(Usuario usuario);
        void RemoveUsuario(Usuario usuario);
        void Dispose();
    }
}
