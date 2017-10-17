using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Interfaces.IRepositories;

namespace ProjetoBanco.Infra.Data.Repositories
{
    public class ClientesRepository : IClienteRepositoryDomain
    {
        Conexao conn = new Conexao();
        private SqlDataReader result;
        private List<Cliente> lstClientes;
        private Cliente cliente;

        public ClientesRepository()
        {
            lstClientes = new List<Cliente>();
        }

        private enum Procedures
        {
            PBSP_INSERTCLIENTE,
            PBSP_GETALLCLIENTES,
            PBSP_GETCLIENTEBYID,
            PBSP_UPDATECLIENTE,
            PBSP_GETCLIENTEBYCPF
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
            conn.ExecuteProcedure(Procedures.PBSP_GETCLIENTEBYID);
            conn.AddParameter("@id", id);
            result = conn.ExecuteReader();
            while (result.Read())
            {
                cliente = new Cliente
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
                    dataCadastro = Convert.ToDateTime(result["dataCadastro"].ToString()),
                    ativo = Convert.ToBoolean(result["ativo"].ToString()),
                    cidadeId = Convert.ToInt32(result["CidadeId"].ToString()),
                    estadoId = Convert.ToInt32(result["EstadoId"].ToString())
                };
            }
            return cliente;
        }

        public IEnumerable<Cliente> GetAllClientes(int op)
        {
            conn.ExecuteProcedure(Procedures.PBSP_GETALLCLIENTES);
            conn.AddParameter("@op", op);
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
            conn.ExecuteProcedure(Procedures.PBSP_UPDATECLIENTE);
            conn.AddParameter("@id", cliente.Id);
            conn.AddParameter("@cidadeId", cliente.cidadeId);
            conn.AddParameter("@nome", cliente.nome);
            conn.AddParameter("@cpf", cliente.cpf);
            conn.AddParameter("@rg", cliente.rg);
            conn.AddParameter("@fone", cliente.fone);
            conn.AddParameter("@bairro", cliente.bairro);
            conn.AddParameter("@rua", cliente.rua);
            conn.AddParameter("@num", cliente.num);
            conn.AddParameter("@nivel", cliente.nivel);
            conn.AddParameter("@ativo", cliente.ativo);
            conn.ExecuteNonQuery();
        }

        public void RemoveClientes(Cliente obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Cliente GetClienteByCpf(string cpf)
        {
            conn.ExecuteProcedure(Procedures.PBSP_GETCLIENTEBYCPF);
            conn.AddParameter("@cpf", cpf);
            result = conn.ExecuteReader();
            while (result.Read())
            {
                cliente = new Cliente
                {
                    Id = int.Parse(result["Id"].ToString()),
                    nome = result["nome"].ToString()
                };
            }
            return cliente;
        }
    }
}
