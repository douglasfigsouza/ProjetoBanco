﻿using System.Collections.Generic;

using ProjetoBanco.Domain.Entities;

namespace ProjetoBanco.Domain.Interfaces.IRepositories
{
    public interface IContaClienteRepositoryDomain
    {
        void AddContaCliente(Conta conta, List<ContaCliente>contaClientes);
        ContaClienteAlteracao GetContaCliente(string conta, int agencia, string senha);
        void Dispose();
    }
}
