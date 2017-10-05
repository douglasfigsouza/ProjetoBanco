using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Interfaces.IRepositories;
using ProjetoBanco.Domain.Interfaces.IServices;

namespace ProjetoBanco.Application
{
    public class OperacoesRealizadasAppService:IOperacaoesRealizadasAppService
    {
        private readonly IOperacoesRealizadasRepositoryDomain _operacoesRealizadasRepositoryDomain;
        private readonly IOperacoeRealizadaServiceDomain _operacoesRealizadaServiceDomain;
        public OperacoesRealizadasAppService(IOperacoeRealizadaServiceDomain operacoesRealizadaServiceDomain, IOperacoesRealizadasRepositoryDomain operacoesRealizadasRepositoryDomain)
        {
            _operacoesRealizadaServiceDomain = operacoesRealizadaServiceDomain;
            _operacoesRealizadasRepositoryDomain = operacoesRealizadasRepositoryDomain;
        }
        public void AddOpRealizada(OperacaoRealizada operacaoRealizada, Operacoes op)
        {
           _operacoesRealizadasRepositoryDomain.AddOpRealizada(operacaoRealizada,op);
        }

        public void Dispose()
        {
            _operacoesRealizadasRepositoryDomain.Dispose();
            _operacoesRealizadaServiceDomain.Dispose();
        }
    }
}