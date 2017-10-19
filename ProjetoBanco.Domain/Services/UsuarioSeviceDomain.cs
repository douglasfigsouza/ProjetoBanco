using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Interfaces.IRepositories;
using ProjetoBanco.Domain.Interfaces.IServices;

namespace ProjetoBanco.Domain.Services
{
    public class UsuarioSeviceDomain:IUsuariosServiceDomain
    {
        private readonly IUsuarioRepositoryDomain _IUsuarioRepositoryDomain;

        public UsuarioSeviceDomain( IUsuarioRepositoryDomain IUsuarioRepositoryDomain)
        {
            _IUsuarioRepositoryDomain = IUsuarioRepositoryDomain;
        }
        public string AddUsuario(Usuario usuario)
        {
            return _IUsuarioRepositoryDomain.AddUsuario(usuario);
        }

        public Usuario GetByUsuarioId(int id)
        {
            throw new NotImplementedException();
        }

        public Usuario VerificaLogin(Usuario usuario)
        {
           return _IUsuarioRepositoryDomain.VerificaLogin(usuario);
        }

        public IEnumerable<Usuario> GetAllUsuarios()
        {
            throw new NotImplementedException();
        }

        public string UpdateUsuario(Usuario usuario)
        {
           return _IUsuarioRepositoryDomain.UpdateUsuario(usuario);
        }

        public void RemoveUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
