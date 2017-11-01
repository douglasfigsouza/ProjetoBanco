using ProjetoBanco.Domain.Agencias;
using ProjetoBanco.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ProjetoBanco.Infra.Data.Repositories
{
    public class AgenciaRepository : IAgenciaRepository
    {
        private readonly Conexao _conn;
        private Notifications _notifications;
        public enum Procedures
        {
            PBSP_INSERTAGENCIA,
            PBSP_GETALLAGENCIAS,
            PBSP_GETAGENCIABYNUM,
            PBSP_UPDATEAGENCIA
        }
        public AgenciaRepository(Conexao conn, Notifications notifications)
        {
            _conn = conn;
            _notifications = notifications;
        }

        public void AddAgencia(Agencia agencia)
        {
            try
            {
                _conn.ExecuteProcedure(Procedures.PBSP_INSERTAGENCIA);
                _conn.AddParameter("@cidadeId", agencia.CidadeId);
                _conn.AddParameter("@bancoId", agencia.bancoId);
                _conn.AddParameter("@agencia", agencia.agencia);
                _conn.AddParameter("@ativo", agencia.agencia);
                _conn.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível cadastrar agência! Erro {e.Message}");
            }

        }

        public IEnumerable<Agencia> GetAllAgencias()
        {
            SqlDataReader result = null;
            var Agencias = new List<Agencia>();
            try
            {
                _conn.ExecuteProcedure(Procedures.PBSP_GETALLAGENCIAS);
                result = _conn.ExecuteReader();
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível buscar agências! Erro {e.Message}");
            }
            while (result.Read())
            {
                Agencias.Add(new Agencia
                {
                    bancoId = Convert.ToInt32(result["bancoId"].ToString()),
                    agencia = Convert.ToInt32(result["agencia"].ToString()),
                    CidadeId = Convert.ToInt32(result["CidadeId"].ToString()),
                    ativo = Convert.ToBoolean(result["ativo"].ToString())
                });
            }
            if (Agencias.Count == 0)
            {
                _notifications.Notificacoes.Add("Nenhuma agência cadastrada!");
            }
            return Agencias.ToList();
        }
        public void UpdateAgencia(Agencia agencia)
        {
            _conn.ExecuteProcedure(Procedures.PBSP_UPDATEAGENCIA);
            _conn.AddParameter("@agencia", agencia.agencia);
            _conn.AddParameter("@ativo", agencia.ativo);
            try
            {
                _conn.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível cadastrar agencia! Erro {e.Message}");
            }
        }
        public Agencia GetAgenciaByNum(int agencia)
        {
            SqlDataReader result = null;
            Agencia Agencia = null;
            _conn.ExecuteProcedure(Procedures.PBSP_GETAGENCIABYNUM);
            _conn.AddParameter("@agencia", agencia);
            try
            {
                result = _conn.ExecuteReader();
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível buscar agencias! Erro {e.Message}");
            }
            while (result.Read())
            {
                Agencia = new Agencia
                {
                    agencia = int.Parse(result["agencia"].ToString()),
                    banco = result["nome"].ToString(),
                    ativo = Convert.ToBoolean(result["ativo"].ToString()),
                };
            }
            if (Agencia == null)
            {
                _notifications.Notificacoes.Add("Nenhuma agência encontrada!");
            }
            return Agencia;
        }
    }
}
