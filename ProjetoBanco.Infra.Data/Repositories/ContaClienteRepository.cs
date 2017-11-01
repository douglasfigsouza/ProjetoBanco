using ProjetoBanco.Domain.Clientes.Dto;
using ProjetoBanco.Domain.Contas;
using ProjetoBanco.Domain.Entities;
using System;
using System.Data.SqlClient;

namespace ProjetoBanco.Infra.Data.Repositories
{
    public class ContaClienteRepository : IContaClienteRepository
    {
        private readonly Conexao _conn;
        private Notifications _notifications;


        public enum Procedure
        {
            PBSP_INSERTCONTA,
            PBSP_INSERTCONTACLIENTE,
            PBSP_GETCONTA,
            PBSP_UPDATECONTA
        }

        public ContaClienteRepository(Conexao conn, Notifications notifications)
        {
            _conn = conn;
            _notifications = notifications;
        }
        public void AddContaCliente(Conta conta)
        {
            _conn.ExecuteProcedure(Procedure.PBSP_INSERTCONTA);
            _conn.AddParameter("@num", conta.num);
            _conn.AddParameter("@senha", conta.senha);
            _conn.AddParameter("@tipo", conta.tipo);
            _conn.AddParameter("@ativo", conta.ativo);
            try
            {
                var contaId = _conn.ExecuteNonQueryWithReturn();
                foreach (var item in conta.contaClientes)
                {
                    _conn.ExecuteProcedure(Procedure.PBSP_INSERTCONTACLIENTE);
                    _conn.AddParameter("@contaId", contaId);
                    _conn.AddParameter("@clienteId", item.clienteId);
                    _conn.AddParameter("@agencia", item.agencia);
                    _conn.ExecuteNonQuery();
                }

            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível Cadastrar Conta! Erro {e.Message}");
            }
        }
        public void UpdateConta(Conta conta)
        {
            _conn.ExecuteProcedure(Procedure.PBSP_UPDATECONTA);
            _conn.AddParameter("@conta", conta.num);
            _conn.AddParameter("@senha", conta.senha);
            _conn.AddParameter("@ativo", conta.ativo);
            try
            {
                _conn.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível atualizar conta! Erro {e.Message}");
            }
        }
        public ContaClienteAlteracao GetConta(string conta, int agencia, string senha)
        {
            ContaClienteAlteracao contaClienteAlteracao = null;
            _conn.ExecuteProcedure(Procedure.PBSP_GETCONTA);
            _conn.AddParameter("@conta", conta);
            _conn.AddParameter("@senha", senha);
            _conn.AddParameter("@agencia", agencia);
            try
            {
                SqlDataReader result;
                result = _conn.ExecuteReader();
                while (result.Read())
                {
                    contaClienteAlteracao = new ContaClienteAlteracao
                    {
                        conta = result["num"].ToString(),
                        senha = result["senha"].ToString()
                    };
                    contaClienteAlteracao.Clientes.Add(new Cliente
                    {
                        nome = result["nome"].ToString()
                    });
                    contaClienteAlteracao.ativo = bool.Parse(result["ativo"].ToString());
                }
                if (contaClienteAlteracao == null)
                {
                    _notifications.Notificacoes.Add("Não foi possível buscar a conta!");
                }
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível alterar conta! Erro {e.Message}");
            }
            return contaClienteAlteracao;
        }
    }
}
