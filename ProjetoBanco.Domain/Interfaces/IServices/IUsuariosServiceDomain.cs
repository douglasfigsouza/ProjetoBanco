using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Domain.Interfaces.IServices
{
    public interface IUsuariosServiceDomain
    {
        void AddUsuario(Usuario usuario);
        Usuario GetByUsuarioId(int id);
        Usuario VerificaLogin(Usuario usuario);
        IEnumerable<Usuario> GetAllUsuarios();
        void UpdateUsuario(Usuario usuario);
        void RemoveUsuario(Usuario usuario);
        void Dispose();
    }
}
