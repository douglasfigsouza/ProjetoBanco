using ProjetoBanco.Domain.Bancos;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProjetoBanco.Infra.Data.Repositories
{
    public class BancoRepository : IBancoRepository
    {
        private readonly Conexao _conn;
        public enum Procedures
        {
            PBSP_INSERTBANCO,
            PBSP_GETALLBANCOS
        }
        public BancoRepository(Conexao conn)
        {
            _conn = conn;
        }
        public void AddBanco(Banco banco)
        {

            _conn.ExecuteProcedure(Procedures.PBSP_INSERTBANCO);
            _conn.AddParameter("@nome", banco.nome);
            _conn.AddParameter("@ativo", banco.ativo);
            _conn.ExecuteNonQuery();

        }
        public IEnumerable<Banco> GetAllBancos()
        {
            SqlDataReader result = null;
            List<Banco> bancos = new List<Banco>();

            _conn.ExecuteProcedure(Procedures.PBSP_GETALLBANCOS);
            result = _conn.ExecuteReader();

            while (result.Read())
            {
                bancos.Add(new Banco
                {
                    Id = int.Parse(result["Id"].ToString()),
                    nome = result["nome"].ToString()
                });
            }
            return bancos;
        }
    }
}
