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
        void Dispose();
    }
}
