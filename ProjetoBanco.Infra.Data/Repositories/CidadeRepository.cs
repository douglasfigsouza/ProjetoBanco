using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Interfaces.IRepositories;

namespace ProjetoBanco.Infra.Data.Repositories
{
    public class CidadeRepository:ICidadeRepositoryDomain
    {
        private  Conexao conn;
        private SqlDataReader result;
        private List<Cidade> lstCidades;

        public CidadeRepository()
        {
            lstCidades = new List<Cidade>();
        }
        public enum Procedures
        {
            PBSP_GETCIDADESBYIDESTADO
        }

        public Cidade GetByCidadeId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cidade> GetCidadesByEstadoId(int id)
        {
            conn = new Conexao();
            conn.ExecuteProcedure(Procedures.PBSP_GETCIDADESBYIDESTADO);
            conn.AddParameter("@id", id);
            result = conn.ExecuteReader();
            while (result.Read())
            {
                lstCidades.Add(new Cidade
                {
                    cidadeId = Convert.ToInt32(result["CidadeId"].ToString()),
                    Nome = result["Nome"].ToString()
                });
            }
            return lstCidades.ToList();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
