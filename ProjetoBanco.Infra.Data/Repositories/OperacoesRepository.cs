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
    public class OperacoesRepository:IOperacoesRepositoryDomain
    {
        private Conexao conn;
        private SqlDataReader result;
        public enum Procedures
        {
            PBSP_INSERTOPERACAO
        }

        public OperacoesRepository()
        {
            conn = new Conexao();
        }

        public void AddOperacao(Operacoes op)
        {
            try
            {
                conn.ExecuteProcedure(Procedures.PBSP_INSERTOPERACAO);
                conn.AddParameter("@descricao", op.descricao);
                conn.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Operacoes GetOperacaoById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Operacoes> GetAllOperacoes()
        {
            throw new NotImplementedException();
        }

        public void UpdateOperacao(Operacoes op)
        {
            throw new NotImplementedException();
        }

        public void RemoveOperacao(Operacoes op)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
