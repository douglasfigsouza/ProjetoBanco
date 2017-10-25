using System;
using System.Data.SqlClient;
using ProjetoBanco.Domain.Interfaces.IRepositories;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Operacoes;

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

        public void AddOperacao(Operacoes op)
        {
            try
            {
                conn.ExecuteProcedure(Procedures.PBSP_INSERTOPERACAO);
                conn.AddParameter("@descricao", op.descricao);
                conn.AddParameter("@ativo", op.ativo);
                conn.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add("Operação não cadastrada!");
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
            try
            {
                result = conn.ExecuteReader();
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível realizar a transferência! Erro{e.Message}");
                Console.WriteLine(e);
                throw;
            }
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
            try
            {
                conn.ExecuteProcedure(Procedures.PBSP_CONSULTASALDO);
                conn.AddParameter("@nivel",transacao.nivel);
                conn.AddParameter("@senhaCli", transacao.senhaCli);
                conn.AddParameter("@conta", transacao.conta);
                conn.AddParameter("@agencia", transacao.agencia);
                conn.AddParameter("@clienteId", transacao.clienteId);
                result = conn.ExecuteReader();
                transacao = null;
                while (result.Read())
                {
                    transacao = new Transacao();
                    transacao.valor  = decimal.Parse(result["saldo"].ToString());
                    transacao.nome = result["nome"].ToString();
                    transacao.conta = result["num"].ToString();

                }
                if (transacao == null)
                {
                    _notifications.Notificacoes.Add("Conta não encontrada e ou não existe saldo nessa conta!");
                }
                return transacao;
            }
            catch (Exception ex)
            {
                _notifications.Notificacoes.Add($"Conta não encontrada!{ex.Message}");
                return null;

            }
 
        }
    }
}
