using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Domain.Interfaces.IRepositories
{
    public interface IOperacoesRealizadasRepositoryDomain
    {
        void Deposito(OperacaoRealizada operacaoRealizada, int op);
        int Saque(OperacaoRealizada operacaoRealizada, int op);
        void Dispose();
    }
}
