using ProjetoBanco.Domain.Agencias;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ProjetoBanco.Infra.Data.Repositories
{
    public class AgenciaRepository : IAgenciaRepository
    {
        private readonly Conexao _conn;
        public enum Procedures
        {
            PBSP_INSERTAGENCIA,
            PBSP_GETALLAGENCIAS,
            PBSP_GETAGENCIABYNUM,
            PBSP_UPDATEAGENCIA
        }
        public AgenciaRepository(Conexao conn)
        {
            _conn = conn;
        }

        public void AddAgencia(Agencia agencia)
        {

            _conn.ExecuteProcedure(Procedures.PBSP_INSERTAGENCIA);
            _conn.AddParameter("@cidadeId", agencia.CidadeId);
            _conn.AddParameter("@bancoId", agencia.bancoId);
            _conn.AddParameter("@agencia", agencia.agencia);
            _conn.AddParameter("@ativo", agencia.agencia);
            _conn.ExecuteNonQuery();

        }

        public IEnumerable<Agencia> GetAllAgencias()
        {
            SqlDataReader result = null;
            var Agencias = new List<Agencia>();

            _conn.ExecuteProcedure(Procedures.PBSP_GETALLAGENCIAS);
            result = _conn.ExecuteReader();

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
            return Agencias.ToList();
        }
        public void UpdateAgencia(Agencia agencia)
        {
            _conn.ExecuteProcedure(Procedures.PBSP_UPDATEAGENCIA);
            _conn.AddParameter("@agencia", agencia.agencia);
            _conn.AddParameter("@ativo", agencia.ativo);
            _conn.ExecuteNonQuery();
        }
        public Agencia GetAgenciaByNum(int agencia)
        {
            SqlDataReader result = null;
            Agencia Agencia = null;
            _conn.ExecuteProcedure(Procedures.PBSP_GETAGENCIABYNUM);
            _conn.AddParameter("@agencia", agencia);
            result = _conn.ExecuteReader();
            while (result.Read())
            {
                Agencia = new Agencia
                {
                    agencia = int.Parse(result["agencia"].ToString()),
                    banco = result["nome"].ToString(),
                    ativo = Convert.ToBoolean(result["ativo"].ToString()),
                };
            }
            return Agencia;
        }
    }
}
