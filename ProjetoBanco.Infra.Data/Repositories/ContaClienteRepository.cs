using ProjetoBanco.Domain.Clientes;
using ProjetoBanco.Domain.Contas;
using System.Collections.Generic;

namespace ProjetoBanco.Infra.Data.Repositories
{
    public class ContaClienteRepository : IContaClienteRepository
    {
        private readonly Conexao _conn;

        public enum Procedure
        {
            PBSP_INSERTCONTA,
            PBSP_INSERTCONTACLIENTE,
            PBSP_GETCONTA,
            PBSP_UPDATECONTA,
            PBSP_SELDADOSCONTACLIENTE,
            PBSP_GETALLCONTAS
        }

        public ContaClienteRepository(Conexao conn)
        {
            _conn = conn;
        }
        public void AddContaCliente(Conta conta)
        {
            _conn.ExecuteProcedure(Procedure.PBSP_INSERTCONTA);
            _conn.AddParameter("@num", conta.num);
            _conn.AddParameter("@senha", conta.senha);
            _conn.AddParameter("@tipo", conta.tipo);
            _conn.AddParameter("@ativo", conta.ativo);

            var contaId = _conn.ExecuteNonQueryWithReturn();
            foreach (var item in conta.contaClientes)
            {
                _conn.ExecuteProcedure(Procedure.PBSP_INSERTCONTACLIENTE);
                _conn.AddParameter("@contaId", contaId);
                _conn.AddParameter("@clienteId", item.clienteId);
                _conn.AddParameter("@agencia", item.agencia);
                _conn.ExecuteNonQuery();
            }
        }
        public void UpdateConta(Conta conta)
        {
            _conn.ExecuteProcedure(Procedure.PBSP_UPDATECONTA);
            _conn.AddParameter("@conta", conta.num);
            _conn.AddParameter("@senha", conta.senha);
            _conn.AddParameter("@ativo", conta.ativo);
            _conn.ExecuteNonQuery();
        }
        public ContaClienteAlteracao GetConta(string conta, string senha)
        {
            var contaClienteAlteracao = new ContaClienteAlteracao();
            _conn.ExecuteProcedure(Procedure.PBSP_SELDADOSCONTACLIENTE);
            _conn.AddParameter("@conta", conta);
            _conn.AddParameter("@senha", senha);
            using (var result = _conn.ExecuteReader())
                while (result.Read())
                {
                    contaClienteAlteracao.conta = result["num"].ToString();
                    contaClienteAlteracao.senha = result["senha"].ToString();
                    contaClienteAlteracao.Clientes.Add(new ClienteDto()
                    {
                        nome = result["nome"].ToString()
                    });
                    contaClienteAlteracao.ativo = bool.Parse(result["ativo"].ToString());
                }
            return contaClienteAlteracao;
        }

        public List<ContaClienteAlteracao> GetAllContas()
        {
            _conn.ExecuteProcedure(Procedure.PBSP_GETALLCONTAS);
            var contas = new List<ContaClienteAlteracao>();
            var contaCliAlteracao = new ContaClienteAlteracao();
            using (var result = _conn.ExecuteReader())
                while (result.Read())
                {
                    contaCliAlteracao.agencia = int.Parse(result["agencia"].ToString());
                    contaCliAlteracao.contaId = int.Parse(result["contaId"].ToString());
                    contaCliAlteracao.conta = result["num"].ToString();
                    contaCliAlteracao.senha = result["senha"].ToString();
                    contaCliAlteracao.clienteId = int.Parse(result["clienteId"].ToString());
                    contaCliAlteracao.idCliContaCliente = int.Parse(result["idCliContaCliente"].ToString());
                    if (contaCliAlteracao.idCliContaCliente == contaCliAlteracao.clienteId)
                    {
                        contaCliAlteracao.Clientes.Add(new ClienteDto
                        {
                            Id = int.Parse(result["clienteId"].ToString()),
                            nome = result["nome"].ToString()

                        });
                    }
                    contas.Add(contaCliAlteracao);

                }
            return contas;
        }
    }
}
