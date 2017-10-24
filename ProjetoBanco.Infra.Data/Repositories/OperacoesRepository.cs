using System;
using System.Data.SqlClient;
using ProjetoBanco.Domain.Interfaces.IRepositories;
using System.Net.Http;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Operacoes;
using Convert = System.Convert;

namespace ProjetoBanco.Infra.Data.Repositories
{
    public class OperacoesRepository : IOperacoesRepository
    {
        private Notifications _notifications;
        private Conexao conn;
        private SqlDataReader result;

        public enum Procedures
        {
            PBSP_INSERTOPERACAO,
            PBSP_VERIFICADADOSTRASACAO,
            PBSP_VERIFICADADOSDATRANSFERENCIA,
            PBSP_CONSULTASALDO
        }

        public OperacoesRepository(Notifications notifications)
        {
            _notifications = notifications;
            conn = new Conexao();
        }

        public HttpResponseMessage AddOperacao(Operacoes op)
        {
            try
            {
                conn.ExecuteProcedure(Procedures.PBSP_INSERTOPERACAO);
                conn.AddParameter("@descricao", op.descricao);
                conn.AddParameter("@ativo", op.ativo);
                conn.ExecuteNonQuery();
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public Transacao VerificaDadosTransacao(Transacao transacao)
        {
            conn = new Conexao();
            conn.ExecuteProcedure(Procedures.PBSP_VERIFICADADOSTRASACAO);
            conn.AddParameter("@op", transacao.op);
            conn.AddParameter("@nivel",transacao.nivel);
            conn.AddParameter("@senhaCli", transacao.senhaCli);
            conn.AddParameter("@agencia", transacao.agencia);
            conn.AddParameter("@clienteId", transacao.clienteId);
            conn.AddParameter("@conta", transacao.conta);
            transacao = null;
            result = conn.ExecuteReader();
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
            if (transacao == null)
            {
                _notifications.Notificacoes.Add("Cliente não existente");
            }
            return transacao;
        }

        public Transacao VerificaDadosTransferencia(Transacao transacao)
        {
            conn = new Conexao();
            conn.ExecuteProcedure(Procedures.PBSP_VERIFICADADOSDATRANSFERENCIA);
            conn.AddParameter("@agencia", transacao.agencia);
            conn.AddParameter("@conta", transacao.conta);
            result = conn.ExecuteReader();
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

        public decimal ConsultaSaldo(Transacao transacao)
        {
            try
            {
                conn.ExecuteProcedure(Procedures.PBSP_CONSULTASALDO);
                conn.AddParameter("@nivel",transacao.nivel);
                conn.AddParameter("@senhaCli", transacao.senhaCli);
                conn.AddParameter("@conta", transacao.conta);
                conn.AddParameter("@agencia", transacao.agencia);
                conn.AddParameter("@clienteId", transacao.clienteId);
                decimal saldo = 0;
                result = conn.ExecuteReader();
                while (result.Read())
                {
                    saldo = decimal.Parse(result["saldo"].ToString());
                }
                return saldo;
            }
            catch (Exception ex)
            {
                return -1;

            }
 
        }
    }
}
