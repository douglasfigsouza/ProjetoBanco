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
        private ContaClienteAlteracao contaClienteAlteracao;

        public enum Procedure
        {
            PBSP_INSERTCONTA,
            PBSP_INSERTCONTACLIENTE,
            PBSP_GETCONTACLIENTE
        }

        public ContaClienteRepository()
        {
            conn = new Conexao();
            contaClienteAlteracao = new ContaClienteAlteracao();
            contaClienteAlteracao.Clientes = new List<Cliente>();
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

        public ContaClienteAlteracao GetContaCliente(string conta, int agencia, string senha)
        {
            try
            {
                conn.ExecuteProcedure(Procedure.PBSP_GETCONTACLIENTE);
                conn.AddParameter("@conta",conta);
                conn.AddParameter("@senha", senha);
                conn.AddParameter("@agencia", agencia);
                result = conn.ExecuteReader();
                while (result.Read())
                {
                    contaClienteAlteracao.conta = result["num"].ToString();
                    contaClienteAlteracao.senha = result["senha"].ToString();
                    contaClienteAlteracao.Clientes.Add(new Cliente
                    {
                        Id = int.Parse(result["Id"].ToString()),
                        nome = result["nome"].ToString()
                    });
                        
                }
                return contaClienteAlteracao;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
