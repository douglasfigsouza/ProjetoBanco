using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Interfaces.IRepositories;

namespace ProjetoBanco.Infra.Data.Repositories
{
    public class OperacaoRealizadaRepository : IOperacoesRealizadasRepositoryDomain
    {
        private Conexao conn;
        private SqlDataReader result;
        private List<Estorno> OpsEstorno;
        private enum Procedure
        {
            PBSP_DEPOSITO,
            PBSP_SAQUE,
            PBSP_TRANSFERENCIA,
            PBSP_GETALLOPERACOESESTORNO,
            PBSP_GETOPREALIZADASPORCONTA,
            PBSP_ESTORNA
        }

        public OperacaoRealizadaRepository()
        {
            conn = new Conexao();
            OpsEstorno = new List<Estorno>();
        }
        public void Deposito(OperacaoRealizada operacaoRealizada, int op)
        {
            conn.ExecuteProcedure(Procedure.PBSP_DEPOSITO);
            conn.AddParameter("@codTipoOp", op);
            conn.AddParameter("@agencia", operacaoRealizada.agencia);
            conn.AddParameter("@contaId", operacaoRealizada.contaId);
            conn.AddParameter("@clienteId", operacaoRealizada.clienteId);
            conn.AddParameter("@dataOp", operacaoRealizada.dataOp);
            conn.AddParameter("@valorOp", operacaoRealizada.valorOp);
            conn.ExecuteNonQuery();

        }
        public int Transferencia(OperacaoRealizada opConta1, OperacaoRealizada opConta2)
        {
            conn.ExecuteProcedure(Procedure.PBSP_SAQUE);
            conn.AddParameter("codTipoOp", 2);
            conn.AddParameter("@agencia", opConta1.agencia);
            conn.AddParameter("@contaId", opConta1.contaId);
            conn.AddParameter("@clienteId", opConta1.clienteId);
            conn.AddParameter("@dataOp", opConta1.dataOp);
            conn.AddParameter("@valorOp", opConta1.valorOp);
            if (conn.ExecuteNonQueryWithReturn() == 1)
            {
                conn = new Conexao();
                conn.ExecuteProcedure(Procedure.PBSP_TRANSFERENCIA);
                conn.AddParameter("codTipoOp", 4);
                conn.AddParameter("@agencia", opConta2.agencia);
                conn.AddParameter("@contaId", opConta2.contaId);
                conn.AddParameter("@dataOp", opConta2.dataOp);
                conn.AddParameter("@valorOp", opConta1.valorOp);
                conn.ExecuteNonQuery();
                return 1;
            }

            else
            {
                return 0;
            }
        }
        public IEnumerable<Estorno> GetAllOperacoesPorContaParaEstorno(string conta, string senha, int agencia)
        {
            conn.ExecuteProcedure(Procedure.PBSP_GETOPREALIZADASPORCONTA);
            conn.AddParameter("@conta", conta);
            conn.AddParameter("@senha", senha);
            conn.AddParameter("@agencia", agencia);
            try
            {
                result = conn.ExecuteReader();
                while (result.Read())
                {
                    OpsEstorno.Add(new Estorno
                    {
                        Id = Convert.ToInt32(result["Id"].ToString()),
                        opId = Convert.ToInt32(result["codTipoOp"].ToString()),
                        dataOp = Convert.ToDateTime(result["dataOp"].ToString()),
                        valorOp = Convert.ToDecimal(result["valorOp"].ToString()),
                        saldoAnterior = Convert.ToDecimal(result["saldoAnterior"].ToString()),
                        descricao = result["descricao"].ToString(),
                        agencia = Convert.ToInt32(result["agencia"].ToString()),
                        conta = result["num"].ToString(),
                        cliente = result["nome"].ToString()
                    });
                }
                return OpsEstorno;
            }
            catch (Exception e)
            {
                return null;
            }


        }
        public string ConfirmEstorno(int id)
        {
            conn.ExecuteProcedure(Procedure.PBSP_ESTORNA);
            conn.AddParameter("@id", id);
            conn.AddParameter("@opId", 4);

            try
            {
                conn.ExecuteNonQuery();
                return null;
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public int Saque(OperacaoRealizada operacaoRealizada, int op)
        {
            conn.ExecuteProcedure(Procedure.PBSP_SAQUE);
            conn.AddParameter("@codTipoOp", op);
            conn.AddParameter("@agencia", operacaoRealizada.agencia);
            conn.AddParameter("@contaId", operacaoRealizada.contaId);
            conn.AddParameter("@clienteId", operacaoRealizada.clienteId);
            conn.AddParameter("@dataOp", operacaoRealizada.dataOp);
            conn.AddParameter("@valorOp", operacaoRealizada.valorOp);

            return conn.ExecuteNonQueryWithReturn();
        }
        public IEnumerable<Estorno> GetAllOperacoesEstorno()
        {
            conn.ExecuteProcedure(Procedure.PBSP_GETALLOPERACOESESTORNO);
            result = conn.ExecuteReader();

            while (result.Read())
            {
                OpsEstorno.Add(new Estorno
                {
                    Id = Convert.ToInt32(result["Id"].ToString()),
                    opId = Convert.ToInt32(result["codTipoOp"].ToString()),
                    dataOp = Convert.ToDateTime(result["dataOp"].ToString()),
                    valorOp = Convert.ToDecimal(result["valorOp"].ToString()),
                    saldoAnterior = Convert.ToDecimal(result["saldoAnterior"].ToString()),
                    descricao = result["descricao"].ToString(),
                    agencia = Convert.ToInt32(result["agencia"].ToString()),
                    conta = result["num"].ToString(),
                    cliente = result["nome"].ToString()
                });
            }
            return OpsEstorno;
        }
    }
}
