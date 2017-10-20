using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Interfaces.IRepositories;

namespace ProjetoBanco.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepositoryDomain
    {
        private Conexao conn;
        private SqlDataReader result;
        private Usuario usuario;
        private List<Usuario> Usuarios;
        public enum Procedures
        {
            PBSP_INSERTUSUARIOS,
            PBSP_AUTENTICA,
            PBSP_GETALLUSERS,
            PBSP_GETBYUSUARIOID,
            PBSP_UPDATEUSUARIO
        }

        public UsuarioRepository()
        {
            conn = new Conexao();
            usuario = new Usuario();
            Usuarios = new List<Usuario>();
        }
        public string AddUsuario(Usuario usuario)
        {
            try
            {
                conn.ExecuteProcedure(Procedures.PBSP_INSERTUSUARIOS);
                conn.AddParameter("@clienteId", usuario.clienteId);
                conn.AddParameter("@nome", usuario.nome);
                conn.AddParameter("@senha", usuario.senha);
                conn.ExecuteNonQuery();
                return null;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        public Usuario VerificaLogin(Usuario usuario)
        {
            conn.ExecuteProcedure(Procedures.PBSP_AUTENTICA);
            conn.AddParameter("@nome", usuario.nome);
            conn.AddParameter("@senha", usuario.senha);
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
            conn.ExecuteProcedure(Procedures.PBSP_GETBYUSUARIOID);
            conn.AddParameter("@id", id);
            result = conn.ExecuteReader();
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
            conn.ExecuteProcedure(Procedures.PBSP_GETALLUSERS);
            result = conn.ExecuteReader();
            while (result.Read())
            {
                Usuarios.Add(new Usuario
                {
                    clienteId = Convert.ToInt32(result["clienteId"].ToString()),
                    nome = result["usuNome"].ToString(),
                    senha = result["senha"].ToString(),
                    nomeCli = result["cliNome"].ToString()
                });
            }
            return Usuarios;
        }
        public string UpdateUsuario(Usuario usuario)
        {
            try
            {
                conn.ExecuteProcedure(Procedures.PBSP_UPDATEUSUARIO);
                conn.AddParameter("@clienteId", usuario.clienteId);
                conn.AddParameter("@nome", usuario.nome);
                conn.AddParameter("@senha", usuario.senha);
                conn.AddParameter("@ativo", usuario.ativo);
                conn.ExecuteNonQuery();
                return null;
            }
            catch (Exception e)
            {
                return e.Message;
            }
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
