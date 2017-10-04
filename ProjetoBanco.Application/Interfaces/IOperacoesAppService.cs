﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Application.Interfaces
{
    public interface IOperacoesAppService
    {
        void AddOperacao(Operacoes op);
        Operacoes GetOperacaoById(int id);
        IEnumerable<Operacoes> GetAllOperacoes();
        void UpdateOperacao(Operacoes op);
        void RemoveOperacao(Operacoes op);
        void Dispose();
    }
}
