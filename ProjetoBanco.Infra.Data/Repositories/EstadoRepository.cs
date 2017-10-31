using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Estados;
using ProjetoBanco.Domain.Estados.Dto;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProjetoBanco.Infra.Data.Repositories
{
    public class EstadoRepository : IEstadoRepository
    {
        private readonly Conexao _conn;
        private Notifications _notifications;

        public EstadoRepository(Conexao conn, Notifications notifications)
        {
            _conn = conn;
            _notifications = notifications;
        }
        private enum Procedures
        {
            PBSP_GETALLESTADOS
        }
        public IEnumerable<Estado> GetAllEstados()
        {
            SqlDataReader result = null;
            List<Estado> estados = new List<Estado>();
            _conn.ExecuteProcedure(Procedures.PBSP_GETALLESTADOS);
            try
            {
                result = _conn.ExecuteReader();
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível buscar estados! Erro {e.Message}");
            }
            while (result.Read())
            {
                estados.Add(new Estado
                {
                    Sigla = result["Sigla"].ToString(),
                    EstadoId = Convert.ToInt32(result["EstadoId"].ToString())
                });
            }
            if (estados.Count == 0)
            {
                _notifications.Notificacoes.Add("Nenhum estado cadastrado!");
            }
            return estados;
        }
    }
}
