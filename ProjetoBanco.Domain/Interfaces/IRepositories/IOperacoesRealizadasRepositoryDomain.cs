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
        void AddOpRealizada(OperacaoRealizada operacaoRealizada, Operacoes op);
        void Dispose();
    }
}
