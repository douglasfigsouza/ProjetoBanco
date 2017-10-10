using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
            PBSP_CONSULTASALDO
        }

        public OperacoesRepository()
        {
            conn = new Conexao();
            lstTransacoes = new List<Transacao>();
        }

        public void AddOperacao(Operacoes op)
        {
            try
            {
                conn.ExecuteProcedure(Procedures.PBSP_INSERTOPERACAO);
                conn.AddParameter("@descricao", op.descricao);
                conn.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
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

        public Transacao VerificaDadosDeposito(Transacao transacao)
        {
            conn = new Conexao();
            conn.ExecuteProcedure(Procedures.PBSP_VERIFICADADOSTRASACAO);
            conn.AddParameter("@agencia", transacao.agencia);
            conn.AddParameter("@conta", transacao.conta);
            conn.AddParameter("@clienteId", transacao.clienteId);
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

        public List<Transacao> VerificaDadosTransferencia(List<Transacao> transacoes)
        {
            foreach (var transacao in transacoes)
            {
                conn= new Conexao();
                conn.ExecuteProcedure(Procedures.PBSP_VERIFICADADOSTRASACAO);
                conn.AddParameter("@agencia", transacao.agencia);
                conn.AddParameter("@conta", transacao.conta);
                conn.AddParameter("@clienteId", transacao.clienteId);
                result = conn.ExecuteReader();
                while (result.Read())
                {
                    lstTransacoes.Add(new Transacao
                    {
                        clienteId = Convert.ToInt32(result["clienteId"].ToString()),
                        nome = result["nome"].ToString(),
                        bancoId = Convert.ToInt32(result["bancoId"].ToString()),
                        agencia = Convert.ToInt32(result["agencia"].ToString()),
                        contaId = Convert.ToInt32(result["contaId"].ToString()),
                    });
                }
            }
         
            return lstTransacoes;
        }

        public decimal ConsultaSaldo(Transacao transacao)
        {
            conn.ExecuteProcedure(Procedures.PBSP_CONSULTASALDO);
            conn.AddParameter("@conta",transacao.conta);
            conn.AddParameter("@agencia", transacao.agencia);
            conn.AddParameter("@clienteId", transacao.clienteId);
            result = conn.ExecuteReader();
            decimal saldo=0;
            while (result.Read())
            {
                saldo = Convert.ToDecimal(result["Saldo"].ToString());
            }
            return saldo ;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
