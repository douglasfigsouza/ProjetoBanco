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
        public enum Procedures
        {
            PBSP_INSERTAGENCIA
        }
        public AgenciaRepository()
        {
            conn = new Conexao();
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
            throw new NotImplementedException();
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
