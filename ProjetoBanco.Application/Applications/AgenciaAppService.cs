﻿using System;
using System.Collections.Generic;
using ProjetoBanco.Application.Interfaces;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Interfaces.IRepositories;
using ProjetoBanco.Domain.Interfaces.IServices;

namespace ProjetoBanco.Application
{
    public class AgenciaAppService : IAgenciaAppService
    {
        private readonly IAgenciaServiceDomain _agenciaServiceDomain;
        private readonly IAgenciaRepositoryDomain _agenciaRepositoryDomain;

        public AgenciaAppService(IAgenciaServiceDomain agenciaServiceDomain,
            IAgenciaRepositoryDomain agenciaRepositoryDomain)
        {
            _agenciaServiceDomain = agenciaServiceDomain;
            _agenciaRepositoryDomain = agenciaRepositoryDomain;
        }

        public string AddAgencia(Agencia agencia)
        {
            return _agenciaRepositoryDomain.AddAgencia(agencia);
        }
        public IEnumerable<Agencia> GetAllAgencias()
        {
            return _agenciaRepositoryDomain.GetAllAgencias();
        }

        public string UpdateAgencia(Agencia agencia)
        {
            return _agenciaRepositoryDomain.UpdateAgencia(agencia);
        }

        public void Dispose()
        {
            _agenciaRepositoryDomain.Dispose();
        }
        public Agencia GetAgenciaByNum(int agencia)
        {
            return _agenciaRepositoryDomain.GetAgenciaByNum(agencia);
        }
    }
}