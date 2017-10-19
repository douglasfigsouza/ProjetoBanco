using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Interfaces.IRepositories;

namespace ProjetoBanco.Infra.Data.Repositories
{
    public class OperacoesRepository:IOperacoesRepositoryDomain, IDisposable
    {
        private Conexao conn;
        private SqlDataReader result;
        private List<Transacao> lstTransacoes;

        public enum Procedures
        {
            PBSP_INSERTOPERACAO,
            PBSP_VERIFICADADOSTRASACAO,
            PBSP_VERIFICADADOSDATRANSFERENCIA,
            PBSP_CONSULTASALDO
        }

        public OperacoesRepository()
        {
            conn = new Conexao();
            lstTransacoes = new List<Transacao>();
        }

        public string AddOperacao(Operacoes op)
        {
            try
            {
                conn.ExecuteProcedure(Procedures.PBSP_INSERTOPERACAO);
                conn.AddParameter("@descricao", op.descricao);
                conn.ExecuteNonQuery();
                return null;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        public Operacoes GetOperacaoById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Operacoes> GetAllOperacoes()
        {
            throw new NotImplementedException();
        }

        public void UpdateOperacao(Operacoes op)
        {
            throw new NotImplementedException();
        }

        public void RemoveOperacao(Operacoes op)
        {
            throw new NotImplementedException();
        }

        public Transacao VerificaDadosTransacao(Transacao transacao, int op)
        {
            conn = new Conexao();
            conn.ExecuteProcedure(Procedures.PBSP_VERIFICADADOSTRASACAO);
            conn.AddParameter("@op", op);
            conn.AddParameter("@nivel",transacao.nivel);
            conn.AddParameter("@senhaCli", transacao.senhaCli);
            conn.AddParameter("@agencia", transacao.agencia);
            conn.AddParameter("@clienteId", transacao.clienteId);
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
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
