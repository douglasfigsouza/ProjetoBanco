using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProjetoBanco.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Conexao _conn;
        private Notifications _notifications;
        public enum Procedures
        {
            PBSP_INSERTUSUARIOS,
            PBSP_AUTENTICA,
            PBSP_GETALLUSERS,
            PBSP_GETBYUSUARIOID,
            PBSP_UPDATEUSUARIO
        }

        public UsuarioRepository(Conexao conn, Notifications notifications)
        {
            _conn = conn;
            _notifications = notifications;
        }
        public void AddUsuario(Usuario usuario)
        {
            _conn.ExecuteProcedure(Procedures.PBSP_INSERTUSUARIOS);
            _conn.AddParameter("@clienteId", usuario.clienteId);
            _conn.AddParameter("@nome", usuario.nome);
            _conn.AddParameter("@senha", usuario.senha);
            try
            {
                _conn.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível cadastrar usuário! Erro {e.Message}");
            }
        }

        public Usuario VerificaLogin(Usuario usuario)
        {
            SqlDataReader result = null;
            _conn.ExecuteProcedure(Procedures.PBSP_AUTENTICA);
            _conn.AddParameter("@nome", usuario.nome);
            _conn.AddParameter("@senha", usuario.senha);
            usuario = null;
            try
            {
                result = _conn.ExecuteReader();
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível fazer login! Erro {e.Message}");
            }
            while (result.Read())
            {
                usuario = new Usuario();
                usuario.clienteId = int.Parse(result["clienteId"].ToString());
                usuario.nome = result["nome"].ToString();
                usuario.senha = result["senha"].ToString();
                usuario.nivel = char.Parse(result["nivel"].ToString());
            }
            if (usuario == null)
            {
                _notifications.Notificacoes.Add("Usuário ou senha inválidos!");
            }
            return usuario;
        }

        public Usuario GetByUsuarioId(int id)
        {
            SqlDataReader result = null;
            Usuario usuario = null;
            _conn.ExecuteProcedure(Procedures.PBSP_GETBYUSUARIOID);
            _conn.AddParameter("@id", id);
            try
            {
                result = _conn.ExecuteReader();
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível buscar usuários! Erro {e.Message}");
            }
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
            if (usuario == null)
            {
                _notifications.Notificacoes.Add("Não existem usuários cadastrados!");
            }
            return usuario;
        }
        public IEnumerable<Usuario> GetAllUsuarios()
        {
            SqlDataReader result = null;
            List<Usuario> usuarios = new List<Usuario>();
            _conn.ExecuteProcedure(Procedures.PBSP_GETALLUSERS);

            try
            {
                result = _conn.ExecuteReader();
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível buscar usuários! Erro {e.Message}");
            }
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
            if (usuarios.Count == 0)
            {
                _notifications.Notificacoes.Add("Não existem usuários!");
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
            try
            {
                _conn.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível atualizar usuários! Erro {e.Message}");
            }
        }
    }
}
