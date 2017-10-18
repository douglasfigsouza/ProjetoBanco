﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Interfaces.IRepositories;

namespace ProjetoBanco.Infra.Data.Repositories
{
    public class BancoRepository:IBancoRepositoryDomain
    {
        private Conexao conn;
        private SqlDataReader result;
        private List<Banco> lstBancos;

        public enum Procedures
        {
            PBSP_INSERTBANCO,
            PBSP_GETALLBANCOS
        }
        public BancoRepository()
        {
            conn = new Conexao();
            lstBancos = new List<Banco>();
        }
        public string AddBanco(Banco banco)
        {
            try
            {
                conn.ExecuteProcedure(Procedures.PBSP_INSERTBANCO);
                conn.AddParameter("@nome", banco.nome);
                conn.AddParameter("@ativo", banco.ativo);
                conn.ExecuteNonQuery();
                return null;
            }
            catch (Exception e)
            {
                return e.ToString();
            }

        }

        public Banco GetByBancoId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Banco> GetAllBancos()
        {
            conn.ExecuteProcedure(Procedures.PBSP_GETALLBANCOS);
            result = conn.ExecuteReader();
            while (result.Read())
            {
                lstBancos.Add(new Banco
                {
                    Id = Convert.ToInt32(result["Id"].ToString()),
                    nome = result["nome"].ToString()
                });
            }
            return lstBancos.ToList();
        }

        public string UpdateBanco(Banco banco)
        {
            throw new NotImplementedException();
        }


        public void RemoveBanco(Banco banco)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
