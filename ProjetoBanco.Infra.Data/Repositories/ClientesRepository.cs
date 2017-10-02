using System;
using System.Collections.Generic;
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

        private enum Procedures
        {
            PBSP_INSERTCLIENTE
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
            throw new NotImplementedException();
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
