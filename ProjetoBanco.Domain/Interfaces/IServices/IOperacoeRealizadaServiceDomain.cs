using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Domain.Interfaces.IServices
{
    public interface IOperacoeRealizadaServiceDomain
    {
        void Deposito(OperacaoRealizada operacaoRealizada, int op);
        string Saque(OperacaoRealizada operacaoRealizada, int op);
        int Transferencia(OperacaoRealizada opConta1, OperacaoRealizada opConta2);
        void Dispose();
    }
}
