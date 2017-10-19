using System;
using System.Collections.Generic;
using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Interfaces.IRepositories;
using ProjetoBanco.Domain.Interfaces.IServices;

namespace ProjetoBanco.Application
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuariosServiceDomain _UsuarioServiceDomain;
        private readonly IUsuarioRepositoryDomain _UsuarioRepositoryDomain;

        public UsuarioAppService(IUsuariosServiceDomain IUsuarioServiceDomain, IUsuarioRepositoryDomain UsuarioRepositoryDomain)
        {
            _UsuarioServiceDomain = IUsuarioServiceDomain;
            _UsuarioRepositoryDomain = UsuarioRepositoryDomain;
        }
        public string AddUsuario(Usuario usuario)
        {
            return _UsuarioRepositoryDomain.AddUsuario(usuario);
        }

        public Usuario GetByUsuarioId(int id)
        {
            return _UsuarioRepositoryDomain.GetByUsuarioId(id);
        }

        public IEnumerable<Usuario> GetAllUsuarios()
        {
            return _UsuarioRepositoryDomain.GetAllUsuarios();
        }

        public string UpdateUsuario(Usuario usuario)
        {
           return _UsuarioRepositoryDomain.UpdateUsuario(usuario);
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
