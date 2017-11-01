using ProjetoBanco.Domain.Entities;
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
        private Notifications _notifications;
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

        public OperacaoRealizadaRepository(Notifications notifications, Conexao conn)
        {
            _notifications = notifications;
            _conn = conn;
        }
        public void Deposito(OperacoesRealizadas operacaoRealizada)
        {
            _conn.ExecuteProcedure(Procedure.PBSP_DEPOSITO);
            _conn.AddParameter("@codTipoOp", operacaoRealizada.operacaoId);
            _conn.AddParameter("@contaId", operacaoRealizada.contaId);
            _conn.AddParameter("@clienteId", operacaoRealizada.clienteId);
            _conn.AddParameter("@dataOp", operacaoRealizada.dataOp);
            _conn.AddParameter("@valorOp", operacaoRealizada.valorOp);
            try
            {
                _conn.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Conta não encontrada! Erro {e.Message}");
                throw;
            }

        }
        public void Transferencia(List<OperacoesRealizadas> operacoes)
        {
            OperacoesRealizadas opConta1 = new OperacoesRealizadas();
            OperacoesRealizadas opConta2 = new OperacoesRealizadas();

            opConta1 = operacoes.ElementAt(0);
            opConta2 = operacoes.ElementAt(1);
            _conn.ExecuteProcedure(Procedure.PBSP_SAQUE);
            _conn.AddParameter("codTipoOp", 2);
            _conn.AddParameter("@agencia", opConta1.agencia);
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
            }

            else
            {
                _notifications.Notificacoes.Add("A transferência não pode ser realizada, você não possui saldo suficiente");
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
            try
            {
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
                if (OpsEstorno.Count == 0)
                {
                    _notifications.Notificacoes.Add("Não existem operações para estorno!");
                }
                return OpsEstorno;
            }
            catch (Exception ex)
            {
                _notifications.Notificacoes.Add($"Impossível obter operações para estorno! Erro {ex.Message}");
                return null;
            }


        }
        public void ConfirmEstorno(int id)
        {
            _conn.ExecuteProcedure(Procedure.PBSP_ESTORNA);
            _conn.AddParameter("@id", id);
            _conn.AddParameter("@opId", 4);

            try
            {
                _conn.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível realizar o estorno!Erro {e.Message}");
            }

        }
        public void Saque(OperacoesRealizadas operacaoRealizada)
        {
            _conn.ExecuteProcedure(Procedure.PBSP_SAQUE);
            _conn.AddParameter("@codTipoOp", operacaoRealizada.operacaoId);
            _conn.AddParameter("@contaId", operacaoRealizada.contaId);
            _conn.AddParameter("@clienteId", operacaoRealizada.clienteId);
            _conn.AddParameter("@dataOp", operacaoRealizada.dataOp);
            _conn.AddParameter("@valorOp", operacaoRealizada.valorOp);
            try
            {
                if (_conn.ExecuteNonQueryWithReturn() == 0)
                    _notifications.Notificacoes.Add("Você não possui saldo suficiente!");
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível realizar saque!Erro {e.Message}");
                throw;
            }
        }
        public IEnumerable<Estorno> GetAllOperacoesEstorno()
        {
            SqlDataReader result = null;
            var OpsEstorno = new List<Estorno>();

            _conn.ExecuteProcedure(Procedure.PBSP_GETALLOPERACOESESTORNO);
            try
            {
                result = _conn.ExecuteReader();
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível buscar operações! Erro {e.Message}");
            }
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
            if (OpsEstorno.Count == 0)
            {
                _notifications.Notificacoes.Add("Não existem operações para estorno!");
            }
            return OpsEstorno;
        }

        public Estorno GetOpRealizadaEstornoById(int Id)
        {
            SqlDataReader result = null;
            _conn.ExecuteProcedure(Procedure.PBSP_GETOPREALIZADAESTORNOBYID);
            _conn.AddParameter("@Id", Id);
            Estorno estorno = null;
            try
            {
                result = _conn.ExecuteReader();
            }
            catch (Exception e)
            {
                _notifications.Notificacoes.Add($"Impossível buscar a operação selecionada! Erro: {e.Message}");
                throw;
            }
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
            if (estorno == null)
            {
                _notifications.Notificacoes.Add("Operação não encontrada!");
            }
            return estorno;
        }
    }
}
