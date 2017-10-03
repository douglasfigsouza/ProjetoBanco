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
        private Usuario usuario;

        public enum Procedures
        {
            PBSP_INSERTUSUARIOS,
            PBSP_AUTENTICA
        }

        public UsuarioRepository()
        {
            conn = new Conexao();
            usuario = new Usuario();
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
            conn.ExecuteProcedure(Procedures.PBSP_AUTENTICA);
            conn.AddParameter("@nome",usuario.nome);
            conn.AddParameter("@senha",usuario.senha);
            result = conn.ExecuteReader();
            while (result.Read())
            {
                usuario.clienteId = Convert.ToInt32(result["clienteId"].ToString());
                usuario.nome = result["nome"].ToString();
                usuario.senha = result["senha"].ToString();
                usuario.nivel = Convert.ToChar(result["nivel"].ToString());
            }
            return usuario;
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
