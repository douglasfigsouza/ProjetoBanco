using ProjetoBanco.Domain.Operacoes;
using ProjetoBanco.Domain.Operacoes.Dto;
using System;
using System.Data.SqlClient;

namespace ProjetoBanco.Infra.Data.Repositories
{
    public class OperacoesRepository : IOperacoesRepository
    {
        private Conexao _conn;

        public enum Procedures
        {
            PBSP_INSERTOPERACAO,
            PBSP_SELDADOSCLIENTESAQUE,
            PBSP_VERIFICADADOSDATRANSFERENCIA,
            PBSP_CONSULTASALDO,
            PBSP_SELDADOSCLIENTEDEPOSITO
        }

        public OperacoesRepository(Conexao conn)
        {
            _conn = conn;
        }

        public void AddOperacao(Operacoes op)
        {

            _conn.ExecuteProcedure(Procedures.PBSP_INSERTOPERACAO);
            _conn.AddParameter("@descricao", op.descricao);
            _conn.AddParameter("@ativo", op.ativo);
            _conn.ExecuteNonQuery();
        }
        public Transacao VerificaDadosTransacao(Transacao transacao)
        {
            if (transacao.op == 1)
            {
                _conn.ExecuteProcedure(Procedures.PBSP_SELDADOSCLIENTEDEPOSITO);
                _conn.AddParameter("@conta", transacao.conta);
            }
            else if (transacao.op == 2)
            {
                _conn.ExecuteProcedure(Procedures.PBSP_SELDADOSCLIENTESAQUE);
                _conn.AddParameter("@senhaCli", transacao.senhaCli);
                _conn.AddParameter("@clienteId", transacao.clienteId);
                _conn.AddParameter("@conta", transacao.conta);
            }

            var valor = transacao.valor;
            SqlDataReader result = null;

            result = _conn.ExecuteReader();
            while (result.Read())
            {
                transacao = new Transacao
                {
                    clienteId = Convert.ToInt32(result["clienteId"].ToString()),
                    nome = result["nome"].ToString(),
                    bancoId = Convert.ToInt32(result["bancoId"].ToString()),
                    agencia = Convert.ToInt32(result["agencia"].ToString()),
                    contaId = Convert.ToInt32(result["contaId"].ToString()),
                    valor = valor
                };
            }
            return transacao;
        }

        public Transacao VerificaDadosTransferencia(Transacao transacao)
        {
            _conn.ExecuteProcedure(Procedures.PBSP_VERIFICADADOSDATRANSFERENCIA);
            _conn.AddParameter("@agencia", transacao.agencia);
            _conn.AddParameter("@conta", transacao.conta);
            transacao = null;
            SqlDataReader result = null;

            result = _conn.ExecuteReader();
            while (result.Read())
            {
                transacao = new Transacao
                {
                    clienteId = Convert.ToInt32(result["clienteId"].ToString()),
                    nome = result["nome"].ToString(),
                    bancoId = Convert.ToInt32(result["bancoId"].ToString()),
                    agencia = Convert.ToInt32(result["agencia"].ToString()),
                    contaId = Convert.ToInt32(result["contaId"].ToString()),
                };
            }
            return transacao;
        }

        public Transacao ConsultaSaldo(Transacao transacao)
        {
            _conn.ExecuteProcedure(Procedures.PBSP_CONSULTASALDO);
            _conn.AddParameter("@nivel", transacao.nivel);
            _conn.AddParameter("@senhaCli", transacao.senhaCli);
            _conn.AddParameter("@conta", transacao.conta);
            _conn.AddParameter("@agencia", transacao.agencia);
            _conn.AddParameter("@clienteId", transacao.clienteId);

            SqlDataReader result = null;
            result = _conn.ExecuteReader();
            while (result.Read())
            {
                transacao = new Transacao();
                transacao.valor = decimal.Parse(result["saldo"].ToString());
                transacao.nome = result["nome"].ToString();
                transacao.conta = result["num"].ToString();

            }
            return transacao;
        }
    }
}
