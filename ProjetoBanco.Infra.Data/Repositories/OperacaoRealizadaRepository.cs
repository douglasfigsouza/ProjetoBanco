﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Interfaces.IRepositories;

namespace ProjetoBanco.Infra.Data.Repositories
{
    public class OperacaoRealizadaRepository:IOperacoesRealizadasRepositoryDomain
    {
        private Conexao conn;
        private SqlDataReader result;
        private enum Procedure
        {
            PBSP_DEPOSITO,
            PBSP_SAQUE,
            PBSP_TRANSFERENCIA
        }

        public OperacaoRealizadaRepository()
        {
            conn= new Conexao();
        }
        public void Deposito(OperacaoRealizada operacaoRealizada, int op)
        {
            conn.ExecuteProcedure(Procedure.PBSP_DEPOSITO);
            conn.AddParameter("@operacaoId",op);
            conn.AddParameter("@agencia", operacaoRealizada.agencia);
            conn.AddParameter("@contaId", operacaoRealizada.contaId);
            conn.AddParameter("@clienteId", operacaoRealizada.clienteId);
            conn.AddParameter("@dataOp", operacaoRealizada.dataOp);
            conn.AddParameter("@valorOp", operacaoRealizada.valorOp);
            conn.ExecuteNonQuery();

        }

        public int Transferencia(OperacaoRealizada opConta1, OperacaoRealizada opConta2)
        {
            conn.ExecuteProcedure(Procedure.PBSP_TRANSFERENCIA);
            conn.AddParameter("@agencia", opConta1.agencia);
            conn.AddParameter("@contaId", opConta1.contaId);
            conn.AddParameter("@clienteId", opConta1.clienteId);
            conn.AddParameter("@dataOp", opConta1.dataOp);
            conn.AddParameter("@valorOp", opConta1.valorOp);

            conn.AddParameter("@agencia1", opConta2.agencia);
            conn.AddParameter("@conta1Id", opConta2.contaId);
            conn.AddParameter("@cliente1Id", opConta2.clienteId);
            conn.AddParameter("@dataOp1", opConta2.dataOp);
            conn.AddParameter("@valorOp1", opConta2.valorOp);

            return conn.ExecuteNonQueryWithReturn();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int Saque(OperacaoRealizada operacaoRealizada, int op)
        {
            conn.ExecuteProcedure(Procedure.PBSP_SAQUE);
            conn.AddParameter("@operacaoId", op);
            conn.AddParameter("@agencia", operacaoRealizada.agencia);
            conn.AddParameter("@contaId", operacaoRealizada.contaId);
            conn.AddParameter("@clienteId", operacaoRealizada.clienteId);
            conn.AddParameter("@dataOp", operacaoRealizada.dataOp);
            conn.AddParameter("@valorOp", operacaoRealizada.valorOp);

            return conn.ExecuteNonQueryWithReturn();
        }
    }
}
