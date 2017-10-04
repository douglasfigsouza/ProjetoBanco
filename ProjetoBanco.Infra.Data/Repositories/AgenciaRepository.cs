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
    public class AgenciaRepository:IAgenciaRepositoryDomain
    {
        private Conexao conn;
        private SqlDataReader result;
        private List<Agencia> Agencias;
        public enum Procedures
        {
            PBSP_INSERTAGENCIA,
            PBSP_GETALLAGENCIAS
        }
        public AgenciaRepository()
        {
            conn = new Conexao();
            Agencias = new List<Agencia>();
        }

        public void AddAgencia(Agencia agencia)
        {
            try
            {
                conn.ExecuteProcedure(Procedures.PBSP_INSERTAGENCIA);
                conn.AddParameter("@cidadeId", agencia.CidadeId);
                conn.AddParameter("@bancoId", agencia.bancoId);
                conn.AddParameter("@agencia", agencia.agencia);
                conn.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public Agencia GetByAgenciaId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Agencia> GetAllAgencias()
        {
            conn.ExecuteProcedure(Procedures.PBSP_GETALLAGENCIAS);
            result = conn.ExecuteReader();
            while (result.Read())
            {
                Agencias.Add(new Agencia
                {
                    bancoId = Convert.ToInt32(result["bancoId"].ToString()),
                    agencia = Convert.ToInt32(result["agencia"].ToString()),
                    CidadeId = Convert.ToInt32(result["CidadeId"].ToString())
                });
            }
            return Agencias.ToList();
        }

        public void UpdateAgencia(Agencia agencia)
        {
            throw new NotImplementedException();
        }

        public void RemoveAgencia(Agencia agencia)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
