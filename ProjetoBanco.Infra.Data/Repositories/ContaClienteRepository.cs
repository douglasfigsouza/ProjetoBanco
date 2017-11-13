﻿using ProjetoBanco.Domain.Clientes;
using ProjetoBanco.Domain.Contas;
using System.Data.SqlClient;

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
            PBSP_SELDADOSCONTACLIENTE
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
        public ContaClienteAlteracao GetConta(string conta,string senha)
        {
            var contaClienteAlteracao = new ContaClienteAlteracao();
            _conn.ExecuteProcedure(Procedure.PBSP_SELDADOSCONTACLIENTE);
            _conn.AddParameter("@conta", conta);
            _conn.AddParameter("@senha", senha);
            SqlDataReader result;
            result = _conn.ExecuteReader();
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
    }
}
