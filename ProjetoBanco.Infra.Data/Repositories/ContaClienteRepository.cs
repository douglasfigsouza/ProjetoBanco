using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Interfaces.IRepositories;

namespace ProjetoBanco.Infra.Data.Repositories
{
    public class ContaClienteRepository:IContaClienteRepositoryDomain
    {
        private Conexao conn;
        private SqlDataReader result;
        private int contaId;

        public enum Procedure
        {
            PBSP_INSERTCONTA,
            PBSP_INSERTCONTACLIENTE
        }

        public ContaClienteRepository()
        {
            conn = new Conexao();
        }

        public void AddContaCliente(Conta conta, List<Domain.Entities.ContaCliente> contaClientes)
        {
            try
            {
                conn.ExecuteProcedure(Procedure.PBSP_INSERTCONTA);
                conn.AddParameter("@num", conta.num);
                conn.AddParameter("@senha", conta.senha);
                conn.AddParameter("@tipo", conta.tipo);
                contaId = conn.ExecuteNonQueryWithReturn();
                foreach (var item in contaClientes)
                {
                    conn.ExecuteProcedure(Procedure.PBSP_INSERTCONTACLIENTE);
                    conn.AddParameter("@contaId", contaId);
                    conn.AddParameter("@clienteId", item.clienteId);
                    conn.AddParameter("@agencia", item.agencia);
                    conn.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
