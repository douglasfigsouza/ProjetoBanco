using ProjetoBanco.Domain.Clientes;
using ProjetoBanco.Domain.Clientes.Dto;
using ProjetoBanco.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ProjetoBanco.Infra.Data.Repositories
{
    public class ClientesRepository : IClienteRepository
    {
        private readonly Conexao _conn;
        private Notifications _notifications;
        private SqlDataReader result;
        private List<Cliente> lstClientes;
        private Cliente cliente;


        public ClientesRepository(Notifications notifications, Conexao conn)
        {
            lstClientes = new List<Cliente>();
            _notifications = notifications;
            _conn = conn;

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
            try
            {
                _conn.ExecuteProcedure(Procedures.PBSP_INSERTCLIENTE);
                _conn.AddParameter("@cidadeId", cliente.cidadeId);
                _conn.AddParameter("@nome", cliente.nome);
                _conn.AddParameter("@cpf", cliente.cpf);
                _conn.AddParameter("@rg", cliente.rg);
                _conn.AddParameter("@fone", cliente.fone);
                _conn.AddParameter("@bairro", cliente.bairro);
                _conn.AddParameter("@rua", cliente.rua);
                _conn.AddParameter("@num", cliente.num);
                _conn.AddParameter("@dataCadastro", cliente.dataCadastro);
                _conn.AddParameter("@nivel", cliente.nivel);
                _conn.AddParameter("@ativo", cliente.ativo);
                _conn.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível cadastrar cliente! {e.Message}");
            }

        }

        public Cliente GetByClienteId(int id)
        {
            _conn.ExecuteProcedure(Procedures.PBSP_GETCLIENTEBYID);
            _conn.AddParameter("@id", id);
            try
            {
                result = _conn.ExecuteReader();
            }
            catch (Exception ex)
            {
                _notifications.Notificacoes.Add($"Impossível buscar clientes {ex.Message}");
            }
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
            if (cliente == null)
            {
                _notifications.Notificacoes.Add("Não existem clientes cadastrados!");
            }
            return cliente;
        }

        public IEnumerable<Cliente> GetAllClientes(int op)
        {
            _conn.ExecuteProcedure(Procedures.PBSP_GETALLCLIENTES);
            //o parametro 0 é para recuperar todos os clientes ativos e nao ativos
            _conn.AddParameter("@op", op);
            result = _conn.ExecuteReader();
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
            try
            {
                _conn.ExecuteProcedure(Procedures.PBSP_UPDATECLIENTE);
                _conn.AddParameter("@id", cliente.Id);
                _conn.AddParameter("@cidadeId", cliente.cidadeId);
                _conn.AddParameter("@nome", cliente.nome);
                _conn.AddParameter("@cpf", cliente.cpf);
                _conn.AddParameter("@rg", cliente.rg);
                _conn.AddParameter("@fone", cliente.fone);
                _conn.AddParameter("@bairro", cliente.bairro);
                _conn.AddParameter("@rua", cliente.rua);
                _conn.AddParameter("@num", cliente.num);
                _conn.AddParameter("@nivel", cliente.nivel);
                _conn.AddParameter("@ativo", cliente.ativo);
                _conn.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível atualizar cliente! Erro  {e.Message}");
            }

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
            _conn.ExecuteProcedure(Procedures.PBSP_GETCLIENTEBYCPF);
            _conn.AddParameter("@cpf", cpf);
            result = _conn.ExecuteReader();
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
