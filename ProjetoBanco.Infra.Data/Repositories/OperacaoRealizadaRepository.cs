using ProjetoBanco.Domain.Operacoes;
using ProjetoBanco.Domain.Operacoes.Dto;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ProjetoBanco.Infra.Data.Repositories
{
    public class OperacaoRealizadaRepository : IOperacoesRealizadasRepository
    {
        private readonly Conexao _conn;
        private enum Procedure
        {
            PBSP_DEPOSITO,
            PBSP_SAQUE,
            PBSP_TRANSFERENCIA,
            PBSP_GETALLOPERACOESESTORNO,
            PBSP_GETOPREALIZADASPORCONTA,
            PBSP_ESTORNA,
            PBSP_GETOPREALIZADAESTORNOBYID
        }

        public OperacaoRealizadaRepository(Conexao conn)
        {
            _conn = conn;
        }
        public void Deposito(OperacoesRealizadas operacaoRealizada)
        {
            _conn.ExecuteProcedure(Procedure.PBSP_DEPOSITO);
            _conn.AddParameter("@codTipoOp", operacaoRealizada.operacaoId);
            _conn.AddParameter("@contaId", operacaoRealizada.contaId);
            _conn.AddParameter("@clienteId", operacaoRealizada.clienteId);
            _conn.AddParameter("@dataOp", operacaoRealizada.dataOp);
            _conn.AddParameter("@valorOp",operacaoRealizada.valorOp);
            _conn.ExecuteNonQuery();
        }
        public int Transferencia(List<OperacoesRealizadas> operacoes)
        {
            OperacoesRealizadas opConta1 = new OperacoesRealizadas();
            OperacoesRealizadas opConta2 = new OperacoesRealizadas();

            opConta1 = operacoes.ElementAt(0);
            opConta2 = operacoes.ElementAt(1);
            _conn.ExecuteProcedure(Procedure.PBSP_SAQUE);
            _conn.AddParameter("codTipoOp", 2);
            _conn.AddParameter("@contaId", opConta1.contaId);
            _conn.AddParameter("@clienteId", opConta1.clienteId);
            _conn.AddParameter("@dataOp", opConta1.dataOp);
            _conn.AddParameter("@valorOp", opConta1.valorOp);
            if (_conn.ExecuteNonQueryWithReturn() == 1)
            {
                _conn.ExecuteProcedure(Procedure.PBSP_TRANSFERENCIA);
                _conn.AddParameter("codTipoOp", 4);
                _conn.AddParameter("@agencia", opConta2.agencia);
                _conn.AddParameter("@contaId", opConta2.contaId);
                _conn.AddParameter("@dataOp", opConta2.dataOp);
                _conn.AddParameter("@valorOp", opConta1.valorOp);
                _conn.ExecuteNonQuery();
                return 1;
            }

            else
            {
                return 0;

            }
        }
        public List<Estorno> GetAllOperacoesPorContaParaEstorno(DadosGetOpReal dadosGetOp)
        {
            SqlDataReader result = null;
            var OpsEstorno = new List<Estorno>();
            _conn.ExecuteProcedure(Procedure.PBSP_GETOPREALIZADASPORCONTA);
            _conn.AddParameter("@conta", dadosGetOp.conta);
            _conn.AddParameter("@senha", dadosGetOp.senha);
            _conn.AddParameter("@agencia", dadosGetOp.agencia);

            result = _conn.ExecuteReader();
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
        public void ConfirmEstorno(int id)
        {
            _conn.ExecuteProcedure(Procedure.PBSP_ESTORNA);
            _conn.AddParameter("@id", id);
            //insere a operação informando que a operação é um estorno 
            _conn.AddParameter("@opId", 5);
            _conn.ExecuteNonQuery();
        }
        public int Saque(OperacoesRealizadas operacaoRealizada)
        {
            _conn.ExecuteProcedure(Procedure.PBSP_SAQUE);
            _conn.AddParameter("@codTipoOp", operacaoRealizada.operacaoId);
            _conn.AddParameter("@contaId", operacaoRealizada.contaId);
            _conn.AddParameter("@clienteId", operacaoRealizada.clienteId);
            _conn.AddParameter("@dataOp", operacaoRealizada.dataOp);
            _conn.AddParameter("@valorOp", operacaoRealizada.valorOp);
            if (_conn.ExecuteNonQueryWithReturn() == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public IEnumerable<Estorno> GetAllOperacoesEstorno()
        {
            SqlDataReader result = null;
            var OpsEstorno = new List<Estorno>();

            _conn.ExecuteProcedure(Procedure.PBSP_GETALLOPERACOESESTORNO);
            result = _conn.ExecuteReader();
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

        public Estorno GetOpRealizadaEstornoById(int Id)
        {
            SqlDataReader result = null;
            _conn.ExecuteProcedure(Procedure.PBSP_GETOPREALIZADAESTORNOBYID);
            _conn.AddParameter("@Id", Id);
            Estorno estorno = null;
            result = _conn.ExecuteReader();
            while (result.Read())
            {
                estorno = new Estorno
                {
                    Id = Convert.ToInt32(result["Id"].ToString()),
                    opId = Convert.ToInt32(result["codTipoOp"].ToString()),
                    dataFormatada = String.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(result["dataOp"].ToString())),
                    valorOp = Convert.ToDecimal(result["valorOp"].ToString()),
                    saldoAnterior = Convert.ToDecimal(result["saldoAnterior"].ToString()),
                    descricao = result["descricao"].ToString(),
                    agencia = Convert.ToInt32(result["agencia"].ToString()),
                    conta = result["num"].ToString(),
                    cliente = result["nome"].ToString()
                };
            }
            return estorno;
        }
    }
}
