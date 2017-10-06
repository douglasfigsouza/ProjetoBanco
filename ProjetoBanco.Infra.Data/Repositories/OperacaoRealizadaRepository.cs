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
    public class OperacaoRealizadaRepository:IOperacoesRealizadasRepositoryDomain
    {
        private Conexao conn;
        private SqlDataReader result;
        private enum Procedure
        {
            PBSP_INSERTOPREALIZADA
        }

        public OperacaoRealizadaRepository()
        {
            conn= new Conexao();
        }
        public void AddOpRealizada(OperacaoRealizada operacaoRealizada, int op)
        {
            conn.ExecuteProcedure(Procedure.PBSP_INSERTOPREALIZADA);
            conn.AddParameter("@operacaoId",op);
            conn.AddParameter("@agencia", operacaoRealizada.agencia);
            conn.AddParameter("@contaId", operacaoRealizada.contaId);
            conn.AddParameter("@clienteId", operacaoRealizada.clienteId);
            conn.AddParameter("@dataOp", operacaoRealizada.dataOp);
            conn.AddParameter("@valorOp", operacaoRealizada.valorOp);
            conn.ExecuteNonQuery();

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
