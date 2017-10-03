using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Interfaces.IRepositories;

namespace ProjetoBanco.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepositoryDomain
    {
        private Conexao conn;
        private SqlDataReader result;

        public enum Procedures
        {
            PBSP_INSERTUSUARIOS
        }

        public UsuarioRepository()
        {
            conn = new Conexao();
        }
        public void AddUsuario(Usuario usuario)
        {
            conn.ExecuteProcedure(Procedures.PBSP_INSERTUSUARIOS);
            conn.AddParameter("@clienteId", usuario.clienteId);
            conn.AddParameter("@nome", usuario.nome);
            conn.AddParameter("@senha", usuario.senha);
            conn.ExecuteNonQuery();
        }

        public Usuario VerificaLogin(Usuario usuario)
        {
            throw new NotImplementedException();
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
    }
}
