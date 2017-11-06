using ProjetoBanco.Domain.Cidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProjetoBanco.Infra.Data.Repositories
{
    public class CidadeRepository : ICidadeRepository
    {
        private readonly Conexao _conn;
        public CidadeRepository(Conexao conn)
        {
            _conn = conn;
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
            result = _conn.ExecuteReader();
            List<Cidade> cidades = new List<Cidade>();
            while (result.Read())
            {
                cidades.Add(new Cidade
                {
                    cidadeId = Convert.ToInt32(result["CidadeId"].ToString()),
                    Nome = result["Nome"].ToString()
                });
            }
            return cidades;
        }
    }
}
