using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Interfaces.IRepositories;

namespace ProjetoBanco.Infra.Data.Repositories
{
    public class ContaClienteRepository : IContaClienteRepositoryDomain
    {
        private Conexao conn;
        private SqlDataReader result;
        private int contaId;
        private ContaClienteAlteracao contaClienteAlteracao;

        public enum Procedure
        {
            PBSP_INSERTCONTA,
            PBSP_INSERTCONTACLIENTE,
            PBSP_GETCONTA,
            PBSP_UPDATECONTA
        }

        public ContaClienteRepository()
        {
            conn = new Conexao();
            contaClienteAlteracao = new ContaClienteAlteracao();
            contaClienteAlteracao.Clientes = new List<Cliente>();
        }
        public string AddContaCliente(Conta conta, List<Domain.Entities.ContaCliente> contaClientes)
        {
            try
            {
                conn.ExecuteProcedure(Procedure.PBSP_INSERTCONTA);
                conn.AddParameter("@num", conta.num);
                conn.AddParameter("@senha", conta.senha);
                conn.AddParameter("@tipo", conta.tipo);
                conn.AddParameter("@ativo", conta.ativo);
                contaId = conn.ExecuteNonQueryWithReturn();
                foreach (var item in contaClientes)
                {
                    conn.ExecuteProcedure(Procedure.PBSP_INSERTCONTACLIENTE);
                    conn.AddParameter("@contaId", contaId);
                    conn.AddParameter("@clienteId", item.clienteId);
                    conn.AddParameter("@agencia", item.agencia);
                    conn.ExecuteNonQuery();
                }
                return null;
            }
            catch (Exception e)
            {
                return e.Message;


            }
        }
        public string UpdateConta(Conta conta)
        {
            try
            {
                conn.ExecuteProcedure(Procedure.PBSP_UPDATECONTA);
                conn.AddParameter("@conta", conta.num);
                conn.AddParameter("@senha", conta.senha);
                conn.AddParameter("@ativo", conta.ativo);
                conn.ExecuteNonQuery();
                return null;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public ContaClienteAlteracao GetConta(string conta, int agencia, string senha)
        {
            try
            {
                conn.ExecuteProcedure(Procedure.PBSP_GETCONTA);
                conn.AddParameter("@conta", conta);
                conn.AddParameter("@senha", senha);
                conn.AddParameter("@agencia", agencia);
                result = conn.ExecuteReader();
                while (result.Read())
                {
                    contaClienteAlteracao.conta = result["num"].ToString();
                    contaClienteAlteracao.senha = result["senha"].ToString();
                    contaClienteAlteracao.Clientes.Add(new Cliente
                    {
                        nome = result["nome"].ToString()
                    });
                    contaClienteAlteracao.ativo = bool.Parse(result["ativo"].ToString());
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
