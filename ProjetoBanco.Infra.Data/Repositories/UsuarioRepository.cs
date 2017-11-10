using ProjetoBanco.Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProjetoBanco.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Conexao _conn;
        public enum Procedures
        {
            PBSP_INSERTUSUARIOS,
            PBSP_AUTENTICA,
            PBSP_GETALLUSERS,
            PBSP_GETBYUSUARIOID,
            PBSP_UPDATEUSUARIO
        }

        public UsuarioRepository(Conexao conn)
        {
            _conn = conn;
        }
        public void AddUsuario(Usuario usuario)
        {
            _conn.ExecuteProcedure(Procedures.PBSP_INSERTUSUARIOS);
            _conn.AddParameter("@clienteId", usuario.clienteId);
            _conn.AddParameter("@nome", usuario.nome);
            _conn.AddParameter("@senha", usuario.senha);
            _conn.AddParameter("@ativo", true);
            _conn.ExecuteNonQuery();
        }

        public Usuario VerificaLogin(Usuario usuario)
        {
            SqlDataReader result = null;
            _conn.ExecuteProcedure(Procedures.PBSP_AUTENTICA);
            _conn.AddParameter("@nome", usuario.nome);
            _conn.AddParameter("@senha", usuario.senha);
            usuario = null;
            result = _conn.ExecuteReader();
            while (result.Read())
            {
                usuario = new Usuario();
                usuario.clienteId = int.Parse(result["clienteId"].ToString());
                usuario.nome = result["nome"].ToString();
                usuario.senha = result["senha"].ToString();
                usuario.nivel = char.Parse(result["nivel"].ToString());
            }
            return usuario;
        }

        public Usuario GetByUsuarioId(int id)
        {
            SqlDataReader result = null;
            Usuario usuario = null;
            _conn.ExecuteProcedure(Procedures.PBSP_GETBYUSUARIOID);
            _conn.AddParameter("@id", id);
            result = _conn.ExecuteReader();
            while (result.Read())
            {
                usuario = new Usuario
                {
                    clienteId = Convert.ToInt32(result["clienteId"].ToString()),
                    nome = result["nome"].ToString(),
                    senha = result["senha"].ToString(),
                    ativo = Convert.ToBoolean(result["ativo"].ToString())
                };
            }
            return usuario;
        }
        public IEnumerable<Usuario> GetAllUsuarios()
        {
            SqlDataReader result = null;
            List<Usuario> usuarios = new List<Usuario>();
            _conn.ExecuteProcedure(Procedures.PBSP_GETALLUSERS);
            result = _conn.ExecuteReader();
            while (result.Read())
            {
                usuarios.Add(new Usuario
                {
                    clienteId = Convert.ToInt32(result["clienteId"].ToString()),
                    nome = result["usuNome"].ToString(),
                    senha = result["senha"].ToString(),
                    nomeCli = result["cliNome"].ToString()
                });
            }
            return usuarios;
        }
        public void UpdateUsuario(Usuario usuario)
        {
            _conn.ExecuteProcedure(Procedures.PBSP_UPDATEUSUARIO);
            _conn.AddParameter("@clienteId", usuario.clienteId);
            _conn.AddParameter("@nome", usuario.nome);
            _conn.AddParameter("@senha", usuario.senha);
            _conn.AddParameter("@ativo", usuario.ativo);
            _conn.ExecuteNonQuery();
        }
    }
}
