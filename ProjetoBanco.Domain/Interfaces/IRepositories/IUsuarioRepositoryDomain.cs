using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Domain.Interfaces.IRepositories
{
    public interface IUsuarioRepositoryDomain
    {
        void AddUsuario(Usuario usuario);
        Usuario VerificaLogin(Usuario usuario);
        Usuario GetByUsuarioId(int id);
        IEnumerable<Usuario> GetAllUsuarios();
        void UpdateUsuario(Usuario usuario);
        void RemoveUsuario(Usuario usuario);
        void Dispose();
    }
}
