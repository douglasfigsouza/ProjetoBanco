﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Interfaces.IRepositories;

namespace ProjetoBanco.Infra.Data.Repositories
{
    public class AgenciaRepository : IAgenciaRepositoryDomain
    {
        private Conexao conn;
        private SqlDataReader result;
        private List<Agencia> Agencias;
        private Agencia Agencia;
        public enum Procedures
        {
            PBSP_INSERTAGENCIA,
            PBSP_GETALLAGENCIAS,
            PBSP_GETAGENCIABYNUM,
            PBSP_UPDATEAGENCIA
        }
        public AgenciaRepository()
        {
            conn = new Conexao();
            Agencias = new List<Agencia>();
            Agencia = new Agencia();
        }

        public string AddAgencia(Agencia agencia)
        {
            try
            {
                conn.ExecuteProcedure(Procedures.PBSP_INSERTAGENCIA);
                conn.AddParameter("@cidadeId", agencia.CidadeId);
                conn.AddParameter("@bancoId", agencia.bancoId);
                conn.AddParameter("@agencia", agencia.agencia);
                conn.AddParameter("@ativo", agencia.agencia);
                conn.ExecuteNonQuery();
                return null;
            }
            catch (Exception e)
            {
                return e.ToString();
            }

        }

        public IEnumerable<Agencia> GetAllAgencias()
        {
            try
            {
                conn.ExecuteProcedure(Procedures.PBSP_GETALLAGENCIAS);
                result = conn.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            while (result.Read())
            {
                Agencias.Add(new Agencia
                {
                    bancoId = Convert.ToInt32(result["bancoId"].ToString()),
                    agencia = Convert.ToInt32(result["agencia"].ToString()),
                    CidadeId = Convert.ToInt32(result["CidadeId"].ToString()),
                    ativo = Convert.ToBoolean(result["ativo"].ToString())                 
                });
            }
            return Agencias.ToList();
        }
        public string UpdateAgencia(Agencia agencia)
        {
            try
            {
                conn.ExecuteProcedure(Procedures.PBSP_UPDATEAGENCIA);
                conn.AddParameter("@agencia", agencia.agencia);
                conn.AddParameter("@ativo", agencia.ativo);
                conn.ExecuteNonQuery();
                return null;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public void Dispose()
        {

        }

        public Agencia GetAgenciaByNum(int agencia)
        {
            try
            {
                conn.ExecuteProcedure(Procedures.PBSP_GETAGENCIABYNUM);
                conn.AddParameter("@agencia", agencia);
                result = conn.ExecuteReader();
                while (result.Read())
                {
                    Agencia.agencia = int.Parse(result["agencia"].ToString());
                    Agencia.banco = result["nome"].ToString();
                    Agencia.ativo = Convert.ToBoolean(result["ativo"].ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return Agencia;
        }
    }
}
