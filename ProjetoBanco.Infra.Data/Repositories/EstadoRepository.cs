using ProjetoBanco.Domain.Estados;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProjetoBanco.Infra.Data.Repositories
{
    public class EstadoRepository : IEstadoRepository
    {
        private readonly Conexao _conn;

        public EstadoRepository(Conexao conn)
        {
            _conn = conn;
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
            result = _conn.ExecuteReader();
            while (result.Read())
            {
                estados.Add(new Estado
                {
                    Sigla = result["Sigla"].ToString(),
                    EstadoId = Convert.ToInt32(result["EstadoId"].ToString())
                });
            }
            return estados;
        }
    }
}
