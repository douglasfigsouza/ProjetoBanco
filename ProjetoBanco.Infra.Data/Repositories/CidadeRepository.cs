using ProjetoBanco.Domain.Cidades;
using ProjetoBanco.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProjetoBanco.Infra.Data.Repositories
{
    public class CidadeRepository : ICidadeRepository
    {
        private readonly Conexao _conn;
        private Notifications _notifications;

        public CidadeRepository(Conexao conn, Notifications notifications)
        {
            _conn = conn;
            _notifications = notifications;
        }
        public enum Procedures
        {
            PBSP_GETCIDADESBYIDESTADO
        }
        public IEnumerable<Cidade> GetCidadesByEstadoId(int id)
        {
            _conn.ExecuteProcedure(Procedures.PBSP_GETCIDADESBYIDESTADO);
            _conn.AddParameter("@id", id);
            SqlDataReader result = null;
            try
            {
                result = _conn.ExecuteReader();
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível buscar cidades! Erro {e.Message}");
            }
            List<Cidade> cidades = new List<Cidade>();
            while (result.Read())
            {
                cidades.Add(new Cidade
                {
                    cidadeId = Convert.ToInt32(result["CidadeId"].ToString()),
                    Nome = result["Nome"].ToString()
                });
            }
            if (cidades.Count == 0)
            {
                _notifications.Notificacoes.Add("Não foi possível buscar cidades!");
            }
            return cidades;
        }
    }
}
