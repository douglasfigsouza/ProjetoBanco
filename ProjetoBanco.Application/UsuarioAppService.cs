using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Interfaces.IRepositories;
using ProjetoBanco.Domain.Interfaces.IServices;

namespace ProjetoBanco.Application
{
    public class UsuarioAppService:IUsuarioAppService
    {
        private readonly IUsuariosServiceDomain _UsuarioServiceDomain;
        private readonly IUsuarioRepositoryDomain _UsuarioRepositoryDomain;

        public UsuarioAppService(IUsuariosServiceDomain IUsuarioServiceDomain, IUsuarioRepositoryDomain UsuarioRepositoryDomain)
        {
            _UsuarioServiceDomain = IUsuarioServiceDomain;
            _UsuarioRepositoryDomain = UsuarioRepositoryDomain;
        }
        public void AddUsuario(Usuario usuario)
        {
           _UsuarioRepositoryDomain.AddUsuario(usuario);
        }

        public Usuario GetByUsuarioId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> GetAllUsuarios()
        {
            throw new NotImplementedException();
        }

        public void UpdateUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void RemoveUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Usuario VerificaLogin(Usuario usuario)
        {
           return _UsuarioRepositoryDomain.VerificaLogin(usuario);
        }
    }
}
