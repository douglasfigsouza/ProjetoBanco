using ProjetoBanco.Domain.Agencias;
using System;
using System.Collections.Generic;
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

        public void AddAgencia(AgenciaDto agencia)
        {

            _conn.ExecuteProcedure(Procedures.PBSP_INSERTAGENCIA);
            _conn.AddParameter("@cidadeId", agencia.CidadeId);
            _conn.AddParameter("@bancoId", agencia.bancoId);
            _conn.AddParameter("@agencia", agencia.agencia);
            _conn.AddParameter("@ativo", agencia.agencia);
            _conn.ExecuteNonQuery();

        }

        public IEnumerable<AgenciaDto> GetAllAgencias()
        {
            var Agencias = new List<AgenciaDto>();

            _conn.ExecuteProcedure(Procedures.PBSP_GETALLAGENCIAS);

            using (var result = _conn.ExecuteReader())
                while (result.Read())
                {
                    Agencias.Add(new AgenciaDto
                    {
                        bancoId = Convert.ToInt32(result["bancoId"].ToString()),
                        agencia = Convert.ToInt32(result["agencia"].ToString()),
                        CidadeId = Convert.ToInt32(result["CidadeId"].ToString()),
                        ativo = Convert.ToBoolean(result["ativo"].ToString())
                    });
                }
            return Agencias.ToList();
        }
        public void UpdateAgencia(AgenciaDto agencia)
        {
            _conn.ExecuteProcedure(Procedures.PBSP_UPDATEAGENCIA);
            _conn.AddParameter("@agencia", agencia.agencia);
            _conn.AddParameter("@ativo", agencia.ativo);
            _conn.ExecuteNonQuery();
        }
        public AgenciaDto GetAgenciaByNum(int agencia)
        {
            AgenciaDto Agencia = null;
            _conn.ExecuteProcedure(Procedures.PBSP_GETAGENCIABYNUM);
            _conn.AddParameter("@agencia", agencia);
            using (var result = _conn.ExecuteReader())
                while (result.Read())
                {
                    Agencia = new AgenciaDto
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
