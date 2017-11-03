using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Operacoes;
using ProjetoBanco.Domain.Operacoes.Dto;
using System;
using System.Data.SqlClient;

namespace ProjetoBanco.Infra.Data.Repositories
{
    public class OperacoesRepository : IOperacoesRepository
    {
        private Notifications _notifications;
        private Conexao _conn;
        private SqlDataReader result;

        public enum Procedures
        {
            PBSP_INSERTOPERACAO,
            PBSP_VERIFICADADOSTRASACAO,
            PBSP_VERIFICADADOSDATRANSFERENCIA,
            PBSP_CONSULTASALDO
        }

        public OperacoesRepository(Notifications notifications, Conexao conn)
        {
            _notifications = notifications;
            _conn = conn;
        }

        public void AddOperacao(Operacoes op)
        {
            try
            {
                _conn.ExecuteProcedure(Procedures.PBSP_INSERTOPERACAO);
                _conn.AddParameter("@descricao", op.descricao);
                _conn.AddParameter("@ativo", op.ativo);
                _conn.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Operação não cadastrada! Erro {e.Message}");
            }
        }
        public Transacao VerificaDadosTransacao(Transacao transacao)
        {
            _conn = new Conexao();
            _conn.ExecuteProcedure(Procedures.PBSP_VERIFICADADOSTRASACAO);
            _conn.AddParameter("@op", transacao.op);
            _conn.AddParameter("@nivel", transacao.nivel);
            _conn.AddParameter("@senhaCli", transacao.senhaCli);
            _conn.AddParameter("@agencia", transacao.agencia);
            _conn.AddParameter("@clienteId", transacao.clienteId);
            _conn.AddParameter("@conta", transacao.conta);
            var valor = transacao.valor;
            transacao = null;
            try
            {
                result = _conn.ExecuteReader();
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível localizar conta! Erro{e.Message}");
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
                    valor = valor
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
            _conn.ExecuteProcedure(Procedures.PBSP_VERIFICADADOSDATRANSFERENCIA);
            _conn.AddParameter("@agencia", transacao.agencia);
            _conn.AddParameter("@conta", transacao.conta);
            transacao = null;
            try
            {
                result = _conn.ExecuteReader();
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
            if (transacao == null)
            {
                _notifications.Notificacoes.Add("Conta para a transferência não existe!");
            }
            return transacao;
        }

        public Transacao ConsultaSaldo(Transacao transacao)
        {
            try
            {
                _conn.ExecuteProcedure(Procedures.PBSP_CONSULTASALDO);
                _conn.AddParameter("@nivel", transacao.nivel);
                _conn.AddParameter("@senhaCli", transacao.senhaCli);
                _conn.AddParameter("@conta", transacao.conta);
                _conn.AddParameter("@agencia", transacao.agencia);
                _conn.AddParameter("@clienteId", transacao.clienteId);
                result = _conn.ExecuteReader();
                transacao = null;
                while (result.Read())
                {
                    transacao = new Transacao();
                    transacao.valor = decimal.Parse(result["saldo"].ToString());
                    transacao.nome = result["nome"].ToString();
                    transacao.conta = result["num"].ToString();

                }
                if (transacao == null)
                {
                    _notifications.Notificacoes.Add("Conta não encontrada!");
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
