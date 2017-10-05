﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Application.Interfaces
{
    public interface IContaClienteAppService
    {
        void AddContaCliente(Conta conta, List<ContaCliente> contaCliente);
        void Dispose();
    }
}
