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
    public class ClientesRepository:IClienteRepositoryDomain
    {
        Conexao conn = new Conexao();
        private SqlDataReader result;
        private List<Cliente> lstClientes;

        public ClientesRepository()
        {
            lstClientes = new List<Cliente>();
        }

        private enum Procedures
        {
            PBSP_INSERTCLIENTE,
            PBSP_GETALLCLIENTES
        }

        public void AddCliente(Cliente cliente)
        {
            conn.ExecuteProcedure(Procedures.PBSP_INSERTCLIENTE);
            conn.AddParameter("@cidadeId", cliente.cidadeId);
            conn.AddParameter("@nome", cliente.nome);
            conn.AddParameter("@cpf", cliente.cpf);
            conn.AddParameter("@rg", cliente.rg);
            conn.AddParameter("@fone", cliente.fone);
            conn.AddParameter("@bairro", cliente.bairro);
            conn.AddParameter("@rua", cliente.rua);
            conn.AddParameter("@num", cliente.num);
            conn.AddParameter("@dataCadastro", cliente.dataCadastro);
            conn.AddParameter("@nivel", cliente.nivel);
            conn.AddParameter("@ativo", cliente.ativo);

            conn.ExecuteNonQuery();
        }

        public Cliente GetByClienteId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> GetAllClientes()
        {
            conn.ExecuteProcedure(Procedures.PBSP_GETALLCLIENTES);
            result = conn.ExecuteReader();
            while (result.Read())
            {
                lstClientes.Add(new Cliente
                {
                    Id = Convert.ToInt32(result["Id"].ToString()),
                    nome = result["nome"].ToString(),
                    cpf = result["cpf"].ToString(),
                    rg = result["rg"].ToString(),
                    rua = result["rua"].ToString(),
                    fone = result["fone"].ToString(),
                    bairro = result["bairro"].ToString(),
                    nivel = Convert.ToChar(result["nivel"].ToString()),
                    num = Convert.ToInt32(result["num"].ToString()),
                    dataCadastro = Convert.ToDateTime(result["dataCadastro"].ToString())
                });
            }
            return lstClientes.ToList();
        }

        public void UpdateClientes(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void RemoveClientes(Cliente obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
