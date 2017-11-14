using ProjetoBanco.Domain.Clientes;
using ProjetoBanco.Domain.Contas;
using System.Collections.Generic;

namespace ProjetoBanco.Infra.Data.Repositories
{
    public class ContaClienteRepository : IContaClienteRepository
    {
        private readonly Conexao _conn;

        public enum Procedure
        {
            PBSP_INSERTCONTA,
            PBSP_INSERTCONTACLIENTE,
            PBSP_GETCONTA,
            PBSP_UPDATECONTA,
            PBSP_SELDADOSCONTACLIENTE,
            PBSP_GETALLCONTAS,
            PBSP_GETALLCLIENTESCONTA
        }

        public ContaClienteRepository(Conexao conn)
        {
            _conn = conn;
        }
        public void AddContaCliente(Conta conta)
        {
            _conn.ExecuteProcedure(Procedure.PBSP_INSERTCONTA);
            _conn.AddParameter("@num", conta.num);
            _conn.AddParameter("@senha", conta.senha);
            _conn.AddParameter("@tipo", conta.tipo);
            _conn.AddParameter("@ativo", conta.ativo);

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
        public void UpdateConta(Conta conta)
        {
            _conn.ExecuteProcedure(Procedure.PBSP_UPDATECONTA);
            _conn.AddParameter("@conta", conta.num);
            _conn.AddParameter("@senha", conta.senha);
            _conn.AddParameter("@ativo", conta.ativo);
            _conn.ExecuteNonQuery();
        }
        public ContaClienteAlteracao GetConta(int contaId)
        {
            var contaClienteAlteracao = new ContaClienteAlteracao();
            _conn.ExecuteProcedure(Procedure.PBSP_SELDADOSCONTACLIENTE);
            _conn.AddParameter("@contaId", contaId);
            using (var result = _conn.ExecuteReader())
                while (result.Read())
                {
                    contaClienteAlteracao.conta = result["num"].ToString();
                    contaClienteAlteracao.senha = result["senha"].ToString();
                    contaClienteAlteracao.Clientes.Add(new ClienteDto()
                    {
                        nome = result["nome"].ToString()
                    });
                    contaClienteAlteracao.ativo = bool.Parse(result["ativo"].ToString());
                }
            return contaClienteAlteracao;
        }

        public List<ContaClienteAlteracao> GetAllContas()
        {
            _conn.ExecuteProcedure(Procedure.PBSP_GETALLCONTAS);
            var contas = new List<ContaClienteAlteracao>();
            ContaClienteAlteracao contaCliAlteracao;
            using (var result = _conn.ExecuteReader())
                while (result.Read())
                {
                    contaCliAlteracao = new ContaClienteAlteracao
                    {
                        contaId = result.GetInt16(result.GetOrdinal("contaId")),
                        conta = result["num"].ToString(),
                        agencia = result.GetInt16(result.GetOrdinal("agencia")),
                        senha = result["senha"].ToString()
                    };

                    contas.Add(contaCliAlteracao);
                }

            return contas;
        }
        public List<ContaCliente> GetAllClientesConta()
        {
            _conn.ExecuteProcedure(Procedure.PBSP_GETALLCLIENTESCONTA);
            var clientesConta = new List<ContaCliente>();
            using (var result = _conn.ExecuteReader())
                while (result.Read())
                {
                    var contaCliente = new ContaCliente
                    {
                        contaId = result.GetInt16(result.GetOrdinal("contaCliId")),
                        clienteId = result.GetInt16(result.GetOrdinal("Id")),
                        nome = result["nome"].ToString()
                    };
                    clientesConta.Add(contaCliente);
                }
            return clientesConta;
        }
    }
}