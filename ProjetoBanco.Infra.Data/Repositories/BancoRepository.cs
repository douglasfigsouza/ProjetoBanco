using ProjetoBanco.Domain.Bancos;
using ProjetoBanco.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProjetoBanco.Infra.Data.Repositories
{
    public class BancoRepository : IBancoRepository
    {
        private readonly Conexao _conn;
        private Notifications _notifications;
        public enum Procedures
        {
            PBSP_INSERTBANCO,
            PBSP_GETALLBANCOS
        }
        public BancoRepository(Conexao conn, Notifications notifications)
        {
            _notifications = notifications;
            _conn = conn;
        }
        public void AddBanco(Banco banco)
        {
            try
            {
                _conn.ExecuteProcedure(Procedures.PBSP_INSERTBANCO);
                _conn.AddParameter("@nome", banco.nome);
                _conn.AddParameter("@ativo", banco.ativo);
                _conn.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível cadastrar banco! Erro {e.Message}");
            }

        }
        public IEnumerable<Banco> GetAllBancos()
        {
            SqlDataReader result = null;
            List<Banco> bancos = new List<Banco>();
            _conn.ExecuteProcedure(Procedures.PBSP_GETALLBANCOS);
            try
            {
                result = _conn.ExecuteReader();
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível buscar bancos! Erro {e.Message}");
            }
            while (result.Read())
            {
                bancos.Add(new Banco
                {
                    Id = Convert.ToInt32(result["Id"].ToString()),
                    nome = result["nome"].ToString()
                });
            }
            if (bancos.Count == 0)
            {
                _notifications.Notificacoes.Add("Não existem bancos cadastrados!");
            }
            return bancos;
        }
    }
}
