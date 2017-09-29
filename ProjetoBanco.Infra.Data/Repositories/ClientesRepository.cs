using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Interfaces.IRepositories;

namespace ProjetoBanco.Infra.Data.Repositories
{
    class ClientesRepository:IClienteRepositoryDomain
    {
        Conexao conn = new Conexao();

        private enum Procedures
        {
            PBSP_INSERTCLI
        }
        public void Add(Cliente cliente)
        {

            conn.ExecuteProcedure(Procedures.PBSP_INSERTCLI);
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

        public Cliente GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void Remove(Cliente obj)
        {
            throw new NotImplementedException();
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
