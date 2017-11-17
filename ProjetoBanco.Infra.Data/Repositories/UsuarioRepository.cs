using ProjetoBanco.Domain.Usuarios;
using System;
using System.Collections.Generic;

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
        public void PostUsuario(UsuarioDto usuario)
        {
            _conn.ExecuteProcedure(Procedures.PBSP_INSERTUSUARIOS);
            _conn.AddParameter("@clienteId", usuario.clienteId);
            _conn.AddParameter("@nome", usuario.nome);
            _conn.AddParameter("@senha", usuario.senha);
            _conn.AddParameter("@ativo", true);
            _conn.ExecuteNonQuery();
        }

        public UsuarioDto VerificaLogin(UsuarioDto usuario)
        {

            _conn.ExecuteProcedure(Procedures.PBSP_AUTENTICA);
            _conn.AddParameter("@nome", usuario.nome);
            _conn.AddParameter("@senha", usuario.senha);
            usuario = null;
            // cria a variavel e ao termino do uso ja limpa da memoria e realiza o dispose 
            using (var result = _conn.ExecuteReader())
                while (result.Read())
                {
                    usuario = new UsuarioDto();
                    usuario.clienteId = int.Parse(result["clienteId"].ToString());
                    usuario.nome = result["nome"].ToString();
                    usuario.senha = result["senha"].ToString();
                    usuario.nivel = char.Parse(result["nivel"].ToString());
                }
            return usuario;
        }

        public UsuarioDto GetByUsuarioId(int id)
        {
            UsuarioDto usuario = null;
            _conn.ExecuteProcedure(Procedures.PBSP_GETBYUSUARIOID);
            _conn.AddParameter("@id", id);
            using (var result = _conn.ExecuteReader())
                while (result.Read())
                {
                    usuario = new UsuarioDto
                    {
                        clienteId = Convert.ToInt32(result["clienteId"].ToString()),
                        nome = result["nome"].ToString(),
                        senha = result["senha"].ToString(),
                        ativo = Convert.ToBoolean(result["ativo"].ToString())
                    };
                }
            return usuario;
        }
        public IEnumerable<UsuarioDto> GetAllUsuarios()
        {
            List<UsuarioDto> usuarios = new List<UsuarioDto>();
            _conn.ExecuteProcedure(Procedures.PBSP_GETALLUSERS);
            using (var result = _conn.ExecuteReader())
                while (result.Read())
                {
                    usuarios.Add(new UsuarioDto
                    {
                        clienteId = Convert.ToInt32(result["clienteId"].ToString()),
                        nome = result["usuNome"].ToString(),
                        senha = result["senha"].ToString(),
                        nomeCli = result["cliNome"].ToString()
                    });
                }
            return usuarios;
        }
        public void PutUsuario(UsuarioDto usuario)
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
