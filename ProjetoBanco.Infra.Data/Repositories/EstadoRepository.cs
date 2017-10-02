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
    public class EstadoRepository:IEstadoRepositoryDomain
    {
        private readonly Conexao conn;
        private SqlDataReader result;
        private List<Estado> lstEstados;

        private enum Procedures
        {
            PBSP_GETALLESTADOS
        }
        public EstadoRepository()
        {
            conn = new Conexao();
            lstEstados = new List<Estado>();

        }

        public Estado GetByEstadoId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Estado> GetAllEstados()
        {
            conn.ExecuteProcedure(Procedures.PBSP_GETALLESTADOS);
            result = conn.ExecuteReader();
            while (result.Read())
            {
                lstEstados.Add(new Estado
                {
                    Sigla = result["Sigla"].ToString(),
                    EstadoId = Convert.ToInt32(result["EstadoId"].ToString())
                });
            }
            return lstEstados;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
