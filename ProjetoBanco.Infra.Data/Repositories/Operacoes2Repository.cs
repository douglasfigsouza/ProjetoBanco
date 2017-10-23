using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.JScript;
using ProjetoBanco.Domain.Entities;
using ProjetoBanco.Domain.Interfaces.IRepositories;

namespace ProjetoBanco.Infra.Data.Repositories
{
    public class Operacoes2Repository : IOperacoesRepository
    {
        private Conexao conn;
        private SqlDataReader result;

        public Operacoes2Repository()
        {
            this.conn = new Conexao();
        }

        public IEnumerable<Operacoes> GetAllOperacoes()
        {
            conn.ExecuteCommand("SELECT * FROM Operacoes");

            var lista = new List<Operacoes>();
            using (var r = conn.ExecuteReader())
            {
                while (r.Read())
                {
                    lista.Add(new Operacoes
                    {
                        Id = int.Parse(r["Id"].ToString()),
                        descricao = r["descricao"].ToString(),
                        ativo = Convert.ToBoolean(r["ativo"].ToString())
                    });
                }
            }
            return lista;
        }
    }
}
